using System;
using System.Linq;
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
            textBox.ScrollBars = ScrollBars.Vertical;
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
                SendMessageInTBox("Решение поставленной задачи:\r\n");
                
                var Ak = GetSideOfMatrix(_a, Side.k);
                SendMessageInTBox("Записываем матрицу Ak:" + Ak);
                
                var Ad = GetSideOfMatrix(_a, Side.d);
                SendMessageInTBox("Записываем матрицу Ad:" + Ad);

                var Bk = MatrixController.CreateIdentityMatrix(_a.GetCountRows);
                SendMessageInTBox("Создаём единичную матрицу Bk:" + Bk);

                var Bd = FindBd(Ad, Ak);
                if (Bd == null)
                {
                    this.Close();
                    return;
                }
                SendMessageInTBox("Находим по формуле матрицу Bd:" + Bd);

                var B = MatrixController.CreateHorizontalBlockMatrix(Bk, Bd);
                SendMessageInTBox("Соединяем части матриц Bk и Bd, найдя матрицу B:" + B);

                var BR = B * _r;
                SendMessageInTBox("Находим матрицу BR, перемножив матрицу B на матрицу R:" + BR);

                var C = MatrixController.CreateVerticalBlockMatrix(_a, BR);
                SendMessageInTBox("Создаём блочную матрицу C:" + C);

                var S = -1 * AddZeroElementsInVectorIfThisNeed(_q, C.GetCountRows);
                SendMessageInTBox("Создаём вектор S, если нужно, дополняя его нулями:" + S);

                var answers = MatrixController.CramerRuleMethod(C, S);
                SendMessageInTBox("Результаты решения СЛАУ методом Крамера:" + answers.ToString());

                var balanceEquation = FindBalanceEquationResults(_a, answers, _q);
                SendMessageInTBox("Уравнение баланса по ветвям:\r\n" + balanceEquation);

                textBox.Text = textBox.Text.Trim();
                textBox.Select(textBox.Text.Length, 0);
            }
            catch (ZeroDeterminantException exc)
            {
                MessageBox.Show(exc.Message, "Определить равен 0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
        }

        private string FindBalanceEquationResults(Matrix a, Vector p, Vector q)
        {
            var result = string.Empty;
            var answer = (a * p) + AddZeroElementsInVectorIfThisNeed(q, p.Count);
            //answer.ArrayValues = answer.ArrayValues.Select(c => c = Math.Round(c, 5)).ToArray();
            var sumElements = answer.GetSumOfElemets();

            var text = string.Empty;
            text += "\r\n";

            for (int i = 0; i < answer.Count; i++)
            {
                text += $" | {answer[i]} |";

                if (answer[i] > 0)
                    text += " - Избыточный продукт экспортируется из узла.";
                else if (answer[i] < 0)
                    text += " - Избыточный продукт импортируется из узла.";

                text += "\r\n";
            }

            result += $"AP + Q = {text}\r\n";

            if (sumElements < 0)
                result += $"Сумма элементов < 0 ({sumElements}). Избыточный продукт импортируется из узлов.";
            else if (sumElements > 0)
                result += $"Сумма элементов > 0 ({sumElements}). Избыточный продукт экспортируется из узлов.";
            else
                result += $"Сумма элементов = 0 ({sumElements}). Соответствие между потреблением и производством.";

            return result;
        }

        private void SendMessageInTBox(string message) => textBox.Text += message + "\r\n";

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
