namespace ProgramowanieAbstrakcyjne4
{
    internal struct ComplexNumber
    {
        public ComplexNumber(int real, int imaginary)
        {
            Imaginary = imaginary;
            Real = real;
        }

        public int Real { get; }

        public int Imaginary { get; }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return a.Real == b.Real && a.Imaginary == b.Imaginary;
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !(a == b);
        }

        public bool Equals(ComplexNumber other)
        {
            return Real == other.Real && Imaginary == other.Imaginary;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ComplexNumber && Equals((ComplexNumber) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Real*397) ^ Imaginary;
            }
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real*b.Real - a.Imaginary*b.Imaginary, a.Imaginary*b.Real - a.Real*b.Imaginary);
        }
    }
}