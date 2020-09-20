namespace Interface
{
    partial class SettingsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jnrhsnmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьРезультатыВФайлF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализРезультатовРешенияЗадачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графическаяИнтерпритацияРезультатовРешенияЗадачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvA = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericColsA = new System.Windows.Forms.NumericUpDown();
            this.numericRowsA = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvQ = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvR = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColsA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRowsA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvR)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(721, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jnrhsnmToolStripMenuItem,
            this.сохранитьРезультатыВФайлF2ToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.закрытьФайлToolStripMenuItem,
            this.выходИзПрограммыToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // jnrhsnmToolStripMenuItem
            // 
            this.jnrhsnmToolStripMenuItem.Name = "jnrhsnmToolStripMenuItem";
            this.jnrhsnmToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.jnrhsnmToolStripMenuItem.Text = "Открыть файл данных F3";
            // 
            // сохранитьРезультатыВФайлF2ToolStripMenuItem
            // 
            this.сохранитьРезультатыВФайлF2ToolStripMenuItem.Name = "сохранитьРезультатыВФайлF2ToolStripMenuItem";
            this.сохранитьРезультатыВФайлF2ToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.сохранитьРезультатыВФайлF2ToolStripMenuItem.Text = "Сохранить результаты в файл F2";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // закрытьФайлToolStripMenuItem
            // 
            this.закрытьФайлToolStripMenuItem.Name = "закрытьФайлToolStripMenuItem";
            this.закрытьФайлToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.закрытьФайлToolStripMenuItem.Text = "Закрыть файл";
            // 
            // выходИзПрограммыToolStripMenuItem
            // 
            this.выходИзПрограммыToolStripMenuItem.Name = "выходИзПрограммыToolStripMenuItem";
            this.выходИзПрограммыToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.выходИзПрограммыToolStripMenuItem.Text = "Выход из программы Alt + X";
            this.выходИзПрограммыToolStripMenuItem.Click += new System.EventHandler(this.ApplicationCloseToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.анализРезультатовРешенияЗадачиToolStripMenuItem,
            this.графическаяИнтерпритацияРезультатовРешенияЗадачиToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.справкаToolStripMenuItem.Text = "Результаты";
            // 
            // анализРезультатовРешенияЗадачиToolStripMenuItem
            // 
            this.анализРезультатовРешенияЗадачиToolStripMenuItem.Name = "анализРезультатовРешенияЗадачиToolStripMenuItem";
            this.анализРезультатовРешенияЗадачиToolStripMenuItem.Size = new System.Drawing.Size(395, 22);
            this.анализРезультатовРешенияЗадачиToolStripMenuItem.Text = "Анализ результатов решения задачи";
            // 
            // графическаяИнтерпритацияРезультатовРешенияЗадачиToolStripMenuItem
            // 
            this.графическаяИнтерпритацияРезультатовРешенияЗадачиToolStripMenuItem.Name = "графическаяИнтерпритацияРезультатовРешенияЗадачиToolStripMenuItem";
            this.графическаяИнтерпритацияРезультатовРешенияЗадачиToolStripMenuItem.Size = new System.Drawing.Size(395, 22);
            this.графическаяИнтерпритацияРезультатовРешенияЗадачиToolStripMenuItem.Text = "Графическая интерпритация результатов решения задачи";
            // 
            // dgvA
            // 
            this.dgvA.AllowUserToAddRows = false;
            this.dgvA.AllowUserToDeleteRows = false;
            this.dgvA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvA.Location = new System.Drawing.Point(19, 136);
            this.dgvA.Name = "dgvA";
            this.dgvA.Size = new System.Drawing.Size(682, 200);
            this.dgvA.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Количество ветвей:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "1) Матрица инциденций:";
            // 
            // numericColsA
            // 
            this.numericColsA.Location = new System.Drawing.Point(210, 101);
            this.numericColsA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericColsA.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericColsA.Name = "numericColsA";
            this.numericColsA.Size = new System.Drawing.Size(104, 27);
            this.numericColsA.TabIndex = 11;
            this.numericColsA.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // numericRowsA
            // 
            this.numericRowsA.Location = new System.Drawing.Point(210, 68);
            this.numericRowsA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericRowsA.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericRowsA.Name = "numericRowsA";
            this.numericRowsA.Size = new System.Drawing.Size(104, 27);
            this.numericRowsA.TabIndex = 9;
            this.numericRowsA.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Количество узлов:";
            // 
            // dgvQ
            // 
            this.dgvQ.AllowUserToAddRows = false;
            this.dgvQ.AllowUserToDeleteRows = false;
            this.dgvQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQ.Location = new System.Drawing.Point(19, 402);
            this.dgvQ.Name = "dgvQ";
            this.dgvQ.Size = new System.Drawing.Size(315, 327);
            this.dgvQ.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 43);
            this.label4.TabIndex = 14;
            this.label4.Text = "2) Объем потоков в узлах:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(400, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 43);
            this.label5.TabIndex = 16;
            this.label5.Text = "3) Стоимость перевозок по ветвям:";
            // 
            // dgvR
            // 
            this.dgvR.AllowUserToAddRows = false;
            this.dgvR.AllowUserToDeleteRows = false;
            this.dgvR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvR.Location = new System.Drawing.Point(386, 402);
            this.dgvR.Name = "dgvR";
            this.dgvR.Size = new System.Drawing.Size(315, 327);
            this.dgvR.TabIndex = 15;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 748);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvQ);
            this.Controls.Add(this.dgvA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericColsA);
            this.Controls.Add(this.numericRowsA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма настройки данных для решения";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColsA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRowsA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jnrhsnmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьРезультатыВФайлF2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзПрограммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анализРезультатовРешенияЗадачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графическаяИнтерпритацияРезультатовРешенияЗадачиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericColsA;
        private System.Windows.Forms.NumericUpDown numericRowsA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvQ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvR;
    }
}

