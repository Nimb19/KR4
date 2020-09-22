using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MatrixLibrary.Models;
using Newtonsoft.Json;

namespace Interface
{
    public partial class SettingsForm : Form
    {
        private string _filename { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            InitDGVs();
        }

        private void InitDGVs()
        {
            dgvA.Rows.Clear();
            dgvR.Rows.Clear();
            dgvQ.Rows.Clear();

            dgvA.Columns.Clear();
            dgvR.Columns.Clear();
            dgvQ.Columns.Clear();

            SetSettingsInDGV();
            SetCountRowsAndColumnsInDGVA(Convert.ToInt32(numericRowsA.Value), Convert.ToInt32(numericColsA.Value));

            AddColumnsQ();
            SetCountRowsAndColumnsInDGVQ(Convert.ToInt32(numericRowsA.Value) - 1);

            AddColumnsR();
            SetCountRowsAndColumnsInDGVR(Convert.ToInt32(numericColsA.Value));
        }

        private void AddRowsQ(int count)
        {
            for (int i = 0; i < count; i++)
            {
                dgvQ.Rows.Add();
                dgvQ.Rows[dgvQ.RowCount - 1].HeaderCell.Value = "Узел №" + (dgvQ.RowCount);
            }
        }

        private void AddColumnsQ()
        {
            var newcol = new DataGridViewColumn();
            newcol.CellTemplate = new DataGridViewTextBoxCell();
            newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            newcol.Resizable = DataGridViewTriState.True;
            newcol.HeaderCell.Value = "Объем потоков";

            dgvQ.Columns.Add(newcol);
        }

        private void AddColumnsR()
        {
            var newcol = new DataGridViewColumn();
            newcol.CellTemplate = new DataGridViewTextBoxCell();
            newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            newcol.Resizable = DataGridViewTriState.True;
            newcol.HeaderCell.Value = "Стоимость";

            dgvR.Columns.Add(newcol);
        }

        private void AddRowsR(int count)
        {
            for (int i = 0; i < count; i++)
            {
                dgvR.Rows.Add();
                dgvR.Rows[dgvR.RowCount - 1].HeaderCell.Value = "Ветвь №" + dgvR.RowCount;
            }
        }

        private void SetSettingsInDGV()
        {
            var collectionDGV = new DataGridView[3] { dgvA, dgvR, dgvQ };

            foreach (var dataGridView in collectionDGV) 
            {
                var templateRow = new DataGridViewRow();
                templateRow.Height = 36;
                dataGridView.RowTemplate = templateRow;

                dataGridView.Font = new Font(new FontFamily(GenericFontFamilies.SansSerif), 12);
                dataGridView.AllowUserToResizeColumns = true;
                dataGridView.AllowUserToResizeRows = true;
                dataGridView.RowHeadersWidth = 120;
                dataGridView.ColumnHeadersHeight = 36;
                dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            }
        }

        private void AddColumnsA(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newcol = new DataGridViewColumn();
                newcol.CellTemplate = new DataGridViewTextBoxCell();
                newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                newcol.Resizable = DataGridViewTriState.True;
                newcol.HeaderCell.Value = "Ветвь №" + (dgvA.ColumnCount + 1);

                dgvA.Columns.Add(newcol);
            }
        }

        private void AddRowsA(int count)
        {
            for (int i = 0; i < count; i++)
            {
                dgvA.Rows.Add();
                dgvA.Rows[dgvA.RowCount - 1].HeaderCell.Value = "Узел №" + (dgvA.RowCount - 1);
            }
        }

        private void ApplicationCloseToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".json";
            saveFile.Filter = "ParametersFiles |*.json";
            saveFile.InitialDirectory = Directory.GetCurrentDirectory();

