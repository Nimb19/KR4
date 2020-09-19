using System;
using System.Linq;
using MatrixLibrary.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLibrary.Controllers.Tests
{
    [TestClass]
    public class MatrixControllerTests
    {
        private static Matrix[] matrices;
        private static Vector[] vectors;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            matrices = new Matrix[3]
            {
                new Matrix(new double[2, 2] { { 4, 6 }, { -2, 2 } }),
                new Matrix(new double[3, 3] { { 3, 5, 1 }, { 2, 5, -7 }, { 6, 4, -2 } }),
                new Matrix(new double[4, 4] { { 3, 5, 1, -15 }, { 2, 5, -7, -1 }, { 6, 4, -2, 14 }, { 1, 3, -2, 25 } })
            };

            vectors = new Vector[3]
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

            for (int i = 0; i < matrices.Length; i++)
                Assert.AreEqual(results[i], matrices[i].FindingTheDeterminant());
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

            Vector[] vectorsActual = new Vector[matrices.Length];
            for (int i = 0; i < matrices.Length; i++)
                vectorsActual[i] = matrices[i].MatrixMultiplicationByVector(vectors[i]);

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

            MatriciesComparison(matricesExpected, matrices.Select(x => x.InverseOfAMatrix()).ToArray(), "Несоответствие при проверке результата нахождения обратной матрицы.");
        }

        [TestMethod()]
        public void MatrixMultiplicationByNumberTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void TransposeOfTheMatrixTest()
        {
            throw new NotImplementedException();
        }


        [TestMethod()]
        public void FindAlgebraicComplementTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void MatrixMultiplicationTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void MatrixAdditionTest()
        {
            throw new NotImplementedException();
        }

        private void MatriciesComparison(Matrix[] matricesExpected, Matrix[] matricesActual, string exceptionMessage)
        {
            for (int k = 0; k < matricesExpected.Length; k++)
                        Assert.IsTrue(matricesExpected[k] == matricesActual[k], exceptionMessage);
        }

        private void VectorsComparison(Vector[] vectorsExpected, Vector[] vectorsActual, string exceptionMessage)
        {
            for (int k = 0; k < vectorsExpected.Length; k++)
                for (int i = 0; i < vectorsExpected[k].Count; i++)
                    Assert.AreEqual(vectorsExpected[k][i], vectorsActual[k][i], 0.01, exceptionMessage);
        }
    }
}