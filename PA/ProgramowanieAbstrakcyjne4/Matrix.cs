using System;
using System.Collections;
using System.Collections.Generic;

namespace ProgramowanieAbstrakcyjne4
{
    public class Matrix<TType> : IEnumerable<TType>
    {
        public static Func<TType, TType, TType> AdditionOperator;
        public static Func<TType, TType, TType> MultiplicationOperator;

        public Matrix(uint width, uint height)
        {
            Width = width;
            Height = height;
            Data = new TType[width*height];
        }

        public Matrix(uint width, uint height, TType[] data)
        {
            Width = width;
            Height = height;
            Data = data;
        }


        public TType[] Data { get; set; }
        public uint Width { get; }
        public uint Height { get; }

        public TType this[uint x, uint y]
        {
            get { return Data[x + y*Width]; }
            set { Data[x + y*Width] = value; }
        }

        public static Matrix<TType> operator +(Matrix<TType> a, Matrix<TType> b)
        {
            if (AdditionOperator == null)
            {
                throw new InvalidOperationException(
                    $"Define {nameof(SquareMatrix<TType>)}.{nameof(AdditionOperator)} before using this method!");
            }

            if (a.Width != b.Width || a.Height != b.Height)
            {
                throw new InvalidOperationException("Dodawanie macierzy o różnych wymiwarach!");
            }

            var result = new Matrix<TType>(a.Width, a.Height);
            for (uint x = 0; x < a.Width; x ++)
            {
                for (uint y = 0; y < a.Height; y++)
                {
                    result[x, y] = AdditionOperator(a[x, y], b[x, y]);
                }
            }
            return result;
        }

        public static Matrix<TType> operator *(Matrix<TType> a, Matrix<TType> b)
        {
            if (AdditionOperator == null)
            {
                throw new InvalidOperationException(
                    $"Define {nameof(SquareMatrix<TType>)}.{nameof(AdditionOperator)} before using this method!");
            }

            if (MultiplicationOperator == null)
            {
                throw new InvalidOperationException(
                    $"Define {nameof(SquareMatrix<TType>)}.{nameof(MultiplicationOperator)} before using this method!");
            }

            if (a.Height != b.Width)
            {
                throw new InvalidOperationException("Wysokość pierwszej macierzy musi być równa długości drugiej");
            }

            var result = new Matrix<TType>(a.Height, b.Width);
            for (uint x = 0; x < result.Width; x++)
            {
                for (uint y = 0; y < result.Height; y++)
                {
                    var cell = default(TType);
                    for (uint i = 0; i < a.Width; i++)
                    {
                        cell = AdditionOperator(cell, MultiplicationOperator(a[i, y], b[x, i]));
                    }

                    result[x, y] = cell;
                }
            }
            return result;
        }

        #region CustomInitializer

        // ta sztuka pozwala elegancko inicjalizować dane
        public IEnumerator<TType> GetEnumerator()
        {
            return ((IEnumerable<TType>) Data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private uint _index;

        public void Add(params TType[] input)
        {
            if (input.Length != Width)
            {
                throw new InvalidOperationException("Zła ilość danych w wierszu!");
            }

            for (var i = 0; i < input.Length; i++)
            {
                if (i + _index >= Data.Length)
                {
                    throw new InvalidOperationException("Zbyt dużo wierszy!");
                }

                Data[i + _index] = input[i];
            }
            _index += (uint) input.Length;
        }

        #endregion

        #region operator == do testów

        public static bool operator ==(Matrix<TType> a, Matrix<TType> b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object) a == null) || ((object) b == null))
            {
                return false;
            }
            if (a.Width != b.Width || a.Height != b.Height)
            {
                return false;
            }

            for (uint x = 0; x < a.Width; x++)
            {
                for (uint y = 0; y < a.Height; y++)
                {
                    if (!EqualityComparer<TType>.Default.Equals(a[x, y], b[x, y]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(Matrix<TType> a, Matrix<TType> b)
        {
            return !(a == b);
        }

        #endregion
    }
}