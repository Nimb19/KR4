using System;
using System.Collections;
using System.Text;

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
        public Vector(double[] arrayValues) => ArrayValues = arrayValues.Clone() as double[];

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

        public static bool operator ==(Vector one, Vector two) => VectorComparison(one, two);
        public static bool operator !=(Vector one, Vector two) => !VectorComparison(one, two);

        /// <summary>
        /// Метод сравнения векторов.
        /// </summary>
        /// <param name="one"> Первый вектор. </param>
        /// <param name="two"> Второй вектор. </param>
        /// <returns> true - если значения векторов равны. </returns>
        public static bool VectorComparison(Vector one, Vector two)
        {
            for (int i = 0; i < one.Count; i++)
                if (Math.Abs(one[i] - two[i]) > 0.01)
                    return false;
            return true;
        }

        /// <summary>
        /// Преобразует информацию о классе в переменную строкового типа.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj) => VectorComparison(this, obj as Vector);
        public override int GetHashCode() => base.GetHashCode();
    }
}
