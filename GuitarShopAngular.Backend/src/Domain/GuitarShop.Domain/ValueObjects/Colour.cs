using GuitarShop.Shared.Exceptions;

namespace GuitarShop.Domain.ValueObjects
{
    public class Colour
    {
        public string Value { get; set; }

        public Colour(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                throw new NotFoundException($"Color: {value} is invalid!");

            Value = value;
        }

        public static implicit operator Colour(string value) => value is null ? null : new Colour(value);

        public static implicit operator string(Colour value) => value.Value;
        public override string ToString() => Value;
    }
}
