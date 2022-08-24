using GuitarShop.Shared.Exceptions;

namespace GuitarShop.Domain.ValueObjects
{
    public class Size
    {
        public double Value { get; set; }

        public Size(double value)
        {
            if (value < 0 || value.Equals(null))
                throw new NotFoundException($"Size: {value} is invalid!");

            Value = value;
        }

        public static implicit operator Size(double value) => new Size(value);

        public static implicit operator double(Size value) => value.Value;
    }
}
