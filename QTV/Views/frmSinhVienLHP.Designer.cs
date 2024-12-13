namespace QTV.Views
{
    partial class frmSinhVienLHP
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgvSinhVien = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dgvSinhVienNot = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVienNot).BeginInit();
            SuspendLayout();
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.BackgroundColor = Color.WhiteSmoke;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(501, 132);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(381, 373);
            dgvSinhVien.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(55, 67);
            label1.Name = "label1";
            label1.Size = new Size(276, 37);
            label1.TabIndex = 25;
            label1.Text = "Danh Sách Sinh Viên";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(501, 67);
            label2.Name = "label2";
            label2.Size = new Size(276, 37);
            label2.TabIndex = 29;
            label2.Text = "Danh Sách Sinh Viên";
            // 
            // dgvSinhVienNot
            // 
            dgvSinhVienNot.BackgroundColor = Color.WhiteSmoke;
            dgvSinhVienNot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVienNot.Location = new Point(55, 132);
            dgvSinhVienNot.Name = "dgvSinhVienNot";
            dgvSinhVienNot.RowHeadersWidth = 51;
            dgvSinhVienNot.Size = new Size(374, 373);
            dgvSinhVienNot.TabIndex = 30;
            // 
            // frmSinhVienLHP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(dgvSinhVienNot);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvSinhVien);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmSinhVienLHP";
            Text = "frmSinhVienLHP";
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVienNot).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Label label2;
        private DataGridView dataGridView2;
        private DataGridView dgvSinhVien;
        private DataGridView dgvSinhVienNot;
    }
}