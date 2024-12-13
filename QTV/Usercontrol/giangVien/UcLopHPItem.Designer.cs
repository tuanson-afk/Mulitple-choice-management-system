namespace QTV.Usercontrol.giangVien
{
    partial class UcLopHPItem
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
            img = new Guna.UI2.WinForms.Guna2PictureBox();
            LabelTenLHP = new Label();
            LabelMaLHP = new Label();
            lblMaLHP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTenLHP = new Guna.UI2.WinForms.Guna2HtmlLabel();
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
            mainPanel.Controls.Add(lblTenLHP);
            mainPanel.Controls.Add(lblMaLHP);
            mainPanel.Controls.Add(img);
            mainPanel.Controls.Add(LabelTenLHP);
            mainPanel.Controls.Add(LabelMaLHP);
            mainPanel.CustomizableEdges = customizableEdges3;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(0, 0, 10, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            mainPanel.Size = new Size(355, 269);
            mainPanel.TabIndex = 31;
            // 
            // img
            // 
            img.BorderRadius = 4;
            customizableEdges1.BottomLeft = false;
            customizableEdges1.BottomRight = false;
            img.CustomizableEdges = customizableEdges1;
            img.Image = Properties.Resources.background_6055745_640;
            img.ImageRotate = 0F;
            img.Location = new Point(0, 0);
            img.Margin = new Padding(0, 0, 10, 0);
            img.Name = "img";
            img.ShadowDecoration.CustomizableEdges = customizableEdges2;
            img.Size = new Size(355, 167);
            img.TabIndex = 6;
            img.TabStop = false;
            // 
            // LabelTenLHP
            // 
            LabelTenLHP.AutoSize = true;
            LabelTenLHP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTenLHP.ForeColor = Color.FromArgb(64, 64, 64);
            LabelTenLHP.Location = new Point(15, 225);
            LabelTenLHP.Margin = new Padding(2, 0, 2, 0);
            LabelTenLHP.Name = "LabelTenLHP";
            LabelTenLHP.Size = new Size(64, 20);
            LabelTenLHP.TabIndex = 3;
            LabelTenLHP.Text = "Tên lớp:";
            // 
            // LabelMaLHP
            // 
            LabelMaLHP.AutoSize = true;
            LabelMaLHP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelMaLHP.ForeColor = Color.FromArgb(64, 64, 64);
            LabelMaLHP.Location = new Point(15, 187);
            LabelMaLHP.Margin = new Padding(2, 0, 2, 0);
            LabelMaLHP.Name = "LabelMaLHP";
            LabelMaLHP.Size = new Size(61, 20);
            LabelMaLHP.TabIndex = 2;
            LabelMaLHP.Text = "Mã lớp:";
            // 
            // lblMaLHP
            // 
            lblMaLHP.BackColor = Color.Transparent;
            lblMaLHP.Location = new Point(84, 186);
            lblMaLHP.Name = "lblMaLHP";
            lblMaLHP.Size = new Size(28, 22);
            lblMaLHP.TabIndex = 7;
            lblMaLHP.Text = "BTS";
            // 
            // lblTenLHP
            // 
            lblTenLHP.BackColor = Color.Transparent;
            lblTenLHP.Location = new Point(84, 224);
            lblTenLHP.Name = "lblTenLHP";
            lblTenLHP.Size = new Size(195, 22);
            lblTenLHP.TabIndex = 8;
            lblTenLHP.Text = "Lớp của Nguyễn Minh Quang";
            // 
            // UcLopHPItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Name = "UcLopHPItem";
            Size = new Size(355, 269);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)img).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2PictureBox img;
        private Label LabelTenLHP;
        private Label LabelMaLHP;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenLHP;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaLHP;
    }
}
