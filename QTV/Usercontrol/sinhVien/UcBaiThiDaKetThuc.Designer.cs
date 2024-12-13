namespace QTV.Usercontrol.sinhVien
{
    partial class UcBaiThiDaKetThuc
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            container = new Guna.UI2.WinForms.Guna2Panel();
            lblTGBatDau = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTenLopHP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            LabelTGBatDau = new Guna.UI2.WinForms.Guna2HtmlLabel();
            LabelTenLopHP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTenBaiThi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            img = new Guna.UI2.WinForms.Guna2PictureBox();
            mainPanel.SuspendLayout();
            container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)img).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(container);
            mainPanel.Controls.Add(img);
            mainPanel.CustomizableEdges = customizableEdges5;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            mainPanel.Size = new Size(445, 334);
            mainPanel.TabIndex = 0;
            // 
            // container
            // 
            container.BorderColor = Color.Gray;
            container.BorderRadius = 4;
            container.BorderThickness = 2;
            container.Controls.Add(lblTGBatDau);
            container.Controls.Add(lblTenLopHP);
            container.Controls.Add(LabelTGBatDau);
            container.Controls.Add(LabelTenLopHP);
            container.Controls.Add(lblTenBaiThi);
            container.CustomBorderThickness = new Padding(3, 0, 3, 3);
            customizableEdges1.TopLeft = false;
            customizableEdges1.TopRight = false;
            container.CustomizableEdges = customizableEdges1;
            container.Dock = DockStyle.Bottom;
            container.Location = new Point(0, 172);
            container.Margin = new Padding(0);
            container.Name = "container";
            container.Padding = new Padding(25, 20, 25, 20);
            container.ShadowDecoration.CustomizableEdges = customizableEdges2;
            container.Size = new Size(445, 162);
            container.TabIndex = 2;
            // 
            // lblTGBatDau
            // 
            lblTGBatDau.BackColor = Color.Transparent;
            lblTGBatDau.Location = new Point(121, 105);
            lblTGBatDau.Name = "lblTGBatDau";
            lblTGBatDau.Size = new Size(120, 22);
            lblTGBatDau.TabIndex = 4;
            lblTGBatDau.Text = "Thời gian bắt đầu";
            // 
            // lblTenLopHP
            // 
            lblTenLopHP.BackColor = Color.Transparent;
            lblTenLopHP.ForeColor = Color.Black;
            lblTenLopHP.Location = new Point(121, 65);
            lblTenLopHP.Name = "lblTenLopHP";
            lblTenLopHP.Size = new Size(44, 22);
            lblTenLopHP.TabIndex = 3;
            lblTenLopHP.Text = "K71E3";
            // 
            // LabelTGBatDau
            // 
            LabelTGBatDau.BackColor = Color.Transparent;
            LabelTGBatDau.ForeColor = Color.FromArgb(64, 64, 64);
            LabelTGBatDau.Location = new Point(28, 105);
            LabelTGBatDau.Name = "LabelTGBatDau";
            LabelTGBatDau.Size = new Size(68, 22);
            LabelTGBatDau.TabIndex = 2;
            LabelTGBatDau.Text = "Thời gian: ";
            // 
            // LabelTenLopHP
            // 
            LabelTenLopHP.BackColor = Color.Transparent;
            LabelTenLopHP.ForeColor = Color.FromArgb(64, 64, 64);
            LabelTenLopHP.Location = new Point(28, 65);
            LabelTenLopHP.Name = "LabelTenLopHP";
            LabelTenLopHP.Size = new Size(56, 22);
            LabelTenLopHP.TabIndex = 1;
            LabelTenLopHP.Text = "Tên lớp: ";
            // 
            // lblTenBaiThi
            // 
            lblTenBaiThi.BackColor = Color.Transparent;
            lblTenBaiThi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenBaiThi.ForeColor = Color.FromArgb(64, 64, 64);
            lblTenBaiThi.Location = new Point(28, 24);
            lblTenBaiThi.Name = "lblTenBaiThi";
            lblTenBaiThi.Size = new Size(101, 25);
            lblTenBaiThi.TabIndex = 0;
            lblTenBaiThi.Text = "TÊN BÀI THI";
            lblTenBaiThi.Click += lblTenBaiThi_Click;
            // 
            // img
            // 
            img.BorderRadius = 4;
            img.CustomizableEdges = customizableEdges3;
            img.Dock = DockStyle.Top;
            img.Image = Properties.Resources.art_7065738_640;
            img.ImageRotate = 0F;
            img.Location = new Point(0, 0);
            img.Margin = new Padding(0);
            img.Name = "img";
            img.ShadowDecoration.CustomizableEdges = customizableEdges4;
            img.Size = new Size(445, 179);
            img.TabIndex = 0;
            img.TabStop = false;
            // 
            // UcBaiThiDaKetThuc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Margin = new Padding(0, 0, 15, 0);
            Name = "UcBaiThiDaKetThuc";
            Size = new Size(445, 334);
            mainPanel.ResumeLayout(false);
            container.ResumeLayout(false);
            container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)img).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2PictureBox img;
        private Guna.UI2.WinForms.Guna2Panel container;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTGBatDau;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenLopHP;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelTGBatDau;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelTenLopHP;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenBaiThi;
    }
}
