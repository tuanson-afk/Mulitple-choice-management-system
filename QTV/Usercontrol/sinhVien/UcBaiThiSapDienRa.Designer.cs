namespace QTV.Usercontrol.sinhVien
{
    partial class UcBaiThiSapDienRa
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            container = new Guna.UI2.WinForms.Guna2Panel();
            btnLamBai = new Guna.UI2.WinForms.Guna2Button();
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
            mainPanel.CustomizableEdges = customizableEdges7;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 2, 3, 2);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            mainPanel.Size = new Size(389, 250);
            mainPanel.TabIndex = 0;
            // 
            // container
            // 
            container.BorderThickness = 1;
            container.Controls.Add(btnLamBai);
            container.Controls.Add(lblTGBatDau);
            container.Controls.Add(lblTenLopHP);
            container.Controls.Add(LabelTGBatDau);
            container.Controls.Add(LabelTenLopHP);
            container.Controls.Add(lblTenBaiThi);
            container.CustomBorderThickness = new Padding(3, 0, 3, 3);
            container.CustomizableEdges = customizableEdges3;
            container.Dock = DockStyle.Bottom;
            container.Location = new Point(0, 122);
            container.Margin = new Padding(0);
            container.Name = "container";
            container.Padding = new Padding(22, 15, 22, 15);
            container.ShadowDecoration.CustomizableEdges = customizableEdges4;
            container.Size = new Size(389, 128);
            container.TabIndex = 1;
            // 
            // btnLamBai
            // 
            btnLamBai.BorderRadius = 4;
            btnLamBai.CustomizableEdges = customizableEdges1;
            btnLamBai.DisabledState.BorderColor = Color.DarkGray;
            btnLamBai.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLamBai.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLamBai.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLamBai.FillColor = Color.Firebrick;
            btnLamBai.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamBai.ForeColor = Color.White;
            btnLamBai.Location = new Point(242, 82);
            btnLamBai.Margin = new Padding(3, 2, 3, 2);
            btnLamBai.Name = "btnLamBai";
            btnLamBai.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLamBai.Size = new Size(123, 25);
            btnLamBai.TabIndex = 5;
            btnLamBai.Text = "Làm bài";
            btnLamBai.Click += btnLamBai_Click_1;
            // 
            // lblTGBatDau
            // 
            lblTGBatDau.BackColor = Color.Transparent;
            lblTGBatDau.Location = new Point(106, 86);
            lblTGBatDau.Margin = new Padding(3, 2, 3, 2);
            lblTGBatDau.Name = "lblTGBatDau";
            lblTGBatDau.Size = new Size(95, 17);
            lblTGBatDau.TabIndex = 4;
            lblTGBatDau.Text = "Thời gian bắt đầu";
            // 
            // lblTenLopHP
            // 
            lblTenLopHP.BackColor = Color.Transparent;
            lblTenLopHP.Location = new Point(106, 56);
            lblTenLopHP.Margin = new Padding(3, 2, 3, 2);
            lblTenLopHP.Name = "lblTenLopHP";
            lblTenLopHP.Size = new Size(34, 17);
            lblTenLopHP.TabIndex = 3;
            lblTenLopHP.Text = "K71E3";
            // 
            // LabelTGBatDau
            // 
            LabelTGBatDau.BackColor = Color.Transparent;
            LabelTGBatDau.Location = new Point(24, 86);
            LabelTGBatDau.Margin = new Padding(3, 2, 3, 2);
            LabelTGBatDau.Name = "LabelTGBatDau";
            LabelTGBatDau.Size = new Size(55, 17);
            LabelTGBatDau.TabIndex = 2;
            LabelTGBatDau.Text = "Thời gian: ";
            // 
            // LabelTenLopHP
            // 
            LabelTenLopHP.BackColor = Color.Transparent;
            LabelTenLopHP.Location = new Point(24, 56);
            LabelTenLopHP.Margin = new Padding(3, 2, 3, 2);
            LabelTenLopHP.Name = "LabelTenLopHP";
            LabelTenLopHP.Size = new Size(45, 17);
            LabelTenLopHP.TabIndex = 1;
            LabelTenLopHP.Text = "Tên lớp: ";
            // 
            // lblTenBaiThi
            // 
            lblTenBaiThi.BackColor = Color.Transparent;
            lblTenBaiThi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenBaiThi.ForeColor = Color.FromArgb(64, 64, 64);
            lblTenBaiThi.Location = new Point(24, 25);
            lblTenBaiThi.Margin = new Padding(3, 2, 3, 2);
            lblTenBaiThi.Name = "lblTenBaiThi";
            lblTenBaiThi.Size = new Size(73, 21);
            lblTenBaiThi.TabIndex = 0;
            lblTenBaiThi.Text = "Tên bài thi";
            // 
            // img
            // 
            img.CustomizableEdges = customizableEdges5;
            img.Dock = DockStyle.Top;
            img.Image = Properties.Resources.abstract_6284460_1920;
            img.ImageRotate = 0F;
            img.Location = new Point(0, 0);
            img.Margin = new Padding(0);
            img.Name = "img";
            img.ShadowDecoration.CustomizableEdges = customizableEdges6;
            img.Size = new Size(389, 124);
            img.TabIndex = 0;
            img.TabStop = false;
            img.Click += img_Click;
            // 
            // UcBaiThiSapDienRa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Margin = new Padding(0, 0, 13, 0);
            Name = "UcBaiThiSapDienRa";
            Size = new Size(389, 250);
            mainPanel.ResumeLayout(false);
            container.ResumeLayout(false);
            container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)img).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Panel container;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelTGBatDau;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelTenLopHP;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenBaiThi;
        private Guna.UI2.WinForms.Guna2PictureBox img;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTGBatDau;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenLopHP;
        private Guna.UI2.WinForms.Guna2Button btnLamBai;
    }
}
