namespace QTV.Views.GiangVien
{
    partial class frmDanhSachDeThi
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            containerPanel = new Guna.UI2.WinForms.Guna2Panel();
            btnXoaDeThi = new Guna.UI2.WinForms.Guna2Button();
            btnSuaDeThi = new Guna.UI2.WinForms.Guna2Button();
            btnCapNhatDuLieu = new Guna.UI2.WinForms.Guna2Button();
            gbDanhSachBaiThi = new Guna.UI2.WinForms.Guna2GroupBox();
            flpDanhSachDeThi = new FlowLayoutPanel();
            btnThemDeThi = new Guna.UI2.WinForms.Guna2Button();
            tbDanhSachDeThi = new Guna.UI2.WinForms.Guna2TextBox();
            mainPanel.SuspendLayout();
            containerPanel.SuspendLayout();
            gbDanhSachBaiThi.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(containerPanel);
            mainPanel.CustomBorderColor = Color.Transparent;
            mainPanel.CustomizableEdges = customizableEdges15;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges16;
            mainPanel.Size = new Size(1582, 924);
            mainPanel.TabIndex = 1;
            // 
            // containerPanel
            // 
            containerPanel.Anchor = AnchorStyles.None;
            containerPanel.BackColor = Color.White;
            containerPanel.BorderRadius = 6;
            containerPanel.Controls.Add(btnXoaDeThi);
            containerPanel.Controls.Add(btnSuaDeThi);
            containerPanel.Controls.Add(btnCapNhatDuLieu);
            containerPanel.Controls.Add(gbDanhSachBaiThi);
            containerPanel.Controls.Add(btnThemDeThi);
            containerPanel.Controls.Add(tbDanhSachDeThi);
            containerPanel.CustomBorderThickness = new Padding(2);
            containerPanel.CustomizableEdges = customizableEdges13;
            containerPanel.Location = new Point(9, 13);
            containerPanel.Margin = new Padding(0);
            containerPanel.Name = "containerPanel";
            containerPanel.Padding = new Padding(23, 40, 23, 40);
            containerPanel.ShadowDecoration.BorderRadius = 12;
            containerPanel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            containerPanel.Size = new Size(1564, 800);
            containerPanel.TabIndex = 0;
            containerPanel.Paint += containerPanel_Paint;
            // 
            // btnXoaDeThi
            // 
            btnXoaDeThi.BorderRadius = 4;
            btnXoaDeThi.CustomizableEdges = customizableEdges1;
            btnXoaDeThi.DisabledState.BorderColor = Color.DarkGray;
            btnXoaDeThi.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXoaDeThi.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXoaDeThi.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXoaDeThi.FillColor = Color.Firebrick;
            btnXoaDeThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaDeThi.ForeColor = Color.White;
            btnXoaDeThi.Image = Properties.Resources.trash__2_;
            btnXoaDeThi.ImageSize = new Size(15, 15);
            btnXoaDeThi.Location = new Point(1080, 165);
            btnXoaDeThi.Margin = new Padding(34, 60, 34, 60);
            btnXoaDeThi.Name = "btnXoaDeThi";
            btnXoaDeThi.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnXoaDeThi.Size = new Size(153, 49);
            btnXoaDeThi.TabIndex = 29;
            btnXoaDeThi.Text = " Xóa đề thi";
            btnXoaDeThi.Click += btnXoaDeThi_Click;
            // 
            // btnSuaDeThi
            // 
            btnSuaDeThi.BorderRadius = 4;
            btnSuaDeThi.CustomizableEdges = customizableEdges3;
            btnSuaDeThi.DisabledState.BorderColor = Color.DarkGray;
            btnSuaDeThi.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSuaDeThi.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSuaDeThi.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSuaDeThi.FillColor = Color.SteelBlue;
            btnSuaDeThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuaDeThi.ForeColor = Color.White;
            btnSuaDeThi.Image = Properties.Resources.file_edit__1_;
            btnSuaDeThi.ImageSize = new Size(15, 15);
            btnSuaDeThi.Location = new Point(581, 165);
            btnSuaDeThi.Margin = new Padding(34, 60, 34, 60);
            btnSuaDeThi.Name = "btnSuaDeThi";
            btnSuaDeThi.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSuaDeThi.Size = new Size(153, 49);
            btnSuaDeThi.TabIndex = 28;
            btnSuaDeThi.Text = " Sửa đề thi";
            btnSuaDeThi.Click += btnSuaDeThi_Click;
            // 
            // btnCapNhatDuLieu
            // 
            btnCapNhatDuLieu.BorderRadius = 4;
            btnCapNhatDuLieu.CustomizableEdges = customizableEdges5;
            btnCapNhatDuLieu.DisabledState.BorderColor = Color.DarkGray;
            btnCapNhatDuLieu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCapNhatDuLieu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCapNhatDuLieu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCapNhatDuLieu.FillColor = Color.ForestGreen;
            btnCapNhatDuLieu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhatDuLieu.ForeColor = Color.White;
            btnCapNhatDuLieu.Image = Properties.Resources.upload__1_;
            btnCapNhatDuLieu.ImageSize = new Size(12, 12);
            btnCapNhatDuLieu.Location = new Point(835, 165);
            btnCapNhatDuLieu.Margin = new Padding(34, 60, 34, 60);
            btnCapNhatDuLieu.Name = "btnCapNhatDuLieu";
            btnCapNhatDuLieu.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCapNhatDuLieu.Size = new Size(153, 49);
            btnCapNhatDuLieu.TabIndex = 26;
            btnCapNhatDuLieu.Text = "Cập nhật dữ liệu";
            btnCapNhatDuLieu.Click += btnCapNhatDuLieu_Click;
            // 
            // gbDanhSachBaiThi
            // 
            gbDanhSachBaiThi.Controls.Add(flpDanhSachDeThi);
            gbDanhSachBaiThi.CustomBorderThickness = new Padding(0);
            gbDanhSachBaiThi.CustomizableEdges = customizableEdges7;
            gbDanhSachBaiThi.Font = new Font("Segoe UI", 9F);
            gbDanhSachBaiThi.ForeColor = Color.FromArgb(125, 137, 149);
            gbDanhSachBaiThi.Location = new Point(26, 279);
            gbDanhSachBaiThi.Margin = new Padding(3, 4, 3, 4);
            gbDanhSachBaiThi.Name = "gbDanhSachBaiThi";
            gbDanhSachBaiThi.Padding = new Padding(11, 13, 11, 13);
            gbDanhSachBaiThi.ShadowDecoration.CustomizableEdges = customizableEdges8;
            gbDanhSachBaiThi.Size = new Size(1512, 477);
            gbDanhSachBaiThi.TabIndex = 2;
            // 
            // flpDanhSachDeThi
            // 
            flpDanhSachDeThi.AutoScroll = true;
            flpDanhSachDeThi.Dock = DockStyle.Fill;
            flpDanhSachDeThi.Location = new Point(11, 13);
            flpDanhSachDeThi.Margin = new Padding(3, 4, 3, 4);
            flpDanhSachDeThi.Name = "flpDanhSachDeThi";
            flpDanhSachDeThi.Size = new Size(1490, 451);
            flpDanhSachDeThi.TabIndex = 0;
            // 
            // btnThemDeThi
            // 
            btnThemDeThi.BorderRadius = 4;
            btnThemDeThi.CustomizableEdges = customizableEdges9;
            btnThemDeThi.DisabledState.BorderColor = Color.DarkGray;
            btnThemDeThi.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemDeThi.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemDeThi.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemDeThi.FillColor = Color.FromArgb(64, 64, 128);
            btnThemDeThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemDeThi.ForeColor = Color.White;
            btnThemDeThi.Image = Properties.Resources.plus__2_2;
            btnThemDeThi.ImageSize = new Size(15, 15);
            btnThemDeThi.Location = new Point(331, 166);
            btnThemDeThi.Margin = new Padding(34, 60, 34, 60);
            btnThemDeThi.Name = "btnThemDeThi";
            btnThemDeThi.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnThemDeThi.Size = new Size(153, 49);
            btnThemDeThi.TabIndex = 27;
            btnThemDeThi.Text = " Thêm đề thi";
            btnThemDeThi.Click += btnThemDeThi_Click;
            // 
            // tbDanhSachDeThi
            // 
            tbDanhSachDeThi.BorderColor = Color.Transparent;
            tbDanhSachDeThi.BorderThickness = 0;
            tbDanhSachDeThi.Cursor = Cursors.IBeam;
            tbDanhSachDeThi.CustomizableEdges = customizableEdges11;
            tbDanhSachDeThi.DefaultText = "Danh sách đề thi";
            tbDanhSachDeThi.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbDanhSachDeThi.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbDanhSachDeThi.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbDanhSachDeThi.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbDanhSachDeThi.Enabled = false;
            tbDanhSachDeThi.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbDanhSachDeThi.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbDanhSachDeThi.ForeColor = Color.FromArgb(64, 64, 128);
            tbDanhSachDeThi.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbDanhSachDeThi.Location = new Point(27, 29);
            tbDanhSachDeThi.Margin = new Padding(13, 12, 13, 12);
            tbDanhSachDeThi.Name = "tbDanhSachDeThi";
            tbDanhSachDeThi.PasswordChar = '\0';
            tbDanhSachDeThi.PlaceholderText = "";
            tbDanhSachDeThi.ReadOnly = true;
            tbDanhSachDeThi.SelectedText = "";
            tbDanhSachDeThi.ShadowDecoration.CustomizableEdges = customizableEdges12;
            tbDanhSachDeThi.Size = new Size(751, 112);
            tbDanhSachDeThi.TabIndex = 1;
            // 
            // frmDanhSachDeThi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 924);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDanhSachDeThi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách đề thi";
            WindowState = FormWindowState.Maximized;
            Load += frmDanhSachDeThi_Load;
            mainPanel.ResumeLayout(false);
            containerPanel.ResumeLayout(false);
            gbDanhSachBaiThi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Panel containerPanel;
        private Guna.UI2.WinForms.Guna2Button btnSuaDeThi;
        private Guna.UI2.WinForms.Guna2Button btnCapNhatDuLieu;
        private Guna.UI2.WinForms.Guna2GroupBox gbDanhSachBaiThi;
        private FlowLayoutPanel flpDanhSachDeThi;
        private Guna.UI2.WinForms.Guna2Button btnThemDeThi;
        private Guna.UI2.WinForms.Guna2TextBox tbDanhSachDeThi;
        private Guna.UI2.WinForms.Guna2Button btnXoaDeThi;
    }
}