namespace QTV.Usercontrol.giangVien
{
    partial class UcLopHPCuThe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            containelPanel = new Guna.UI2.WinForms.Guna2Panel();
            tbTenLopHP = new Guna.UI2.WinForms.Guna2TextBox();
            flpDanhSachBaiThi = new FlowLayoutPanel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            containelPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(-219, 101);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 37);
            label1.TabIndex = 22;
            label1.Text = "Môn học";
            // 
            // containelPanel
            // 
            containelPanel.Controls.Add(tbTenLopHP);
            containelPanel.Controls.Add(flpDanhSachBaiThi);
            containelPanel.Controls.Add(guna2HtmlLabel1);
            containelPanel.CustomizableEdges = customizableEdges3;
            containelPanel.Location = new Point(105, 155);
            containelPanel.Name = "containelPanel";
            containelPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            containelPanel.Size = new Size(1018, 381);
            containelPanel.TabIndex = 23;
            // 
            // tbTenLopHP
            // 
            tbTenLopHP.CustomizableEdges = customizableEdges1;
            tbTenLopHP.DefaultText = "";
            tbTenLopHP.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbTenLopHP.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbTenLopHP.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbTenLopHP.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbTenLopHP.Dock = DockStyle.Left;
            tbTenLopHP.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbTenLopHP.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbTenLopHP.ForeColor = Color.FromArgb(64, 64, 128);
            tbTenLopHP.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbTenLopHP.Location = new Point(0, 0);
            tbTenLopHP.Margin = new Padding(6, 9, 6, 9);
            tbTenLopHP.Name = "tbTenLopHP";
            tbTenLopHP.PasswordChar = '\0';
            tbTenLopHP.PlaceholderText = "";
            tbTenLopHP.SelectedText = "";
            tbTenLopHP.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbTenLopHP.Size = new Size(572, 81);
            tbTenLopHP.TabIndex = 2;
            tbTenLopHP.TextChanged += tbTenLopHP_TextChanged;
            // 
            // flpDanhSachBaiThi
            // 
            flpDanhSachBaiThi.Dock = DockStyle.Bottom;
            flpDanhSachBaiThi.Location = new Point(0, 81);
            flpDanhSachBaiThi.Name = "flpDanhSachBaiThi";
            flpDanhSachBaiThi.Size = new Size(1018, 300);
            flpDanhSachBaiThi.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(64, 64, 128);
            guna2HtmlLabel1.Location = new Point(582, 22);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(248, 39);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "> Danh sách bài thi";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
            // 
            // UcLopHPCuThe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(containelPanel);
            Controls.Add(label1);
            Name = "UcLopHPCuThe";
            Size = new Size(1200, 680);
            Load += UcLopHPCuThe_Load;
            containelPanel.ResumeLayout(false);
            containelPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Guna.UI2.WinForms.Guna2Panel containelPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox tbTenLopHP;
        private FlowLayoutPanel flpDanhSachBaiThi;
    }
}
