using System;
using System.Windows.Forms;
using MatrixLibrary.Controllers;
using MatrixLibrary.Models;

namespace Interface
{
    public partial class SolutionForm : Form
    {
        private Matrix _matrixIncident;
        private Matrix _a;
        private Matrix _r;
        private Vector _q;

        public SolutionForm(Matrix matrixIncident, Matrix r, Vector q)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            startTimer.Start();

            _matrixIncident = matrixIncident;
            MatrixIncidentToMatrixA();
            _r = r;
            _q = q;

            SolveTheEquationOfStateMethodAndPrintResults();
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            Opacity += 0.17;
            if (Opacity == 1)
                startTimer.Stop();
        }

        private void SolveTheEquationOfStateMethodAndPrintResults()
        {
            try
            {
                var Ak = GetSideOfMatrix(_a, Side.k);
                var Ad = GetSideOfMatrix(_a, Side.d);
                var Bk = MatrixController.CreateIdentityMatrix(_a.GetCountRows);
                var Bd = FindBd(Ad, Ak);
                if (Bd == null)
                {
                    this.Close();
                    return;
                }

                var B = MatrixController.CreateHorizontalBlockMatrix(Bk, Bd);

                var BR = B * _r;
                var C = MatrixController.CreateVerticalBlockMatrix(_a, BR);
                var S = -1 * AddZeroElementsInVectorIfThisNeed(_q, C.GetCountRows);

                var answers = MatrixController.CramerRuleMethod(C, S);

                textBox.Text += "Результаты решения СЛАУ:\r\n";
                textBox.Text += answers.ToString();

                textBox.Select(textBox.Text.Length, 0);
            } catch (ZeroDeterminantException exc)
            {
                MessageBox.Show(exc.Message, "Определить равен 0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
        }

        private Matrix FindBd(Matrix Ad, Matrix Ak)
        {
            try
            {
                return (-1 * (Ad.
                    InverseOfAMatrix("При нахождении Bk определитель матрицы был равен нулю. " +
                    "\nНайти обратную матрицу невозможно.") * Ak)).TransposeOfTheMatrix();
            }
            catch (ZeroDeterminantException ex)
            {
                MessageBox.Show(ex.Message, "Определитель равен нулю.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private Vector AddZeroElementsInVectorIfThisNeed(Vector vector, int neededCount) =>
            new Vector(vector.ArrayValues.Clone() as double[]).AddElement(new double[neededCount - vector.Count]);

        private Matrix GetSideOfMatrix(Matrix matrix, Side side)
        {
            var arr = new double[matrix.GetCountRows, matrix.GetCountColumns - matrix.GetCountRows];
            int startColumn, endColumn;

            if (side == Side.k)
            {
                startColumn = 0;
                endColumn = matrix.GetCountRows;
            }
            else
            {
                startColumn = matrix.GetCountRows;
                endColumn = matrix.GetCountColumns;
            }

            int i = 0;
            for (int iRow = 0; iRow < matrix.GetCountRows; iRow++)
            {
                int j = 0;
                for (int iCol = startColumn; iCol < endColumn; iCol++)
                {
                    arr[i, j] = matrix[iRow, iCol];
                    j++;
                }
                i++;
            }

            return new Matrix(arr);
        }

        private void MatrixIncidentToMatrixA()
        {
            var arr = new double[_matrixIncident.GetCountRows - 1, _matrixIncident.GetCountColumns];
            var i1 = 0;
            for (int i = 1; i < _matrixIncident.GetCountRows; i++)
            {
                var j1 = 0;
                for (int j = 0; j < _matrixIncident.GetCountColumns; j++)
                {
                    arr[i1, j1] = _matrixIncident[i, j];
                    j1++;
                }
                i1++;
            }

            _a = new Matrix(arr);
        }

        /// <summary>
        /// Выбрать взять k - контурную левую часть матрицы или d.
        /// </summary>
        enum Side
        {
            k = 0,
            d = 1
        }
    }
}
