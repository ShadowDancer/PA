using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieAbstrakcyjne4
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    class Matrix<TType>
    {
        public TType[] _data { get; set; }
        public uint Width { get; }
    public uint Height {get; }
        public Matrix(uint width, uint height)
        {
            _data = new TType[width * height];
        }

        public TType this[uint x, uint y] 
            {
                get
                {
                return _data[x * Width + y];
                }
                set
                {
                _data[x * Width + y] = value;
                }
            }

        public static Matrix<TType> operator + (Matrix<TType> a, Matrix<TType> b)
        {
            if(a.Width != b.Width || a.Height != b.Height)
            {
                throw new InvalidOperationException("Dodawanie macierzy o innych wymiwarach");
            }

            Matrix<TType> result = new Matrix<TType>(a.Width, a.Height);
            for(uint x = 0; x < a.Width; x ++)
            {
                for(uint y = 0; y < a.Height; y++)
                {
                    
                }
            }
            return result;
        }

        public static Matrix<TType> operator *(Matrix<TType> a, Matrix<TType> b)
        {
            if (a.Height != b.Width)
            {
                throw new InvalidOperationException("Wysokość pierwszej macierzy musi być równa długości drugiej");
            }

            Matrix<TType> result = new Matrix<TType>(a.Width, b.Height);
            for (uint x = 0; x < result.Width; x++)
            {
                for (uint y = 0; y < result.Height; y++)
                {
                    throw new NotImplementedException("TODO");
                }
            }
            return result;
        }
    }

    class SquareMatrix<TType> : Matrix<TType>
    {
        public SquareMatrix(uint size) : base(size, size)
        {
        }

        public bool IsDiagonal()
        {
            for (uint x = 0; x < Width; x++)
            {
                for (uint y = 0; y < Height; y++)
                {
                    if(x != y && !this[x, y].IsZero)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}
