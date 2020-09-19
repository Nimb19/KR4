using System;

namespace MatrixLibrary.Controllers
{
    /// <summary>
    /// Класс ошибки, который должен использоваться, если определитель матрицы равен нулю.
    /// </summary>
    public class ZeroDeterminantException : Exception
    {
        /// <summary>
        /// Используется, когда определитель матрицы равен 0.
        /// </summary>
        /// <param name="exceptionMessage"> Сообщение об ошибке. </param>
        public ZeroDeterminantException(string exceptionMessage) : base(exceptionMessage) { /*ignore*/ }

        /// <summary>
        /// Используется, когда определитель матрицы равен 0.
        /// </summary>
        public ZeroDeterminantException() => new ZeroDeterminantException(string.Empty);
    }
}
