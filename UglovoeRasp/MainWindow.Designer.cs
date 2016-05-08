namespace Угловое_распределение
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьДанныеИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьРезультатВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar1Расчет = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel1Выполнение = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1Kord = new System.Windows.Forms.CheckBox();
            this.checkBox1GraphW = new System.Windows.Forms.CheckBox();
            this.button1startmath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3_count_зерен = new System.Windows.Forms.TextBox();
            this.textBox2_Плотность = new System.Windows.Forms.TextBox();
            this.textBox1_R = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(632, 223);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьДанныеИзФайлаToolStripMenuItem,
            this.сохранитьРезультатВФайлToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.файлToolStripMenuItem.Text = "Исходные данные";
            // 
            // загрузитьДанныеИзФайлаToolStripMenuItem
            // 
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Name = "загрузитьДанныеИзФайлаToolStripMenuItem";
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Text = "Загрузить данные из файла";
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.загрузитьДанныеИзФайлаToolStripMenuItem_Click);
            // 
            // сохранитьРезультатВФайлToolStripMenuItem
            // 
            this.сохранитьРезультатВФайлToolStripMenuItem.Name = "сохранитьРезультатВФайлToolStripMenuItem";
            this.сохранитьРезультатВФайлToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.сохранитьРезультатВФайлToolStripMenuItem.Text = "Сохранить данные в файл";
            this.сохранитьРезультатВФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьДанныеВФайлToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar1Расчет,
            this.StatusLabel1Выполнение});
            this.statusStrip1.Location = new System.Drawing.Point(0, 201);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar1Расчет
            // 
            this.ProgressBar1Расчет.Name = "ProgressBar1Расчет";
            this.ProgressBar1Расчет.Size = new System.Drawing.Size(100, 16);
            // 
            // StatusLabel1Выполнение
            // 
            this.StatusLabel1Выполнение.Name = "StatusLabel1Выполнение";
            this.StatusLabel1Выполнение.Size = new System.Drawing.Size(64, 17);
            this.StatusLabel1Выполнение.Text = "Ожидание";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.checkBox1Kord, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBox1GraphW, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button1startmath, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 156);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(626, 38);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // checkBox1Kord
            // 
            this.checkBox1Kord.AutoSize = true;
            this.checkBox1Kord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1Kord.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox1Kord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1Kord.Location = new System.Drawing.Point(5, 5);
            this.checkBox1Kord.Name = "checkBox1Kord";
            this.checkBox1Kord.Size = new System.Drawing.Size(153, 28);
            this.checkBox1Kord.TabIndex = 5;
            this.checkBox1Kord.Text = "Расчет координат";
            this.checkBox1Kord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1Kord.UseVisualStyleBackColor = true;
            // 
            // checkBox1GraphW
            // 
            this.checkBox1GraphW.AutoSize = true;
            this.checkBox1GraphW.Checked = true;
            this.checkBox1GraphW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1GraphW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1GraphW.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox1GraphW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1GraphW.Location = new System.Drawing.Point(166, 5);
            this.checkBox1GraphW.Name = "checkBox1GraphW";
            this.checkBox1GraphW.Size = new System.Drawing.Size(110, 28);
            this.checkBox1GraphW.TabIndex = 4;
            this.checkBox1GraphW.Text = "График W(r)";
            this.checkBox1GraphW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1GraphW.UseVisualStyleBackColor = true;
            // 
            // button1startmath
            // 
            this.button1startmath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1startmath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1startmath.Location = new System.Drawing.Point(284, 5);
            this.button1startmath.Name = "button1startmath";
            this.button1startmath.Size = new System.Drawing.Size(337, 28);
            this.button1startmath.TabIndex = 2;
            this.button1startmath.Text = "Расчет";
            this.button1startmath.UseVisualStyleBackColor = true;
            this.button1startmath.Click += new System.EventHandler(this.button1startmath_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 38);
            this.label3.TabIndex = 2;
            this.label3.Text = "Число зерен";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Плотность";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "R";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3_count_зерен
            // 
            this.textBox3_count_зерен.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3_count_зерен.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3_count_зерен.Location = new System.Drawing.Point(317, 85);
            this.textBox3_count_зерен.Name = "textBox3_count_зерен";
            this.textBox3_count_зерен.Size = new System.Drawing.Size(303, 29);
            this.textBox3_count_зерен.TabIndex = 3;
            // 
            // textBox2_Плотность
            // 
            this.textBox2_Плотность.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2_Плотность.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2_Плотность.Location = new System.Drawing.Point(317, 45);
            this.textBox2_Плотность.Name = "textBox2_Плотность";
            this.textBox2_Плотность.Size = new System.Drawing.Size(303, 29);
            this.textBox2_Плотность.TabIndex = 2;
            // 
            // textBox1_R
            // 
            this.textBox1_R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1_R.Location = new System.Drawing.Point(317, 6);
            this.textBox1_R.Name = "textBox1_R";
            this.textBox1_R.Size = new System.Drawing.Size(303, 29);
            this.textBox1_R.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1_R, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2_Плотность, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3_count_зерен, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 122);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(632, 223);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(3960, 2400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(396, 262);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьДанныеИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьРезультатВФайлToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBox1Kord;
        private System.Windows.Forms.CheckBox checkBox1GraphW;
        private System.Windows.Forms.Button button1startmath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1Расчет;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1Выполнение;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1_R;
        private System.Windows.Forms.TextBox textBox2_Плотность;
        private System.Windows.Forms.TextBox textBox3_count_зерен;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}