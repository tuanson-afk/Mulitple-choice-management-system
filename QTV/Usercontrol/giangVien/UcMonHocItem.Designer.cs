namespace QTV.Usercontrol.giangVien
{
    partial class UcMonHocItem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            img = new Guna.UI2.WinForms.Guna2PictureBox();
            container = new Guna.UI2.WinForms.Guna2Panel();
            lblTenMon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblMaMon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            LabelTenMon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            LabelMaMon = new Guna.UI2.WinForms.Guna2HtmlLabel();
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)img).BeginInit();
            container.SuspendLayout();
            SuspendLayout();
            // 
            // img
            // 
            img.CustomizableEdges = customizableEdges1;
            img.Dock = DockStyle.Top;
            img.Image = Properties.Resources.blue_5520553_1920;
            img.ImageRotate = 0F;
            img.Location = new Point(0, 0);
            img.Margin = new Padding(0);
            img.Name = "img";
            img.ShadowDecoration.CustomizableEdges = customizableEdges2;
            img.Size = new Size(355, 167);
            img.TabIndex = 0;
            img.TabStop = false;
            // 
            // container
            // 
            container.Controls.Add(lblTenMon);
            container.Controls.Add(lblMaMon);
            container.Controls.Add(LabelTenMon);
            container.Controls.Add(LabelMaMon);
            container.CustomizableEdges = customizableEdges3;
            container.Dock = DockStyle.Bottom;
            container.Location = new Point(0, 166);
            container.Margin = new Padding(0);
            container.Name = "container";
            container.Padding = new Padding(29, 13, 29, 13);
            container.ShadowDecoration.CustomizableEdges = customizableEdges4;
            container.Size = new Size(355, 103);
            container.TabIndex = 1;
            // 
            // lblTenMon
            // 
            lblTenMon.BackColor = Color.Transparent;
            lblTenMon.ForeColor = Color.FromArgb(64, 64, 64);
            lblTenMon.Location = new Point(107, 63);
            lblTenMon.Margin = new Padding(3, 4, 3, 4);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(36, 22);
            lblTenMon.TabIndex = 3;
            lblTenMon.Text = "Toán";
            // 
            // lblMaMon
            // 
            lblMaMon.BackColor = Color.Transparent;
            lblMaMon.ForeColor = Color.FromArgb(64, 64, 64);
            lblMaMon.Location = new Point(107, 17);
            lblMaMon.Margin = new Padding(3, 4, 3, 4);
            lblMaMon.Name = "lblMaMon";
            lblMaMon.Size = new Size(59, 22);
            lblMaMon.TabIndex = 2;
            lblMaMon.Text = "1212121";
            // 
            // LabelTenMon
            // 
            LabelTenMon.BackColor = Color.Transparent;
            LabelTenMon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTenMon.ForeColor = Color.FromArgb(64, 64, 64);
            LabelTenMon.Location = new Point(32, 63);
            LabelTenMon.Margin = new Padding(3, 4, 3, 4);
            LabelTenMon.Name = "LabelTenMon";
            LabelTenMon.Size = new Size(69, 22);
            LabelTenMon.TabIndex = 1;
            LabelTenMon.Text = "Tên môn: ";
            // 
            // LabelMaMon
            // 
            LabelMaMon.BackColor = Color.Transparent;
            LabelMaMon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelMaMon.ForeColor = Color.FromArgb(64, 64, 64);
            LabelMaMon.Location = new Point(32, 17);
            LabelMaMon.Margin = new Padding(3, 4, 3, 4);
            LabelMaMon.Name = "LabelMaMon";
            LabelMaMon.Size = new Size(65, 22);
            LabelMaMon.TabIndex = 0;
            LabelMaMon.Text = "Mã môn: ";
            // 
            // mainPanel
            // 
            mainPanel.CustomizableEdges = customizableEdges5;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 167);
            mainPanel.Margin = new Padding(0, 0, 17, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            mainPanel.Size = new Size(355, 0);
            mainPanel.TabIndex = 2;
            // 
            // UcMonHocItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Controls.Add(container);
            Controls.Add(img);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UcMonHocItem";
            Size = new Size(355, 269);
            ((System.ComponentModel.ISupportInitialize)img).EndInit();
            container.ResumeLayout(false);
            container.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox img;
        private Guna.UI2.WinForms.Guna2Panel container;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelMaMon;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelTenMon;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaMon;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenMon;
    }
}
