using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Api.Dto;
using Security.Api.Entity;
using Security.Api.Repositories.Contracts;
using Security.Api.Security.TokenValidators;
using System.Security.Claims;

namespace Security.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityRepository _securityRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly RefreshTokenValidator _refreshTokenValidator;

        public SecurityController(IPasswordHasher passwordHasher,
            IUserRepository userRepository,
            ISecurityRepository securityRepository,
            IRefreshTokenRepository refreshTokenRepository,
            RefreshTokenValidator refreshTokenValidator)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _securityRepository = securityRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _refreshTokenValidator = refreshTokenValidator;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await _userRepository.GetByEmailAsync(model.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            bool isCorrectPassword = _passwordHasher.VerifyPassword(model.Password, user.Password);

            if (!isCorrectPassword)
            {
                return Unauthorized();
            }

            var response = await _securityRepository.Authenticate(user);

            return Ok(response);
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registrationUser = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Login = model.Login,
                CreatedAt = DateTime.UtcNow
            };

            await _securityRepository.Registration(registrationUser);

            return Ok();
        }

        [Route("refresh")]
        [HttpPost]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isValidRefreshToken = _refreshTokenValidator.Validate(model.Token);

            if (!isValidRefreshToken)
            {
                return BadRequest(ModelState);
            }

            RefreshToken refreshTokenDTO = await _refreshTokenRepository.GetByTokenAsync(model.Token);

            if (refreshTokenDTO == null)
            {
                return BadRequest(ModelState);
            }

            await _refreshTokenRepository.DeleteAsync(refreshTokenDTO.UserId);

            User user = await _userRepository.GetByIdAsync(refreshTokenDTO.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var response = await _securityRepository.Authenticate(user);

            return Ok(response);

        }

        [Authorize]
        [Route("logout")]
        [HttpDelete]
        public async Task<ActionResult> Logout()
        {
            string rawUserId = HttpContext.User.FindFirstValue("UserId");

            if (!int.TryParse(rawUserId, out int userId))
            {
                return Unauthorized();
            }

            await _refreshTokenRepository.DeleteAllAsync(userId);

            return NoContent();
        }
    }
}
