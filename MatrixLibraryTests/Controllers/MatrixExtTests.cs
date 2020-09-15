using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary.Models;

namespace MatrixLibrary.Controllers.Tests
{
    [TestClass]
    public class MatrixExtTests
    {
        private static Matrix[] matrices;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            matrices = new Matrix[3]
            {
                new Matrix(new double[2, 2] { { 4, 6 }, { -2, 2 } }),
                new Matrix(new double[3, 3] { { 3, 5, 1 }, { 2, 5, -7 }, { 6, 4, -2 } }),
                new Matrix(new double[4, 4] { { 3, 5, 1, -15 }, { 2, 5, -7, -1 }, { 6, 4, -2, 14 }, { 1, 3, -2, 25 } })
            };
        }

        [TestMethod]
        public void MatrixMultiplicationByNumberTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void FindingTheDeterminantTest()
        {
            double[] results = new double[3] { 20, -158, -5054 };

            for (int i = 0; i < matrices.Length; i++)
                Assert.AreEqual(results[i], matrices[i].FindingTheDeterminant());
        }

        [TestMethod]
        public void TransposeOfTheMatrixTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void MatrixMultiplicationByVectorTest()
        {
            Assert.Fail();
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

            MatrixComparison(matricesExpected, matrices.Select(x => x.InverseOfAMatrix()).ToArray(), "Несоответствие при проверке результата нахождения обратной матрицы.");
        }

        private void MatrixComparison(Matrix[] matricesExpected, Matrix[] matricesActual, string exceptionMessage)
        {
            for (int k = 0; k < matricesExpected.Length; k++)
                for (int i = 0; i < matricesExpected[k].GetCountRows; i++)
                    for (int j = 0; j < matricesExpected[k].GetCountColumns; j++)
                        Assert.AreEqual(matricesExpected[k][i, j], matricesActual[k][i, j], 0.01, exceptionMessage);
        }
    }
}