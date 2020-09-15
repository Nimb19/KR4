//using System;
//using System.Collections.Generic;
//using MatrixLibrary.Models;

//namespace MatrixLibrary.Controllers
//{
//    public static partial class MatrixController
//    {
//        /// <summary>
//        /// Решает СЛАУ методом Зейделя.
//        /// </summary>
//        /// <param name="matrix"> Матрица. </param>
//        /// <param name="vector"> Вектор результатов. </param>
//        /// <param name="eps"></param>
//        /// <returns></returns>
//        public static double[] MethodSeidel(Matrix matrix, Vector vector, double eps = 0.00001)
//        {
//            double[,] A = OddsSorting(matrix, vector);
//            double x1 = 0, x2 = 0, x3 = 0, x4 = 0;  // Будут указывать значения на текущую итерацию.
//            double Old_X1, Old_X2, Old_X3, Old_X4; // Будут указывать значения по прошлой итерации.
//            double Delta; // Указывает разность между X и Old_X. Пока разность < 0,00001 - итерации будут идти.
//            int iteration = 0; // Если итераций было больше 100 - то 100% чисел там уже нет, т.к. они выйдут за границу типа double
//            do
//            { // Здесь начинается расчёт по методу Зейделя.
//                iteration++;
//                Old_X1 = x1; Old_X2 = x2; Old_X3 = x3; Old_X4 = x4;

//                x1 = (A[0, 4] - (A[0, 1] * Old_X2) - (A[0, 2] * Old_X3) - (A[0, 3] * Old_X4)) / A[0, 0];
//                x2 = (A[1, 4] - (A[1, 0] * x1) - (A[1, 2] * Old_X3) - (A[1, 3] * Old_X4)) / A[1, 1];
//                x3 = (A[2, 4] - (A[2, 0] * x1) - (A[2, 1] * x2) - (A[2, 3] * Old_X4)) / A[2, 2];
//                x4 = (A[3, 4] - (A[3, 0] * x1) - (A[3, 1] * x2) - (A[3, 2] * x3)) / A[3, 3];

//                double[,] DeltaArray = new double[2, 4] { { x1, x2, x3, x4 },
//                                                        { Old_X1, Old_X2, Old_X3, Old_X4 } };
//                Delta = Math.Abs(x1) - Math.Abs(Old_X1);
//                for (int Xn = 1; Xn < 4; Xn++) // Здесь мы начинаем проверять какая дельта окажется больше - самую большую выводим на сравнение с eps
//                    if (Math.Abs(Delta) < Math.Abs(DeltaArray[0, Xn]) - Math.Abs(DeltaArray[1, Xn]))
//                        Delta = Math.Abs(DeltaArray[0, Xn]) - Math.Abs(DeltaArray[1, Xn]);

//            } while (Math.Abs(Delta) > eps || iteration < 100); // Если дельта больше eps и кол-во итераций < 100, то продолжаем крутить

//            double[] X1234 = new double[4] { x1, x2, x3, x4 }; // Инициализируем массив ответов

//            for (int n = 0; n < 4; n++) // Если число очень близко к целому - округляем
//                if (Math.Abs(Math.Round(X1234[n])) - Math.Abs(X1234[n]) <= eps * 10)
//                    X1234[n] = Math.Round(X1234[n]);

//            if (iteration == 100)
//                throw new ArithmeticException("Дельта была больше указанной после 100 итераций.");

//            return X1234;
//        }

//        /// <summary>
//        /// Сортировка матрицы для вычисления с помощью метода Зейделя.
//        /// </summary>
//        /// <param name="a"> Матрица A. </param>
//        /// <param name="b"> Матрица B. </param>
//        /// <returns> Отсортированная матрица. </returns>
//        private static double[,] OddsSorting(Matrix a, Vector b) // Сортируем матрицу
//        {
//            double[,] Matrix = new double[4, 5];   // Переводим в матрицу 4x5
//            for (int i = 0; i < 4; i++)
//                for (int j = 0; j < 4; j++)
//                    Matrix[i, j] = a[i, j];
//            for (int i = 0; i < 4; i++)
//                Matrix[i, 4] = b[i];

//            List<int> OrderRows = new List<int>(); // Переставляем строки исходной матрицы таким образом, 
//            for (int j = 0; j < 4; j++)           // чтобы на диагонали стояли наибольшие по модулю коэффициенты матрицы.
//            {
//                double maxAbs = 0;
//                int maxAbsRow = -1;
//                for (int i = 0; i < 4; i++)
//                    if (Math.Abs(maxAbs) < Math.Abs(Matrix[i, j]) && !OrderRows.Contains(i))
//                    {
//                        maxAbs = Matrix[i, j];
//                        maxAbsRow = i;
//                    }
//                OrderRows.Add(maxAbsRow);
//            }
//            double[,] newMatrix = (double[,])Matrix.Clone();
//            for (int i = 0; i < 4; i++)
//                for (int j = 0; j < 5; j++)
//                    newMatrix[i, j] = Matrix[OrderRows[i], j];

//            return newMatrix;
//        }
//    }
//}