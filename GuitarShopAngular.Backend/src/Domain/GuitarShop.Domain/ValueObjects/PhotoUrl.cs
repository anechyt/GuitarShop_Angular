using GuitarShop.Shared.Exceptions;

namespace GuitarShop.Domain.ValueObjects
{
    public class PhotoUrl
    {
        public string Value { get; set; }

        public PhotoUrl(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 24)
                throw new NotFoundException($"PhotoUrl: {value} is invalid!");

            Value = value;
        }

        public static implicit operator PhotoUrl(string value) => value is null ? null : new PhotoUrl(value);

        public static implicit operator string(PhotoUrl value) => value.Value;

        public override string ToString() => Value;
    }
}
