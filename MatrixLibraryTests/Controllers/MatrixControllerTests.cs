using MatrixLibrary.Controllers;
using System;
using System.Linq;
using MatrixLibrary.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLibrary.Controllers.Tests
{
    [TestClass]
    public class MatrixControllerTests
    {
        private static Matrix[] matricesForTests;
        private static Vector[] vectorsForTests;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            matricesForTests = new Matrix[3]
            {
                new Matrix(new double[2, 2] { { 4, 6 }, { -2, 2 } }),
                new Matrix(new double[3, 3] { { 3, 5, 1 }, { 2, 5, -7 }, { 6, 4, -2 } }),
                new Matrix(new double[4, 4] { { 3, 5, 1, -15 }, { 2, 5, -7, -1 }, { 6, 4, -2, 14 }, { 1, 3, -2, 25 } })
            };

            vectorsForTests = new Vector[3]
            {
                new Vector(new double[2] { 3, 1 }),
                new Vector(new double[3] { 66, 2, -11 }),
                new Vector(new double[4] { 5, 4, -2, 13})
            };
        }

        [TestMethod]
        public void FindingTheDeterminantTest()
        {
            double[] results = new double[3] { 20, -158, -5054 };

            for (int i = 0; i < matricesForTests.Length; i++)
                Assert.AreEqual(results[i], matricesForTests[i].FindingTheDeterminant());
        }

        [TestMethod]
        public void MatrixMultiplicationByVectorTest()
        {
            Vector[] vectorsExpected = new Vector[3]
            {
                new Vector(new double[2] { 18, -4 }),
                new Vector(new double[3] { 197, 219, 426 }),
                new Vector(new double[4] { -162, 31, 232, 346})
            };

            Vector[] vectorsActual = new Vector[matricesForTests.Length];
            for (int i = 0; i < matricesForTests.Length; i++)
                vectorsActual[i] = matricesForTests[i].MatrixMultiplicationByVector(vectorsForTests[i]);

            VectorsComparison(vectorsExpected, vectorsActual, "Несоответствие при проверке результата умножения матрицы на вектор.");
        }

        [TestMethod]
        public void InverseOfAMatrixTest()
        {
            Matrix[] matricesExpected = new Matrix[3]
            {
                new Matrix(new double[2, 2] { { 0.1, -0.3 }, { 0.1, 0.2 } }),
                new Matrix(new double[3, 3] { { -0.114, -0.0886, 0.253 }, { 0.241, 0.0759, -0.146 }, { 0.139, -0.114, -0.0316 } }),
                new Matrix(new double[4, 4] { { -0.059, -0.0273, 0.233, -0.167 }, { 0.182, 0.0103, -0.124, 0.179 }, { 0.114, -0.142, -0.0226, 0.0756 }, { -0.0103, -0.0115, -0.00376, 0.0313 } })
            };

            MatriciesComparison(matricesExpected, matricesForTests.Select(x => x.InverseOfAMatrix()).ToArray(), "Несоответствие при проверке результата нахождения обратной матрицы.");
        }

        [TestMethod]
        public void CreateDiagonalMatrixTest()
        {
            var matriciesExpected = new Matrix[3]
            {
               new Matrix(new double[2, 2] {{ 3, 0 }, { 0, 4} }),
               new Matrix(new double[3, 3] {{ -2, 0, 0 }, { 0, 6, 0}, { 0, 0, 111} }),
               new Matrix(new double[5, 5] {{ 113, 0, 0, 0, 0 }, { 0, 21, 0, 0, 0 }, { 0, 0, 51, 0, 0 }, { 0, 0, 0, -331, 0 }, { 0, 0, 0, 0, 35 } })
            };

            var matriciesActual = new Matrix[3]
            {
                MatrixController.CreateDiagonalMatrix(3, 4),
                MatrixController.CreateDiagonalMatrix(-2, 6, 111),
                MatrixController.CreateDiagonalMatrix(113, 21, 51, -331, 35)
            };

            MatriciesComparison(matriciesExpected, matriciesActual,
                "Несоответствие при проверке результата создания диагональной матрицы.");
        }

        [TestMethod]
        public void CreateIdentityMatrixTest()
        {
            var matriciesExpected = new Matrix[3] 
            {
               new Matrix(new double[2, 2] {{ 1, 0 }, { 0, 1} }),
               new Matrix(new double[3, 3] {{ 1, 0, 0 }, { 0, 1, 0}, { 0, 0, 1} }),
               new Matrix(new double[5, 5] {{ 1, 0, 0, 0, 0 }, { 0, 1, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 1 } })
            };

            var matriciesActual = new Matrix[3]
            {
                MatrixController.CreateIdentityMatrix(2),
                MatrixController.CreateIdentityMatrix(3),
                MatrixController.CreateIdentityMatrix(5)
            };

            MatriciesComparison(matriciesExpected, matriciesActual,
                "Несоответствие при проверке результата создания единичной матрицы.");
        }

        [TestMethod]
        public void CramerRuleMethodTest()
        {
            var vectorsExpected = new Vector[3]
            {
                new Vector(new double[2] { 0, 0.5 }),
                new Vector(new double[3] { -10.481, 17.6266, 9.31013 }),
                new Vector(new double[4] { -3.04116, 3.52275, 1.03285, 0.301543})
            };

            Vector[] vectorsActual = new Vector[matricesForTests.Length];
            for (int i = 0; i < matricesForTests.Length; i++)
                vectorsActual[i] = MatrixController.CramerRuleMethod(matricesForTests[i], vectorsForTests[i]);

            VectorsComparison(vectorsExpected, vectorsActual, "Несоответствие при проверке результата вычисления СЛАУ.");
        }

        /// <summary>
        /// Метод сравнения ожидаемых и актуальных матриц.
        /// </summary>
        /// <param name="matricesExpected"> Массив ожидаемых матриц. </param>
        /// <param name="matricesActual"> Массив актуальных матриц. </param>
        /// <param name="exceptionMessage"> Сообщение об ошибке. </param>
        public static void MatriciesComparison(Matrix[] matricesExpected, Matrix[] matricesActual, string exceptionMessage)
        {
            for (int k = 0; k < matricesExpected.Length; k++)
                Assert.IsTrue(matricesExpected[k] == matricesActual[k], exceptionMessage);
        }

        /// <summary>
        /// Метод сравнения ожидаемых и актуальных векторов.
        /// </summary>
        /// <param name="vectorsExpected"> Массив ожидаемых векторов. </param>
        /// <param name="vectorsActual"> Массив актуальных векторов. </param>
        /// <param name="exceptionMessage"> Сообщение об ошибке. </param>
        public static void VectorsComparison(Vector[] vectorsExpected, Vector[] vectorsActual, string exceptionMessage)
        {
            for (int k = 0; k < vectorsExpected.Length; k++)
                Assert.IsTrue(vectorsExpected[k] == vectorsActual[k], exceptionMessage);
        }
    }
}