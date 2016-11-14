namespace ProgramowanieAbstrakcyjne4
{
    internal struct ComplexNumber<TReal, TImaginary>
    {
        public ComplexNumber(TReal real, TImaginary imaginary)
        {
            Imaginary = imaginary;
            Real = real;
        }

        public TReal Real { get; }

        public TImaginary Imaginary { get; }
    }
}