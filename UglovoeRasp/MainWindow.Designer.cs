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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1_R = new System.Windows.Forms.TextBox();
            this.textBox2_Плотность = new System.Windows.Forms.TextBox();
            this.textBox3_count_зерен = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьДанныеИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьРезультатВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar1Расчет = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel1Выполнение = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1Kord = new System.Windows.Forms.CheckBox();
            this.checkBox1GraphW = new System.Windows.Forms.CheckBox();
            this.button1startmath = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 104);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1_R
            // 
            this.textBox1_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1_R.Location = new System.Drawing.Point(190, 3);
            this.textBox1_R.Name = "textBox1_R";
            this.textBox1_R.Size = new System.Drawing.Size(181, 29);
            this.textBox1_R.TabIndex = 1;
            // 
            // textBox2_Плотность
            // 
            this.textBox2_Плотность.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2_Плотность.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2_Плотность.Location = new System.Drawing.Point(190, 38);
            this.textBox2_Плотность.Name = "textBox2_Плотность";
            this.textBox2_Плотность.Size = new System.Drawing.Size(181, 29);
            this.textBox2_Плотность.TabIndex = 2;
            // 
            // textBox3_count_зерен
            // 
            this.textBox3_count_зерен.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3_count_зерен.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3_count_зерен.Location = new System.Drawing.Point(190, 73);
            this.textBox3_count_зерен.Name = "textBox3_count_зерен";
            this.textBox3_count_зерен.Size = new System.Drawing.Size(181, 29);
            this.textBox3_count_зерен.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "R";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Плотность";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Число зерен";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(380, 187);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(380, 22);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьДанныеИзФайлаToolStripMenuItem,
            this.сохранитьРезультатВФайлToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 18);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьДанныеИзФайлаToolStripMenuItem
            // 
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Name = "загрузитьДанныеИзФайлаToolStripMenuItem";
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Text = "Загрузить данные из файла";
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.загрузитьДанныеИзФайлаToolStripMenuItem_Click);
            // 
            // сохранитьРезультатВФайлToolStripMenuItem
            // 
            this.сохранитьРезультатВФайлToolStripMenuItem.Name = "сохранитьРезультатВФайлToolStripMenuItem";
            this.сохранитьРезультатВФайлToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.сохранитьРезультатВФайлToolStripMenuItem.Text = "Сохранить результат в файл";
            this.сохранитьРезультатВФайлToolStripMenuItem.Visible = false;
            this.сохранитьРезультатВФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьРезультатВФайлToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 18);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 18);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar1Расчет,
            this.StatusLabel1Выполнение});
            this.statusStrip1.Location = new System.Drawing.Point(0, 167);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(380, 20);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar1Расчет
            // 
            this.ProgressBar1Расчет.Name = "ProgressBar1Расчет";
            this.ProgressBar1Расчет.Size = new System.Drawing.Size(100, 14);
            // 
            // StatusLabel1Выполнение
            // 
            this.StatusLabel1Выполнение.Name = "StatusLabel1Выполнение";
            this.StatusLabel1Выполнение.Size = new System.Drawing.Size(64, 15);
            this.StatusLabel1Выполнение.Text = "Ожидание";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.checkBox1Kord);
            this.flowLayoutPanel1.Controls.Add(this.checkBox1GraphW);
            this.flowLayoutPanel1.Controls.Add(this.button1startmath);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 135);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(374, 29);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // checkBox1Kord
            // 
            this.checkBox1Kord.AutoSize = true;
            this.checkBox1Kord.Location = new System.Drawing.Point(3, 3);
            this.checkBox1Kord.Name = "checkBox1Kord";
            this.checkBox1Kord.Size = new System.Drawing.Size(117, 17);
            this.checkBox1Kord.TabIndex = 3;
            this.checkBox1Kord.Text = "Расчет координат";
            this.checkBox1Kord.UseVisualStyleBackColor = true;
            // 
            // checkBox1GraphW
            // 
            this.checkBox1GraphW.AutoSize = true;
            this.checkBox1GraphW.Checked = true;
            this.checkBox1GraphW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1GraphW.Location = new System.Drawing.Point(126, 3);
            this.checkBox1GraphW.Name = "checkBox1GraphW";
            this.checkBox1GraphW.Size = new System.Drawing.Size(87, 17);
            this.checkBox1GraphW.TabIndex = 4;
            this.checkBox1GraphW.Text = "График W(r)";
            this.checkBox1GraphW.UseVisualStyleBackColor = true;
            // 
            // button1startmath
            // 
            this.button1startmath.Location = new System.Drawing.Point(219, 3);
            this.button1startmath.Name = "button1startmath";
            this.button1startmath.Size = new System.Drawing.Size(145, 23);
            this.button1startmath.TabIndex = 2;
            this.button1startmath.Text = "Расчет";
            this.button1startmath.UseVisualStyleBackColor = true;
            this.button1startmath.Click += new System.EventHandler(this.button1startmath_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(380, 187);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(396, 226);
            this.MinimumSize = new System.Drawing.Size(396, 226);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1_R;
        private System.Windows.Forms.TextBox textBox2_Плотность;
        private System.Windows.Forms.TextBox textBox3_count_зерен;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьДанныеИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьРезультатВФайлToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1startmath;
        private System.Windows.Forms.CheckBox checkBox1Kord;
        private System.Windows.Forms.CheckBox checkBox1GraphW;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1Расчет;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1Выполнение;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
    }
}