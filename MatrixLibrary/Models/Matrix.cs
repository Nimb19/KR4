﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MatrixLibrary.Models
{
    public class Matrix
    {
        public double[,] ArrayValues { get; set; }
        public int GetCountColumns { get { return ArrayValues.GetLength(0); } }
        public int GetCountRows { get { return ArrayValues.GetLength(1); } }

        /// <summary>
        /// Создаёт матрицу на основе указанного массива.
        /// </summary>
        /// <param name="a"> Значения матрицы в двумерном массиве. </param>
        public Matrix(double[,] a)
        {
            ArrayValues = a;
        }

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
        public Matrix(int m, int n)
        {
            ArrayValues = new double[m, n];
        }

        public int Count => ArrayValues.Length;
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
    }
}