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
                arrAnswers[i] = ChangeColumnOfMatrixToSpecifiedVector(matrix, vector, i).FindingTheDeterminant() / mainDet;

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
    }
}
