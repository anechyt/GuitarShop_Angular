using GuitarShop.Shared.Exceptions;

namespace GuitarShop.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; set; }
        public Price(decimal value)
        {
            if (value <= 0 || value.Equals(null))
                throw new NotFoundException($"Price: {value} is invalid!");

            Value = value;
        }

        public static implicit operator Price(decimal value) => new Price(value);
        public static implicit operator decimal(Price value) => value.Value;
    }
}
