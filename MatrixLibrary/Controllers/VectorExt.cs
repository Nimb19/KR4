using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers
{
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
    }
}
