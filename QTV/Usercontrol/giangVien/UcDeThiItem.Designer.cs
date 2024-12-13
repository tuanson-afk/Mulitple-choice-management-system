namespace QTV.Usercontrol.giangVien
{
    partial class UcDeThiItem
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
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            lblTenDeThi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblMaDeThi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            img = new Guna.UI2.WinForms.Guna2PictureBox();
            LabelTenDeThi = new Label();
            LabelMaDeThi = new Label();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)img).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackgroundImageLayout = ImageLayout.Center;
            mainPanel.BorderColor = Color.LightGray;
            mainPanel.BorderRadius = 4;
            mainPanel.BorderThickness = 1;
            mainPanel.Controls.Add(lblTenDeThi);
            mainPanel.Controls.Add(lblMaDeThi);
            mainPanel.Controls.Add(img);
            mainPanel.Controls.Add(LabelTenDeThi);
            mainPanel.Controls.Add(LabelMaDeThi);
            mainPanel.CustomizableEdges = customizableEdges3;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(0);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            mainPanel.Size = new Size(355, 269);
            mainPanel.TabIndex = 32;
            // 
            // lblTenDeThi
            // 
            lblTenDeThi.BackColor = Color.Transparent;
            lblTenDeThi.ForeColor = Color.FromArgb(64, 64, 64);
            lblTenDeThi.Location = new Point(112, 225);
            lblTenDeThi.Name = "lblTenDeThi";
            lblTenDeThi.Size = new Size(195, 22);
            lblTenDeThi.TabIndex = 8;
            lblTenDeThi.Text = "Lớp của Nguyễn Minh Quang";
            // 
            // lblMaDeThi
            // 
            lblMaDeThi.BackColor = Color.Transparent;
            lblMaDeThi.ForeColor = Color.FromArgb(64, 64, 64);
            lblMaDeThi.Location = new Point(112, 187);
            lblMaDeThi.Name = "lblMaDeThi";
            lblMaDeThi.Size = new Size(28, 22);
            lblMaDeThi.TabIndex = 7;
            lblMaDeThi.Text = "BTS";
            // 
            // img
            // 
            img.BorderRadius = 4;
            customizableEdges1.BottomLeft = false;
            customizableEdges1.BottomRight = false;
            img.CustomizableEdges = customizableEdges1;
            img.Image = Properties.Resources.background_6055853_640;
            img.ImageRotate = 0F;
            img.Location = new Point(0, 0);
            img.Margin = new Padding(0);
            img.Name = "img";
            img.ShadowDecoration.CustomizableEdges = customizableEdges2;
            img.Size = new Size(355, 167);
            img.TabIndex = 6;
            img.TabStop = false;
            // 
            // LabelTenDeThi
            // 
            LabelTenDeThi.AutoSize = true;
            LabelTenDeThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTenDeThi.ForeColor = Color.FromArgb(64, 64, 64);
            LabelTenDeThi.Location = new Point(15, 225);
            LabelTenDeThi.Margin = new Padding(2, 0, 2, 0);
            LabelTenDeThi.Name = "LabelTenDeThi";
            LabelTenDeThi.Size = new Size(82, 20);
            LabelTenDeThi.TabIndex = 3;
            LabelTenDeThi.Text = "Tên đề thi:";
            // 
            // LabelMaDeThi
            // 
            LabelMaDeThi.AutoSize = true;
            LabelMaDeThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelMaDeThi.ForeColor = Color.FromArgb(64, 64, 64);
            LabelMaDeThi.Location = new Point(15, 187);
            LabelMaDeThi.Margin = new Padding(2, 0, 2, 0);
            LabelMaDeThi.Name = "LabelMaDeThi";
            LabelMaDeThi.Size = new Size(79, 20);
            LabelMaDeThi.TabIndex = 2;
            LabelMaDeThi.Text = "Mã đề thi:";
            // 
            // UcDeThiItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Margin = new Padding(0, 0, 10, 10);
            Name = "UcDeThiItem";
            Size = new Size(355, 269);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)img).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenDeThi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaDeThi;
        private Guna.UI2.WinForms.Guna2PictureBox img;
        private Label LabelTenDeThi;
        private Label LabelMaDeThi;
    }
}
