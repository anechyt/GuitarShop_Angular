using GuitarShop.Shared.Exceptions;

namespace GuitarShop.Domain.ValueObjects
{
    public class NumberOfStrings
    {
        public int Value { get; set; }

        public NumberOfStrings(int value)
        {
            if (value <= 0 || value > 15)
                throw new NotFoundException($"NumberOfStrings: {value} is invalid!");

            Value = value;
        }

        public static implicit operator NumberOfStrings(int value) => new NumberOfStrings(value);
        public static implicit operator int(NumberOfStrings value) => value.Value;
    }
}
