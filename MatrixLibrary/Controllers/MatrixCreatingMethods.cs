using System.Linq;
using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers
{
    public static partial class MatrixController
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
        /// Создаёт вертикальную блочную матрицу значений из указанных матриц.
        /// </summary>
        /// <param name="matrices"> Матрицы для формирования блочной. </param>
        /// <returns> Матрица результат. </returns>
        public static Matrix CreateHorizontalBlockMatrix(params Matrix[] matrices)
        {
            int countColumns = 0;
            foreach (var m in matrices)
                countColumns += m.GetCountColumns;

            double[,] arr = new double[matrices.First().GetCountRows, countColumns];

            int currentCol = 0;
            for (int i = 0; i < matrices.Length; i++)
            {
                int k = 0, l = 0;
                for (int m = 0; m < matrices.First().GetCountRows; m++)
                {
                    for (int n = currentCol; n < matrices[i].GetCountColumns; n++)
                    {
                        arr[m, n] += matrices[i][k, l];
                        l++;
                    }
                    k++;
                }
                currentCol += matrices[i].GetCountColumns;
            }

            return new Matrix(arr);
        }

        /// <summary>
        /// Создаёт вертикальную блочную матрицу значений из указанных матриц.
        /// </summary>
        /// <param name="matrices"> Матрицы для формирования блочной. </param>
        /// <returns> Матрица результат. </returns>
        public static Matrix CreateVerticalBlockMatrix(params Matrix[] matrices)
        {
            int countRows = 0;
            foreach (var m in matrices)
                countRows += m.GetCountRows;

            double[,] arr = new double[countRows, matrices.First().GetCountColumns];

            int currentRow = 0;
            for (int i = 0; i < matrices.Length; i++)
            {
                int k = 0, l = 0;
                for (int n = 0; n < matrices.First().GetCountColumns; n++)
                {
                    for (int m = currentRow; m < matrices[i].GetCountRows; m++)
                    {
                        arr[m, n] += matrices[i][k, l];
                        l++;
                    }
                    k++;
                }
                currentRow += matrices[i].GetCountRows;
            }

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
    }
}
