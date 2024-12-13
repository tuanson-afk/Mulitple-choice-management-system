namespace QL_Trac_Nghiem.UserControls
{
    partial class UC_MonHoc
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
            label1 = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            flpMonHoc = new FlowLayoutPanel();
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 128);
            label1.Location = new Point(62, 141);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 37);
            label1.TabIndex = 20;
            label1.Text = "Môn học";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(flpMonHoc);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(62, 205);
            guna2Panel1.Margin = new Padding(3, 4, 3, 4);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(1584, 353);
            guna2Panel1.TabIndex = 21;
            // 
            // flpMonHoc
            // 
            flpMonHoc.AutoScroll = true;
            flpMonHoc.Dock = DockStyle.Bottom;
            flpMonHoc.Location = new Point(0, 53);
            flpMonHoc.Margin = new Padding(3, 4, 3, 4);
            flpMonHoc.Name = "flpMonHoc";
            flpMonHoc.Size = new Size(1584, 300);
            flpMonHoc.TabIndex = 0;
            flpMonHoc.WrapContents = false;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.BackgroundImageLayout = ImageLayout.None;
            mainPanel.CustomizableEdges = customizableEdges3;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            mainPanel.Size = new Size(1395, 893);
            mainPanel.TabIndex = 22;
            // 
            // UC_MonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2Panel1);
            Controls.Add(label1);
            Controls.Add(mainPanel);
            Margin = new Padding(2, 3, 2, 3);
            Name = "UC_MonHoc";
            Size = new Size(1395, 893);
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private FlowLayoutPanel flpMonHoc;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
    }
}
