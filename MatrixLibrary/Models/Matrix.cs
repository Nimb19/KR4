using System;
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
