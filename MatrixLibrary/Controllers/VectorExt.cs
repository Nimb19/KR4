using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers
{
    /// <summary>
    /// Статический класс, предназначенный только для методов расширений векторов.
    /// </summary>
    public static class VectorExt
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
    }
}