            if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
            {
                _filename = saveFile.FileName;
                SaveDGVsParametersAsJson(_filename);
            }
        }

        private void SaveDGVsParametersAsJson(string filepath)
        {
            File.WriteAllText(filepath,
                JsonConvert.SerializeObject(
                    new DGVsParameters(
                        GetMatrixValuesInDGV(dgvA),
                        GetDiagonalMatrixValuesInDGV(dgvR),
                        GetVectorValuesInDGV(dgvQ))));
        }

        private double[,] GetMatrixValuesInDGV(DataGridView dgv)
        {
            var arr = new double[dgv.Rows.Count, dgv.Columns.Count];
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = double.TryParse(dgv[j, i].Value as string, out double ans) == true ? ans : 0;

            return arr;
        }

        private double[,] GetDiagonalMatrixValuesInDGV(DataGridView dgv)
        {
            var arr = new double[dgv.Rows.Count, dgv.Rows.Count];
            for (int i = 0; i < arr.GetLength(0); i++)
                arr[i, i] = double.TryParse(dgv[0, i].Value as string, out double ans) == true ? ans : 0;

            return arr;
        }

        private double[] GetVectorValuesInDGV(DataGridView dgv)
        {
            var vectorArr = new double[dgv.Rows.Count];
            for (int i = 0; i < vectorArr.Length; i++)
                vectorArr[i] = double.TryParse(dgv[0, i].Value as string, out double ans) == true ? ans : 0;

            return vectorArr;
        }

        private void SaveResultsF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_filename == null)
                SaveAsToolStripMenuItem_Click(null, null);
            else
                SaveDGVsParametersAsJson(_filename);
        }

        private void CloseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _filename = null;
            InitDGVs();
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = ".json";
            openFile.Filter = "ParametersFiles |*.json";
            openFile.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFile.ShowDialog() == DialogResult.OK && openFile.FileName.Length > 0)
            {
                InitDGVs();
                _filename = openFile.FileName;
                var fileParams = OpenDGVsParametersAsJson(_filename);

                numericRowsA.Value = fileParams.A.GetLength(0);
                numericColsA.Value = fileParams.A.GetLength(1);
                
                SetCountRowsAndColumnsInDGVA(fileParams.A.GetLength(0), fileParams.A.GetLength(1), new Matrix(fileParams.A));
                SetCountRowsAndColumnsInDGVR(fileParams.R.GetLength(0), new Matrix(fileParams.R));
                SetCountRowsAndColumnsInDGVQ(fileParams.Q.Length, new Vector(fileParams.Q));
            }
        }

        private void SetCountRowsAndColumnsInDGVA(int countRows, int countColumns, Matrix a = null)
        {
            while(dgvA.Columns.Count != countColumns)
            {
                if (dgvA.Columns.Count > countColumns)
                    dgvA.Columns.RemoveAt(dgvA.Columns.Count - 1);
                else
                    AddColumnsA(1);
            }

            while (dgvA.RowCount != countRows)
            {
                if (dgvA.RowCount > countRows)
                    dgvA.Rows.RemoveAt(dgvA.Rows.Count - 1);
                else
                    AddRowsA(1);
            }

            if (a != null)
                for (int i = 0; i < dgvA.RowCount; i++)
                    for (int j = 0; j < dgvA.ColumnCount; j++)
                       dgvA[j, i] = new DataGridViewTextBoxCell() { Value = a[i, j].ToString() };
        }

        private void SetCountRowsAndColumnsInDGVR(int countRows, Matrix r = null)
        {
            while (dgvR.Columns.Count != 1)
            {
                if (dgvR.Columns.Count > 1)
                    dgvR.Columns.RemoveAt(dgvR.Columns.Count - 1);
                else
                    AddColumnsR();
            }

            while (dgvR.RowCount != countRows)
            {
                if (dgvR.RowCount > countRows)
                    dgvR.Rows.RemoveAt(dgvR.Rows.Count - 1);
                else
                    AddRowsR(1);
            }

            if (r != null)
                for (int i = 0; i < dgvR.RowCount; i++)
                    dgvR[0, i] = new DataGridViewTextBoxCell() { Value = r[i, i].ToString() };
        }

        private void SetCountRowsAndColumnsInDGVQ(int countRows, Vector q = null)
        {
            while (dgvQ.Columns.Count != 1)
            {
                if (dgvQ.Columns.Count > 1)
                    dgvQ.Columns.RemoveAt(dgvQ.Columns.Count - 1);
                else
                    AddColumnsR();
            }

            while (dgvQ.RowCount != countRows)
            {
                if (dgvQ.RowCount > countRows)
                    dgvQ.Rows.RemoveAt(dgvQ.Rows.Count - 1);
                else
                    AddRowsQ(1);
            }

            if (q != null)
                for (int i = 0; i < dgvQ.RowCount; i++)
                    dgvQ[0, i] = new DataGridViewTextBoxCell() { Value = q[i].ToString() };
        }

        private DGVsParameters OpenDGVsParametersAsJson(string filepath) => 
            JsonConvert.DeserializeObject<DGVsParameters>(File.ReadAllText(filepath));

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.X)
            {
                ApplicationCloseToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                OpenFileToolStripMenuItem_Click(null, null);
            }
            else if ((e.KeyCode == Keys.F2) || (e.Control && e.KeyCode == Keys.S))
            {
                SaveResultsF2ToolStripMenuItem_Click(null, null);
            }
        }

        private void NumericRowsA_ValueChanged(object sender, EventArgs e)
        {
            SetCountRowsAndColumnsInDGVA(Convert.ToInt32(numericRowsA.Value), dgvA.ColumnCount);
            SetCountRowsAndColumnsInDGVQ(Convert.ToInt32(numericRowsA.Value) - 1);
        }

        private void NumericColsA_ValueChanged(object sender, EventArgs e)
        {
            SetCountRowsAndColumnsInDGVA(dgvA.RowCount, Convert.ToInt32(numericColsA.Value));
            SetCountRowsAndColumnsInDGVR(Convert.ToInt32(numericColsA.Value));
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool throwDialogWindow = false;

            if (IsDGVsFillZero())
                throwDialogWindow = false;
            else if (_filename == null)
                throwDialogWindow = true;
            else
            {
                var jsonParams = OpenDGVsParametersAsJson(_filename);
                if (!IsMatriciesValuesEqual(jsonParams.A, GetMatrixValuesInDGV(dgvA)) ||
                    !IsMatriciesValuesEqual(jsonParams.R, GetDiagonalMatrixValuesInDGV(dgvR)) ||
                    !jsonParams.Q.SequenceEqual(GetVectorValuesInDGV(dgvQ)))
                    throwDialogWindow = true;
            }

            if (throwDialogWindow)
            {
                var resultAns = MessageBox.Show("Вы не сохранили введённые параметры.\nХотите сохранить их?", "Сохранить?", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (resultAns == DialogResult.Yes)
                {
                    SaveResultsF2ToolStripMenuItem_Click(null, null);
                }
                else if (resultAns == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        public bool IsMatriciesValuesEqual(double[,] valuesFirstMatrix, double[,] actualSecondMatrix)
        {
            for (int i = 0; i < valuesFirstMatrix.GetLength(0); i++)
                for (int j = 0; j < valuesFirstMatrix.GetLength(1); j++)
                    if (valuesFirstMatrix[i, j] != actualSecondMatrix[i, j])
                        return false;

            return true;
        }

        private bool IsDGVsFillZero() => IsZeroDGV(dgvA) && IsZeroDGV(dgvQ) && IsZeroDGV(dgvR);

        private bool IsZeroDGV(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
                for (int j = 0; j < dgv.RowCount; j++)
                    if (int.TryParse(dgv[i,j].Value as string, out int ans) ? ans != 0 : false)
                        return false;

            return true;
        }

        private void BTSolveTask_Click(object sender, EventArgs e)
        {
            SolutionForm solutionForm = new SolutionForm(
                new Matrix(GetMatrixValuesInDGV(dgvA)), 
                new Matrix(GetDiagonalMatrixValuesInDGV(dgvR)),
                new Vector(GetVectorValuesInDGV(dgvQ)));
            
            if (!solutionForm.IsDisposed)
                solutionForm.ShowDialog();
        }
    }
}