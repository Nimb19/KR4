using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class SettingsForm : Form
    {
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
    }
}
