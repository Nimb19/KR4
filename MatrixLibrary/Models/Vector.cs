using System;
using System.Collections;

namespace MatrixLibrary.Models
{
    /// <summary>
    /// Вектор.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Значения вектора в виде массива.
        /// </summary>
        public double[] ArrayValues { get; set; }

        /// <summary>
        /// Создание вектора на основе массива.
        /// </summary>
        /// <param name="arrayValues"> Массив значений вектора. </param>
        public Vector(double[] arrayValues) => ArrayValues = arrayValues;

        /// <summary>
        /// Создаёт нулевой вектор с указанным количеством элементов.
        /// </summary>
        /// <param name="countRows"> Количество элементов. </param>
        public static Vector CreateEmptyVector(int countRows) => new Vector(new double[countRows]);

        /// <summary>
        /// Количество всех элементов вектора.
        /// </summary>
        public int Count => ArrayValues.Length;

        /// <summary>
        /// Индексация вектора.
        /// </summary>
        /// <param name="index"> Индекс искомого элемента. </param>
        /// <returns> Значение по указанному индексу. </returns>
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
