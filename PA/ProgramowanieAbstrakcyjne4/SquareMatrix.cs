using System;

namespace ProgramowanieAbstrakcyjne4
{
    internal class SquareMatrix<TType> : Matrix<TType>
    {
        public static Func<TType, bool> IsZeroOperator = null;

        public SquareMatrix(uint size) : base(size, size)
        {
        }

        public SquareMatrix(uint size, TType[] data) : base(size, size, data)
        {
        }

        public bool IsDiagonal()
        {
            if (IsZeroOperator == null)
            {
                throw new InvalidOperationException(
                    $"Define {nameof(SquareMatrix<TType>)}.{nameof(IsZeroOperator)} before using this method!");
            }

            for (uint x = 0; x < Width; x++)
            {
                for (uint y = 0; y < Height; y++)
                {
                    if (x != y && !IsZeroOperator(this[x, y]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}