using System;

using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers
{
    /// <summary>
    /// Класс методов действий над векторами.
    /// </summary>
    public static partial class VectorController
    {
        /// <summary>
        /// Добавляет указанные элементы в конец вектора.
        /// </summary>
        /// <param name="vector"> Вектор, к которому нужно добавить элементы. </param>
        /// <param name="elements"> Добавляемые элементы. </param>
        /// <returns> Вектор-результат добавления. </returns>
        public static Vector AddElement(this Vector vector, params double[] elements)
        {
            double[] arr = new double[vector.Count + elements.Length];
            
            for (int i = 0; i < vector.Count; i++)
                arr[i] = vector[i];

            for (int i = vector.Count; i < elements.Length; i++)
                arr[i] = elements[i];

            return new Vector(arr);
        }

        /// <summary>
        /// Метод взятия суммы всех элементов вектора.
        /// </summary>
        /// <param name="vector"> Вектор. </param>
        /// <returns> Сумма элементов вектора. </returns>
        public static double GetSumOfElemets(this Vector vector)
        {
            double result = 0;

            for (int i = 0; i < vector.Count; i++)
                result += vector[i];

            return result;
        }

        /// <summary>
        /// Метод сложения векторов.
        /// </summary>
        /// <param name="one"> Первый вектор. </param>
        /// <param name="two"> Второй вектор. </param>
        /// <returns> Вектор - результат сложения. </returns>
        public static Vector VectorAddition(this Vector one, Vector two)
        {
            var arr = new double[one.Count];

            for (int i = 0; i < one.Count; i++)
                arr[i] = one[i] + two[i];

            return new Vector(arr);
        }

        /// <summary>
        /// Метод сложения векторов.
        /// </summary>
        /// <param name="vector"> Первый вектор. </param>
        /// <param name="two"> Второй вектор. </param>
        /// <returns> Вектор - результат сложения. </returns>
        public static Vector MultiplyingAVectorByANumber(this Vector vector, int number)
        {
            var arr = new double[vector.Count];

            for (int i = 0; i < vector.Count; i++)
                arr[i] = vector[i] * number;

            return new Vector(arr);
        }

        /// <summary>
        /// Метод сравнения векторов.
        /// </summary>
        /// <param name="one"> Первый вектор. </param>
        /// <param name="two"> Второй вектор. </param>
        /// <returns> true - если значения векторов равны. </returns>
        public static bool VectorComparison(Vector one, Vector two)
        {
            if (one as object == null && two as object == null)
                return true;
            if (one as object == null || two as object == null)
                return false;

            for (int i = 0; i < one.Count; i++)
                if (Math.Abs(one[i] - two[i]) > 0.01)
                    return false;
            return true;
        }
    }
}
