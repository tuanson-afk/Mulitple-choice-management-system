namespace QTV.Usercontrol
{
    partial class UC_QLLHP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QLLHP));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dataGridView1 = new DataGridView();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 240);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1802, 812);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 6;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(64, 64, 128);
            guna2Button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Image = (Image)resources.GetObject("guna2Button1.Image");
            guna2Button1.ImageOffset = new Point(-5, 0);
            guna2Button1.Location = new Point(1695, 185);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(147, 49);
            guna2Button1.TabIndex = 16;
            guna2Button1.Text = "THÊM";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(64, 64, 128);
            guna2HtmlLabel1.Location = new Point(40, 21);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(227, 39);
            guna2HtmlLabel1.TabIndex = 17;
            guna2HtmlLabel1.Text = "Các Lớp học phần";
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 6;
            guna2Button2.CustomizableEdges = customizableEdges3;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.Firebrick;
            guna2Button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Image = (Image)resources.GetObject("guna2Button2.Image");
            guna2Button2.ImageOffset = new Point(-2, 0);
            guna2Button2.Location = new Point(1512, 185);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button2.Size = new Size(147, 49);
            guna2Button2.TabIndex = 18;
            guna2Button2.Text = "CẬP NHẬT";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(865, 195);
            button1.Name = "button1";
            button1.Size = new Size(135, 39);
            button1.TabIndex = 23;
            button1.Text = "Tải dữ liệu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // UC_QLLHP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(guna2Button2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(guna2Button1);
            Controls.Add(dataGridView1);
            Name = "UC_QLLHP";
            Size = new Size(1920, 1080);
            Load += UC_QLLHP_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Button button1;
    }
}
