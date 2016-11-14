using System;
using System.Diagnostics;

namespace ProgramowanieAbstrakcyjne4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Matrix<int>.AdditionOperator = (a, b) => a + b;
            Matrix<int>.MultiplicationOperator = (a, b) => a*b;
            SquareMatrix<int>.IsZeroOperator = a => a == 0;

            Matrix<ComplexNumber<int, int>>.AdditionOperator =
                (a, b) => new ComplexNumber<int, int>(a.Real + b.Real, a.Imaginary + b.Imaginary);

            Matrix<ComplexNumber<int, int>>.MultiplicationOperator =
                (a, b) => new ComplexNumber<int, int>(
                    a.Real*b.Real - a.Imaginary*b.Imaginary,
                    a.Imaginary*b.Real + a.Real*b.Imaginary);

            SquareMatrix<ComplexNumber<int, int>>.IsZeroOperator = a => a.Real == 0 && a.Imaginary == 0;


            Console.WriteLine("Testing...");
            Addition();
            Multiplication();
            DiagonalTests();
            Complex();
            Console.WriteLine("OK!");


            Console.ReadKey();
        }

        private static void Print<TType>(Matrix<TType> matrix)
        {
            for (uint y = 0; y < matrix.Height; y++)
            {
                for (uint x = 0; x < matrix.Width; x++)
                {
                    Console.Write(matrix[x, y] + "\t");
                }
                Console.WriteLine();
            }
        }

        #region Tests

        private static void Addition()
        {
            var zero = new SquareMatrix<int>(2)
            {
                {0, 0},
                {0, 0}
            };

            Debug.Assert(zero + zero == zero);
            var a = new SquareMatrix<int>(2)
            {
                {1, 0},
                {0, 0}
            };
            var b = new SquareMatrix<int>(2)
            {
                {1, -1},
                {1, 0}
            };
            Debug.Assert(a + b == new SquareMatrix<int>(2)
            {
                {2, -1},
                {1, 0}
            });
        }

        private static void Multiplication()
        {
            var a = new Matrix<int>(3, 2)
            {
                {1, 0, 2},
                {-1, 3, 1}
            };
            var b = new Matrix<int>(2, 3)
            {
                {3, 1},
                {2, 1},
                {1, 0}
            };
            Debug.Assert(a*b == new SquareMatrix<int>(2)
            {
                {5, 1},
                {4, 2}
            });
        }

        private static void DiagonalTests()
        {
            Debug.Assert(new SquareMatrix<int>(5)
            {
                {0, 0, 0, 0, 0},
                {0, -1, 0, 0, 0},
                {0, 0, 6, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 21}
            }.IsDiagonal());

            Debug.Assert(!new SquareMatrix<int>(5)
            {
                {0, 0, 0, 0, 0},
                {0, -1, 0, 1, 0},
                {0, 0, 6, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 21}
            }.IsDiagonal());
        }


        private static void Complex()
        {
            Console.WriteLine("Complex");
            var a = new SquareMatrix<ComplexNumber<int, int>>(2)
            {
                {new ComplexNumber<int, int>(0, 5), new ComplexNumber<int, int>(1, -2)},
                {new ComplexNumber<int, int>(0, 0), new ComplexNumber<int, int>(0, 7)}
            };
            var b = new SquareMatrix<ComplexNumber<int, int>>(2)
            {
                {new ComplexNumber<int, int>(3, -1), new ComplexNumber<int, int>(-1, -1)},
                {new ComplexNumber<int, int>(0, 0), new ComplexNumber<int, int>(5, -2)}
            };
            Debug.Assert(a + b == new SquareMatrix<ComplexNumber<int, int>>(2)
            {
                {new ComplexNumber<int, int>(3, 4), new ComplexNumber<int, int>(0, -3)},
                {new ComplexNumber<int, int>(0, 0), new ComplexNumber<int, int>(5, 5)}
            });
            Debug.Assert(a.IsDiagonal() == false);
        }

        #endregion
    }
}