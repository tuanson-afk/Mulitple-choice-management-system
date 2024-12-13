namespace QTV.Usercontrol.giangVien
{
    partial class UcBaiThiItem
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
            lblTGThi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTenBaiThi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            img = new Guna.UI2.WinForms.Guna2PictureBox();
            LabelTGThi = new Label();
            LabelTenBaiThi = new Label();
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
            mainPanel.Controls.Add(lblTGThi);
            mainPanel.Controls.Add(lblTenBaiThi);
            mainPanel.Controls.Add(img);
            mainPanel.Controls.Add(LabelTGThi);
            mainPanel.Controls.Add(LabelTenBaiThi);
            mainPanel.CustomizableEdges = customizableEdges3;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(0);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            mainPanel.Size = new Size(355, 269);
            mainPanel.TabIndex = 33;
            // 
            // lblTGThi
            // 
            lblTGThi.BackColor = Color.Transparent;
            lblTGThi.ForeColor = Color.FromArgb(64, 64, 64);
            lblTGThi.Location = new Point(155, 225);
            lblTGThi.Name = "lblTGThi";
            lblTGThi.Size = new Size(137, 22);
            lblTGThi.TabIndex = 8;
            lblTGThi.Text = "20/10/2022 11:20:11";
            // 
            // lblTenBaiThi
            // 
            lblTenBaiThi.BackColor = Color.Transparent;
            lblTenBaiThi.ForeColor = Color.FromArgb(64, 64, 64);
            lblTenBaiThi.Location = new Point(118, 187);
            lblTenBaiThi.Name = "lblTenBaiThi";
            lblTenBaiThi.Size = new Size(28, 22);
            lblTenBaiThi.TabIndex = 7;
            lblTenBaiThi.Text = "BTS";
            // 
            // img
            // 
            img.BorderRadius = 4;
            customizableEdges1.BottomLeft = false;
            customizableEdges1.BottomRight = false;
            img.CustomizableEdges = customizableEdges1;
            img.Image = Properties.Resources.background_7009746_640;
            img.ImageRotate = 0F;
            img.Location = new Point(0, 0);
            img.Margin = new Padding(0);
            img.Name = "img";
            img.ShadowDecoration.CustomizableEdges = customizableEdges2;
            img.Size = new Size(355, 167);
            img.TabIndex = 6;
            img.TabStop = false;
            // 
            // LabelTGThi
            // 
            LabelTGThi.AutoSize = true;
            LabelTGThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTGThi.ForeColor = Color.FromArgb(64, 64, 64);
            LabelTGThi.Location = new Point(15, 225);
            LabelTGThi.Margin = new Padding(2, 0, 2, 0);
            LabelTGThi.Name = "LabelTGThi";
            LabelTGThi.Size = new Size(135, 20);
            LabelTGThi.TabIndex = 3;
            LabelTGThi.Text = "Thời gian bắt đầu:";
            // 
            // LabelTenBaiThi
            // 
            LabelTenBaiThi.AutoSize = true;
            LabelTenBaiThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTenBaiThi.ForeColor = Color.FromArgb(64, 64, 64);
            LabelTenBaiThi.Location = new Point(15, 187);
            LabelTenBaiThi.Margin = new Padding(2, 0, 2, 0);
            LabelTenBaiThi.Name = "LabelTenBaiThi";
            LabelTenBaiThi.Size = new Size(90, 20);
            LabelTenBaiThi.TabIndex = 2;
            LabelTenBaiThi.Text = "Tên bài thi: ";
            // 
            // UcBaiThiItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Margin = new Padding(0, 0, 10, 10);
            Name = "UcBaiThiItem";
            Size = new Size(355, 269);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)img).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTGThi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenBaiThi;
        private Guna.UI2.WinForms.Guna2PictureBox img;
        private Label LabelTGThi;
        private Label LabelTenBaiThi;
    }
}
