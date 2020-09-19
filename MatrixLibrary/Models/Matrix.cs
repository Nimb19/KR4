using System;
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
        public Matrix(double[,] arrayValues) => ArrayValues = arrayValues.Clone() as double[,];

        /// <summary>
        /// Создаёт копию указанной матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица образец. </param>
        public Matrix(Matrix matrix) => ArrayValues = matrix.ArrayValues.Clone() as double[,];

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
        /// <param name="one"> Первая матрица. </param>
        /// <param name="two"> Вторая матрица. </param>
        /// <returns> true - если значения матриц равны. </returns>
        public static bool MatrixComparison(Matrix one, Matrix two)
        {
            for (int i = 0; i < one.GetCountRows; i++)
                for (int j = 0; j < one.GetCountColumns; j++)
                    if (Math.Abs(one[i, j] - two[i, j]) > 0.01)
                        return false;
            return true;
        }

        /// <summary>
        /// Преобразует информацию о классе в переменную строкового типа.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append(" /");
            for (int m = 0; m < GetCountRows; m++)
            {
                if (m != 0)
                    str.Append("| ");

                for (int n = 0; n < GetCountColumns; n++)
                {
                    str.Append(this[m, n]);
                    if (m != 0 && m != GetCountRows && n == GetCountColumns)
                        str.Append(" ");
                }

                if (m == 0)
                    str.Append("\\\n");
                else if (m != GetCountColumns - 1)
                    str.Append("|\n");
            }
            str.Append(@"/");

            return str.ToString();
        }

        public override bool Equals(object obj) => MatrixComparison(this, obj as Matrix);
        public override int GetHashCode() => base.GetHashCode();
    }
}
