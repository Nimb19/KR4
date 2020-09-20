using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Interface
{
    public partial class SettingsForm : Form
    {
        private string filename { get; set; }
        public SettingsForm()
        {
            InitializeComponent();

            SetSettingsInDGV(dgvA);
            AddColumns(dgvA, Convert.ToInt32(numericColsA.Value));
            AddRows(dgvA, Convert.ToInt32(numericRowsA.Value), "Узел");

            SetSettingsInDGV(dgvQ);
            AddColumnsQ(dgvQ, "Объем потоков");
            AddRowsQ(dgvQ, Convert.ToInt32(numericRowsA.Value));

            SetSettingsInDGV(dgvR);
            AddColumnsR(dgvR, "Стоимость");
            AddRowsR(dgvR, Convert.ToInt32(numericColsA.Value));
        }

        private void AddRowsQ(DataGridView dgvQ, int count)
        {
            for (int i = 0; i < count; i++)
            {
                dgvQ.Rows.Add();
                dgvQ.Rows[dgvQ.RowCount - 1].HeaderCell.Value = "Узел №" + (dgvQ.RowCount - 1);
            }
        }

        private void AddColumnsQ(DataGridView dgvQ, string text)
        {
            var newcol = new DataGridViewColumn();
            newcol.CellTemplate = new DataGridViewTextBoxCell();
            newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            newcol.Resizable = DataGridViewTriState.True;
            newcol.HeaderCell.Value = text;

            dgvQ.Columns.Add(newcol);
        }

        private void AddColumnsR(DataGridView dgvR, string text)
        {
            var newcol = new DataGridViewColumn();
            newcol.CellTemplate = new DataGridViewTextBoxCell();
            newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            newcol.Resizable = DataGridViewTriState.True;
            newcol.HeaderCell.Value = text;

            dgvR.Columns.Add(newcol);
        }

        private void AddRowsR(DataGridView dgvR, int count)
        {
            for (int i = 0; i < count; i++)
            {
                dgvR.Rows.Add();
                dgvR.Rows[dgvR.RowCount - 1].HeaderCell.Value = "Ветвь №" + dgvR.RowCount;
            }
        }

        private void SetSettingsInDGV(DataGridView dataGridView)
        {
            var templateRow = new DataGridViewRow();
            templateRow.Height = 36;
            dataGridView.RowTemplate = templateRow;

            dataGridView.Font = new Font(new FontFamily(GenericFontFamilies.SansSerif), 12);
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToResizeRows = true;
            dataGridView.RowHeadersWidth = 120;
            dataGridView.ColumnHeadersHeight = 36;
        }

        private void AddColumns(DataGridView dataGridView, int count, string text = null)
        {
            for (int i = 0; i < count; i++)
            {
                var newcol = new DataGridViewColumn();
                newcol.CellTemplate = new DataGridViewTextBoxCell();
                newcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                newcol.Resizable = DataGridViewTriState.True;
                newcol.HeaderCell.Value = "Ветвь №" + (dataGridView.ColumnCount + 1);

                dataGridView.Columns.Add(newcol);
            }
        }

        private void AddRows(DataGridView dataGridView, int count, string text)
        {
            for (int i = 0; i < count; i++)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[dataGridView.RowCount - 1].HeaderCell.Value = text + " №" + (dataGridView.RowCount - 1);
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
                SaveDGVsParametersAsJson(saveFile.FileName);
        }

        private void SaveDGVsParametersAsJson(string filename)
        {
            DGVsParameters dgvsParameters =
                    new DGVsParameters(GetMatrixValuesInDGV(dgvA), GetDiagonalMatrixValuesInDGV(dgvR), GetVectorValuesInDGV(dgvQ));
            File.WriteAllText(filename, JsonConvert.SerializeObject(dgvsParameters));
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
    }
}
