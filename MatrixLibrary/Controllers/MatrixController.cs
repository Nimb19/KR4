using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers
{
    public static class MatrixController
    {
        /// <summary>
        /// Создаёт диагональную матрицу и вписывает в неё указанные значения.
        /// </summary>
        /// <param name="values"> Значения диагонали матрицы. </param>
        /// <returns> Диагональная матрица с указанными значениями. </returns>
        public static Matrix CreateDiagonalMatrix(params double[] values)
        {
            var arr = new double[values.Length, values.Length];
            for (int i = 0; i < values.Length; i++)
                arr[i, i] = values[i];
            return new Matrix(arr);
        }

        /// <summary>
        /// Создаёт единичную матрицу.
        /// </summary>
        /// <param name="mn"> Количество строк/столбцов. </param>
        /// <returns> Единичная матрица указанной размерности. </returns>
        public static Matrix CreateIdentityMatrix(int mn)
        {
            var arr = new double[mn, mn];
            for (int i = 0; i < mn; i++)
                arr[i, i] = 1;
            return new Matrix(arr);
        }

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
    }
}
