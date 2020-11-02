using System;
using System.Collections;
using System.Linq;
using System.Text;

using MatrixLibrary.Controllers;

namespace MatrixLibrary.Models
{
    [Serializable]

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

        public static bool operator ==(Vector one, Vector two) => VectorController.VectorComparison(one, two);
        public static bool operator !=(Vector one, Vector two) => !VectorController.VectorComparison(one, two);
        public static Vector operator *(int number, Vector two) => two.MultiplyingAVectorByANumber(number);
        public static Vector operator +(Vector one, Vector two) => one.VectorAddition(two);

        /// <summary>
        /// Преобразует информацию о классе в переменную строкового типа.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var text = string.Empty;
            text += "\r\n";
            
            for (int i = 0; i < this.Count; i++)
                text += $" | {new string(this[i].ToString().Take(7).ToArray())} |\r\n";

            return text;
        }

        public override bool Equals(object obj) => VectorController.VectorComparison(this, obj as Vector);
        public override int GetHashCode() => base.GetHashCode();
    }
}
