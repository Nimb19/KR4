﻿using System;
using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers
{
    public static partial class MatrixController
    {
        /// <summary>
        /// Метод умножения матрицы на число.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="number"> Число, на которое нужно умножить матрицу. </param>
        /// <returns> Матрица - результат произведения. </returns>
        public static Matrix MatrixMultiplicationByNumber(this Matrix matrix, double number)
        {
            var arr = new double[matrix.GetCountRows, matrix.GetCountColumns];

            for (int i = 0; i < matrix.GetCountRows; i++)
                for (int j = 0; j < matrix.GetCountColumns; j++)
                    arr[i, j] = matrix[i, j] * number;

            return new Matrix(arr);
        }

        /// <summary>
        /// Метод сравнения матриц.
        /// </summary>
        /// <param name="one"> Первая матрица. </param>
        /// <param name="two"> Вторая матрица. </param>
        /// <returns> true - если значения матриц равны. </returns>
        public static bool MatrixComparison(Matrix one, Matrix two)
        {
            if (one as object == null && two as object == null)
                return true;
            if (one as object == null || two as object == null)
                return false;
            for (int i = 0; i < one.GetCountRows; i++)
                for (int j = 0; j < one.GetCountColumns; j++)
                    if (Math.Abs(one[i, j] - two[i, j]) > 0.01)
                        return false;
            return true;
        }

        /// <summary>
        /// Метод нахождения определителя матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Определитель матрицы. </returns>
        public static double FindingTheDeterminant(this Matrix _matrix, bool throwNewErrorIfTheDeterminantIsZero = false, string exceptionMessage = "")
        {
            if (_matrix.GetCountColumns != _matrix.GetCountRows)
                throw new ArgumentException("У матрицы должно совпадать количество строк и столбцов.", nameof(_matrix));

            //int i, j, k;
            //double det;
            //int n = _matrix.GetCountColumns;
            Matrix matrix = new Matrix(_matrix.ArrayValues.Clone() as double[,]);

            //for (i = 0; i < n - 1; i++)
            //    for (j = i + 1; j < n; j++)
            //    {
            //        var num = matrix[j, i] / matrix[i, i];
            //        if (Double.IsNaN(num))
            //            det = 0;
            //        else if (Double.IsInfinity(num))
            //            det = 0;
            //        else
            //            det = num;

            //        for (k = i; k < n; k++) {
            //            var res = matrix[j, k] - det * matrix[i, k];
            //            matrix[j, k] = Double.IsNaN(res) ? 0 : res;
            //        }
            //    }

            //det = 1;
            //for (i = 0; i < n; i++)
            //    det = det * matrix[i, i];

            //if (det == 0 && throwNewErrorIfTheDeterminantIsZero)
            //    throw new ZeroDeterminantException(exceptionMessage);

            //return det;

            double det = 0;
            double value = 0;
            
            int n = matrix.GetCountRows;

            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    det = matrix[j, i] / matrix[i, i];

                    for (var k = i; k < n; k++)
                    {
                        value = matrix[j, k] - det * matrix[i, k];

                        matrix[j, k] = value;
                    }
                }
            }
            det = 1;
            for (var i = 0; i < n; i++)
                det = det * matrix[i, i];

            return det;
        }

        /// <summary>
        /// Метод транспонирования матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <returns> Матрица - результат транспонирования. </returns>
        public static Matrix TransposeOfTheMatrix(this Matrix matrix)
        {
            var arr = new double[matrix.GetCountRows, matrix.GetCountColumns];

            for (int i = 0; i < matrix.GetCountRows; i++)
                for (int j = 0; j < matrix.GetCountColumns; j++)
                    arr[j, i] = matrix[i, j];

            return new Matrix(arr);
        }

        /// <summary>
        /// Метод нахождения обратной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="errorMessageNullDeterminant"> Сообщение об ошибке, если главный определитель окажется равен нулю. </param>
        /// <returns> Матрица - результат нахождения обратной матрицы. </returns>
        public static Matrix InverseOfAMatrix(this Matrix matrix, string errorMessageNullDeterminant = null)
        {
            var arr = new double[matrix.GetCountRows, matrix.GetCountColumns];
            double det = matrix.
                FindingTheDeterminant(true, 
                errorMessageNullDeterminant ?? "Найти обратную матрицу невозможно, так как определитель матрицы равен нулю");

            for (int i = 0; i < matrix.GetCountRows; i++)
                for (int j = 0; j < matrix.GetCountColumns; j++)
                {
                    var doub = matrix.FindAlgebraicComplement(i, j);
                    arr[i, j] = Double.IsNaN(doub) ? 0 : doub / det;
                }

            return new Matrix(arr).TransposeOfTheMatrix();
        }

        /// <summary>
        /// Находит алгебраическое дополнение.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="m"> Столбец, который нужно исключить. </param>
        /// <param name="n"> Строка, которую нужно исключить. </param>
        /// <returns> Алгебраическое дополнение. </returns>
        public static double FindAlgebraicComplement(this Matrix matrix, int m, int n)
        {
            if (matrix.GetCountColumns < 2)
                throw new ArgumentException("Алгебраическое дополнение невозможно найти у матрицы размером меньше, чем 2x2", nameof(matrix));

            var arr = new double[matrix.GetCountRows - 1, matrix.GetCountColumns - 1];
            int k = 0, l = 0;

            for (int i = 0; i < matrix.GetCountRows; i++)
            {
                for (int j = 0; j < matrix.GetCountColumns; j++)
                { 
                    if (i != m && j != n)
                    {
                        arr[k, l] = matrix[i, j];
                        l++;
                    }
                }
                l = 0;
                if (i != m)
                    k++;
            }

            return Math.Pow(-1, m + n) * new Matrix(arr).FindingTheDeterminant();
        }

        /// <summary>
        /// Метод умножения матрицы на вектор.
        /// </summary>
        /// <param name="matrix"> Матрица. </param>
        /// <param name="vector"> Вектор, на который нужно умножить матрицу. </param>
        /// <returns> Вектор - результат произведения. </returns>
        public static Vector MatrixMultiplicationByVector(this Matrix matrix, Vector vector)
        {
            var arr = new double[vector.Count];

            for (int el = 0; el < matrix.GetCountRows; el++)
            {
                double elementResult = 0;

                for (int i = 0; i < matrix.GetCountColumns; i++)
                    elementResult += matrix[el, i] * vector[i];

                arr[el] = elementResult;
            }

            return new Vector(arr);
        }
    }
}
