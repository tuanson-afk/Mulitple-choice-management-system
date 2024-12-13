namespace QTV.Usercontrol
{
    partial class UC_Quanlysinhvien
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Quanlysinhvien));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            txtemail = new TextBox();
            txthotensv = new TextBox();
            txtmasv = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 128);
            label1.Location = new Point(20, 23);
            label1.Name = "label1";
            label1.Size = new Size(321, 50);
            label1.TabIndex = 0;
            label1.Text = "Thông tin chi tiết";
            // 
            // txtemail
            // 
            txtemail.Font = new Font("Segoe UI", 12F);
            txtemail.Location = new Point(1055, 104);
            txtemail.Margin = new Padding(3, 4, 3, 4);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(283, 34);
            txtemail.TabIndex = 5;
            txtemail.TextChanged += txtemail_TextChanged;
            // 
            // txthotensv
            // 
            txthotensv.Font = new Font("Segoe UI", 12F);
            txthotensv.Location = new Point(419, 212);
            txthotensv.Margin = new Padding(3, 4, 3, 4);
            txthotensv.Name = "txthotensv";
            txthotensv.Size = new Size(283, 34);
            txthotensv.TabIndex = 4;
            txthotensv.TextChanged += txthotensv_TextChanged;
            // 
            // txtmasv
            // 
            txtmasv.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtmasv.Location = new Point(419, 104);
            txtmasv.Margin = new Padding(3, 4, 3, 4);
            txtmasv.Name = "txtmasv";
            txtmasv.Size = new Size(283, 34);
            txtmasv.TabIndex = 3;
            txtmasv.TextChanged += txtmasv_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(247, 212);
            label4.Name = "label4";
            label4.Size = new Size(117, 31);
            label4.TabIndex = 2;
            label4.Text = "Họ và tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(950, 104);
            label3.Name = "label3";
            label3.Size = new Size(73, 31);
            label3.TabIndex = 1;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(247, 104);
            label2.Name = "label2";
            label2.Size = new Size(150, 31);
            label2.TabIndex = 0;
            label2.Text = "Mã sinh viên";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(84, 397);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1755, 443);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // guna2Button3
            // 
            guna2Button3.BorderRadius = 6;
            guna2Button3.CustomizableEdges = customizableEdges7;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.ForestGreen;
            guna2Button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button3.ForeColor = Color.White;
            guna2Button3.Image = (Image)resources.GetObject("guna2Button3.Image");
            guna2Button3.ImageOffset = new Point(-3, 0);
            guna2Button3.Location = new Point(555, 278);
            guna2Button3.Margin = new Padding(3, 4, 3, 4);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button3.Size = new Size(147, 49);
            guna2Button3.TabIndex = 21;
            guna2Button3.Text = "Xuất Excel";
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 6;
            guna2Button2.CustomizableEdges = customizableEdges9;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(64, 64, 128);
            guna2Button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Image = (Image)resources.GetObject("guna2Button2.Image");
            guna2Button2.ImageOffset = new Point(-8, 0);
            guna2Button2.Location = new Point(875, 278);
            guna2Button2.Margin = new Padding(3, 4, 3, 4);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Button2.Size = new Size(147, 49);
            guna2Button2.TabIndex = 20;
            guna2Button2.Text = "Thêm";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 6;
            guna2Button1.CustomizableEdges = customizableEdges11;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Firebrick;
            guna2Button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Image = (Image)resources.GetObject("guna2Button1.Image");
            guna2Button1.ImageOffset = new Point(-3, 0);
            guna2Button1.Location = new Point(1191, 278);
            guna2Button1.Margin = new Padding(3, 4, 3, 4);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Button1.Size = new Size(147, 49);
            guna2Button1.TabIndex = 19;
            guna2Button1.Text = "Chỉnh sửa";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(891, 347);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(117, 42);
            button1.TabIndex = 22;
            button1.Text = "Tải dữ liệu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // UC_Quanlysinhvien
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button1);
            Controls.Add(txtemail);
            Controls.Add(guna2Button3);
            Controls.Add(label3);
            Controls.Add(txthotensv);
            Controls.Add(guna2Button2);
            Controls.Add(label4);
            Controls.Add(txtmasv);
            Controls.Add(guna2Button1);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UC_Quanlysinhvien";
            Size = new Size(1920, 1080);
            Load += UC_Quanlysinhvien_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtemail;
        private TextBox txthotensv;
        private TextBox txtmasv;
        private DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Button button1;
    }
}
