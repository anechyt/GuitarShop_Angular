using GuitarShop.Application.Categories.Queries.GetAllCategory;
using GuitarShop.Infrastructure.Mapper;
using GuitarShop.Persistence.Extensions;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(GetCategories).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(GuitarShopMappingProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

await builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
