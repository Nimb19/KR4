using System;
using System.Collections;

namespace MatrixLibrary.Models
{
    /// <summary>
    /// Вектор.
    /// </summary>
    public class Vector
    {
        public double[] ArrayValues { get; set; }

        /// <summary>
        /// Создание вектора на основе массива.
        /// </summary>
        /// <param name="arrayValues"> Массив значений вектора. </param>
        public Vector(double[] arrayValues)
        {
            ArrayValues = arrayValues;
        }

        /// <summary>
        /// Создаёт нулевой вектор с указанным количеством элементов.
        /// </summary>
        /// <param name="countRows"> Количество элементов. </param>
        public Vector(int countRows)
        {
            ArrayValues = new double[countRows];
        }

        public int Count => ArrayValues.Length;
        public double this[int index]
        {
            get
            {
                return ArrayValues[index];
            }
            set
            {
                ArrayValues[index] = value;
            }
        }
    }
}
