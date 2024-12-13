namespace QTV.Usercontrol
{
    partial class UC_Quanlygiang_vien
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Quanlygiang_vien));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dataGridView1 = new DataGridView();
            txtemail = new TextBox();
            txthotengv = new TextBox();
            txtmagv = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(84, 397);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = Color.OrangeRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1755, 443);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtemail
            // 
            txtemail.Location = new Point(1054, 95);
            txtemail.Multiline = true;
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(283, 34);
            txtemail.TabIndex = 5;
            // 
            // txthotengv
            // 
            txthotengv.Location = new Point(419, 212);
            txthotengv.Multiline = true;
            txthotengv.Name = "txthotengv";
            txthotengv.Size = new Size(283, 34);
            txthotengv.TabIndex = 4;
            // 
            // txtmagv
            // 
            txtmagv.Location = new Point(419, 95);
            txtmagv.Multiline = true;
            txtmagv.Name = "txtmagv";
            txtmagv.Size = new Size(283, 34);
            txtmagv.TabIndex = 3;
            txtmagv.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(247, 212);
            label4.Name = "label4";
            label4.Size = new Size(117, 31);
            label4.TabIndex = 2;
            label4.Text = "Họ và tên";
            label4.Click += label4_Click;
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
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(247, 104);
            label2.Name = "label2";
            label2.Size = new Size(166, 31);
            label2.TabIndex = 0;
            label2.Text = "Mã giảng viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 128);
            label1.Location = new Point(20, 23);
            label1.Name = "label1";
            label1.Size = new Size(321, 50);
            label1.TabIndex = 5;
            label1.Text = "Thông tin chi tiết";
            label1.Click += label1_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 6;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Firebrick;
            guna2Button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Image = (Image)resources.GetObject("guna2Button1.Image");
            guna2Button1.ImageOffset = new Point(-2, 0);
            guna2Button1.Location = new Point(1145, 278);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(147, 49);
            guna2Button1.TabIndex = 16;
            guna2Button1.Text = "Cập nhật";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 6;
            guna2Button2.CustomizableEdges = customizableEdges3;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(64, 64, 128);
            guna2Button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Image = (Image)resources.GetObject("guna2Button2.Image");
            guna2Button2.ImageOffset = new Point(-3, 0);
            guna2Button2.Location = new Point(875, 278);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button2.Size = new Size(147, 49);
            guna2Button2.TabIndex = 17;
            guna2Button2.Text = "Thêm";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // guna2Button3
            // 
            guna2Button3.BorderRadius = 6;
            guna2Button3.CustomizableEdges = customizableEdges5;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.ForestGreen;
            guna2Button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button3.ForeColor = Color.White;
            guna2Button3.Image = (Image)resources.GetObject("guna2Button3.Image");
            guna2Button3.ImageOffset = new Point(-1, 0);
            guna2Button3.Location = new Point(555, 278);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button3.Size = new Size(147, 49);
            guna2Button3.TabIndex = 18;
            guna2Button3.Text = "Xuất Excel";
            guna2Button3.Click += guna2Button3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(893, 356);
            button1.Name = "button1";
            button1.Size = new Size(107, 35);
            button1.TabIndex = 19;
            button1.Text = "Tải dữ liệu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // UC_Quanlygiang_vien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtemail);
            Controls.Add(button1);
            Controls.Add(txthotengv);
            Controls.Add(guna2Button3);
            Controls.Add(txtmagv);
            Controls.Add(guna2Button2);
            Controls.Add(label4);
            Controls.Add(guna2Button1);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UC_Quanlygiang_vien";
            Size = new Size(1920, 1080);
            Load += UC_Quanlygiang_vien_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtemail;
        private TextBox txthotengv;
        private TextBox txtmagv;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Button button1;
    }
}
