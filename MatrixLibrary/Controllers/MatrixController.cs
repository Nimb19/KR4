using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers
{
    /// <summary>
    /// Класс методов над матрицами.
    /// </summary>
    public static partial class MatrixController
    {
        /// <summary>
        /// Метод произведения матриц.
        /// </summary>
        /// <param name="one"> Первая матрица. </param>
        /// <param name="two"> Вторая матрица. </param>
        /// <returns> Матрица - результат произведения. </returns>
        public static Matrix MatrixMultiplication(Matrix one, Matrix two)
        {
            var arr = new double[one.GetCountRows, two.GetCountColumns];

            for (int i = 0; i < one.GetCountRows; i++)
            {
                for (int j = 0; j < two.GetCountColumns; j++)
                {
                    double elementResult = 0;

                    for (int n = 0; n < one.GetCountRows; n++)
                        elementResult += one[i, n] * two[n, j];

                    arr[i, j] = elementResult;
                }
            }

            return new Matrix(arr);
        }

        /// <summary>
        /// Метод сложения матриц.
        /// </summary>
        /// <param name="one"> Первая матрица. </param>
        /// <param name="two"> Вторая матрица. </param>
        /// <returns> Матрица - результат сложения. </returns>
        public static Matrix MatrixAddition(Matrix one, Matrix two)
        {
            var arr = new double[one.GetCountRows, two.GetCountColumns];

            for (int i = 0; i < one.GetCountRows; i++)
                for (int j = 0; j < two.GetCountColumns; j++)
                    arr[i, j] = one[i, j] + two[i, j];

            return new Matrix(arr);
        }
    }
}
