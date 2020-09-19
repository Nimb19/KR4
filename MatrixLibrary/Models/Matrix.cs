﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using MatrixLibrary.Controllers;

namespace MatrixLibrary.Models
{
    /// <summary>
    /// Матрица.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Значения матрицы в виде массива.
        /// </summary>
        public double[,] ArrayValues { get; set; }

        public int GetCountColumns => ArrayValues.GetLength(0);
        public int GetCountRows => ArrayValues.GetLength(1);

        /// <summary>
        /// Создаёт матрицу на основе указанного массива.
        /// </summary>
        /// <param name="arrayValues"> Значения матрицы в двумерном массиве. </param>
        public Matrix(double[,] arrayValues) => ArrayValues = arrayValues;

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
        /// Создаёт пустую матрицу с указанной размерностью.
        /// </summary>
        /// <param name="m"> Количество строк. </param>
        /// <param name="n"> Количество столбцов. </param>
        public Matrix(int m, int n) => ArrayValues = new double[m, n];

        /// <summary>
        /// Количество всех элементов матрицы.
        /// </summary>
        public int Count => ArrayValues.Length;

        /// <summary>
        /// Индексация матрицы.
        /// </summary>
        /// <param name="m"> Строка искомого элемента. </param>
        /// <param name="n"> Столбец искомого элемента. </param>
        /// <returns> Значение по указанной строке и столбцу. </returns>
        public double this[int m, int n]
        {
            get
            {
                return ArrayValues[m, n];
            }
            set
            {
                ArrayValues[m, n] = value;
            }
        }

        public static Matrix operator +(Matrix one, Matrix two) => MatrixController.MatrixAddition(one, two);
        public static bool operator ==(Matrix one, Matrix two) => MatrixComparison(one, two);
        public static bool operator !=(Matrix one, Matrix two) => !MatrixComparison(one, two);

        /// <summary>
        /// Метод сравнения матриц.
        /// </summary>
        /// <param name="matrixExpected"></param>
        /// <param name="matrixActual"></param>
        /// <returns></returns>
        public static bool MatrixComparison(Matrix matrixExpected, Matrix matrixActual)
        {
            for (int i = 0; i < matrixExpected.GetCountRows; i++)
                for (int j = 0; j < matrixExpected.GetCountColumns; j++)
                    if (matrixExpected[i, j] - matrixActual[i, j] > 0.01)
                        return false;
            return true;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int m = 0; m < GetCountRows; m++)
            {
                str.Append("| ");

                for (int n = 0; n < GetCountColumns; n++)
                    str.Append(this[m, n] + " ");

                if (m != GetCountColumns - 1)
                    str.Append("|\n");
                else
                    str.Append("|");
            }

            return str.ToString();
        }

        public override bool Equals(object obj) => MatrixComparison(this, obj as Matrix);
        public override int GetHashCode() => base.GetHashCode();
    }
}
