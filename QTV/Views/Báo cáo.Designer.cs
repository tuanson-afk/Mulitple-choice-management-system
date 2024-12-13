namespace BCTK
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Kỹ nghệ phần mềm", "Nguyên lí kế toán" });
            comboBox1.Location = new Point(707, 69);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Kỹ nghệ phần mềm", "Nguyên lí kế toán" });
            comboBox2.Location = new Point(707, 137);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 2;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Kỹ nghệ phần mềm", "Nguyên lí kế toán" });
            comboBox3.Location = new Point(1188, 65);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(569, 61);
            label1.Name = "label1";
            label1.Size = new Size(55, 28);
            label1.TabIndex = 4;
            label1.Text = "Môn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(1072, 65);
            label2.Name = "label2";
            label2.Size = new Size(74, 28);
            label2.TabIndex = 5;
            label2.Text = "Bài thi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(569, 137);
            label3.Name = "label3";
            label3.Size = new Size(47, 28);
            label3.TabIndex = 6;
            label3.Text = "Lớp";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(60, 285);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1775, 612);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 4;
            guna2Button2.CustomizableEdges = customizableEdges1;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.ForestGreen;
            guna2Button2.Font = new Font("Segoe UI", 9F);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(839, 196);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button2.Size = new Size(105, 32);
            guna2Button2.TabIndex = 8;
            guna2Button2.Text = "Xuất Excel";
            // 
            // guna2Button4
            // 
            guna2Button4.BorderRadius = 4;
            guna2Button4.CustomizableEdges = customizableEdges3;
            guna2Button4.DisabledState.BorderColor = Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button4.FillColor = Color.FromArgb(57, 90, 127);
            guna2Button4.Font = new Font("Segoe UI", 9F);
            guna2Button4.ForeColor = Color.White;
            guna2Button4.Location = new Point(1072, 196);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button4.Size = new Size(127, 32);
            guna2Button4.TabIndex = 9;
            guna2Button4.Text = "Xem phổ điểm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(0, -1);
            label4.Name = "label4";
            label4.Size = new Size(145, 46);
            label4.TabIndex = 10;
            label4.Text = "Báo cáo";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(label4);
            Controls.Add(guna2Button4);
            Controls.Add(guna2Button2);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Label label4;
    }
}
