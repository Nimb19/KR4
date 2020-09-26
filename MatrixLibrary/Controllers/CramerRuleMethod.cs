using System;
using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers
{
    public static partial class MatrixController
    {
        /// <summary>
        /// Метод решения СЛАУ с помощью метода Крамера.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="vector"> Вектор результатов. </param>
        /// <returns> Вектор ответов. </returns>
        public static Vector CramerRuleMethod(Matrix matrix, Vector vector)
        {
            if (matrix.GetCountColumns != matrix.GetCountRows)
                throw new ArgumentException("Матрица должна иметь одинаковое количество строк и столбцов.", nameof(matrix));
            if (matrix.GetCountRows != vector.Count)
                throw new ArgumentException("Вектор должен иметь столько же элементов, сколько и строк в матрице.", nameof(matrix));

            var mainDet = matrix.FindingTheDeterminant(true, "СЛАУ не может быть решена, т.к. определитель матрицы равен нулю.");
            
            var arrAnswers = new double[matrix.GetCountRows];
            for (int i = 0; i < matrix.GetCountRows; i++)
                arrAnswers[i] = ChangeColumnOfMatrixToSpecifiedVector(matrix, vector, i).MatrixDeterminant() / mainDet;

            return new Vector(arrAnswers);
        }

        /// <summary>
        /// Заменяет в матрице столбец под указанным индексом на вектор.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="vector"> Вектор. </param>
        /// <param name="columnIndex"> Указанный столбец (). </param>
        /// <returns> Матрица с заменённым столбцом на указанный вектор. </returns>
        public static Matrix ChangeColumnOfMatrixToSpecifiedVector(this Matrix matrix, Vector vector, int columnIndex)
        {
            double[,] arr = matrix.ArrayValues.Clone() as double[,];

            for (int m = 0; m < matrix.GetCountRows; m++)
                arr[m, columnIndex] = vector[m];

            return new Matrix(arr);
        }

        private static double[,] MatrixDecompose(double[,] matrix, out int[] perm, out int toggle)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
                throw new Exception("Attempt to MatrixDecompose a non-square matrix");

            double[,] result = MatrixDuplicate(matrix);

            perm = new int[rows];
            for (int i = 0; i < rows; ++i) { perm[i] = i; }

            toggle = 1;

            for (int j = 0; j < rows - 1; ++j)
            {
                double colMax = Math.Abs(result[j, j]);
                int pRow = j;
                for (int i = j + 1; i < rows; ++i)
                {
                    if (result[i, j] > colMax)
                    {
                        colMax = result[i, j];
                        pRow = i;
                    }
                }

                if (pRow != j)
                {
                    double[] rowPtr = new double[result.GetLength(1)];
                    for (int k = 0; k < result.GetLength(1); k++)
                        rowPtr[k] = result[pRow, k];

                    for (int k = 0; k < result.GetLength(1); k++)
                        result[pRow, k] = result[j, k];

                    for (int k = 0; k < result.GetLength(1); k++)
                        result[j, k] = rowPtr[k];

                    int tmp = perm[pRow];
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle;
                }

                if (Math.Abs(result[j, j]) < 1.0E-20)
                    return null;

                for (int i = j + 1; i < rows; ++i)
                {
                    result[i, j] /= result[j, j];
                    for (int k = j + 1; k < rows; ++k)
                    {
                        result[i, k] -= result[i, j] * result[j, k];
                    }
                }
            } 

            return result;
        } 

        private static double MatrixDeterminant(this Matrix matrix)
        {
            int[] perm;
            int toggle;
            double[,] lum = MatrixDecompose(matrix.ArrayValues, out perm, out toggle);
            if (lum == null)
                throw new ZeroDeterminantException();
            double result = toggle;
            for (int i = 0; i < lum.GetLength(0); ++i)
                result *= lum[i, i];

            return result;
        }

        private static double[,] MatrixDuplicate(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    result[i, j] = matrix[i, j];
            return result;
        }
    }
}
