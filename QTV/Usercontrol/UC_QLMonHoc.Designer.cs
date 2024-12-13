namespace QTV.Usercontrol
{
    partial class UC_QLMonHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QLMonHoc));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            button1 = new Button();
            txthotensv = new TextBox();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            label4 = new Label();
            txtmasv = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(865, 377);
            button1.Margin = new Padding(3, 5, 3, 5);
            button1.Name = "button1";
            button1.Size = new Size(122, 47);
            button1.TabIndex = 34;
            button1.Text = "Tải dữ liệu";
            button1.UseVisualStyleBackColor = false;
            // 
            // txthotensv
            // 
            txthotensv.Font = new Font("Segoe UI", 12F);
            txthotensv.Location = new Point(1146, 157);
            txthotensv.Margin = new Padding(3, 5, 3, 5);
            txthotensv.Name = "txthotensv";
            txthotensv.Size = new Size(323, 34);
            txthotensv.TabIndex = 28;
            txthotensv.TextChanged += txthotensv_TextChanged;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderRadius = 6;
            guna2Button2.CustomizableEdges = customizableEdges1;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(64, 64, 128);
            guna2Button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Image = (Image)resources.GetObject("guna2Button2.Image");
            guna2Button2.ImageOffset = new Point(-5, 0);
            guna2Button2.Location = new Point(840, 276);
            guna2Button2.Margin = new Padding(3, 5, 3, 5);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button2.Size = new Size(168, 65);
            guna2Button2.TabIndex = 32;
            guna2Button2.Text = "LƯU";
            guna2Button2.Click += guna2Button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(950, 157);
            label4.Name = "label4";
            label4.Size = new Size(107, 31);
            label4.TabIndex = 26;
            label4.Text = "Tên Môn";
            // 
            // txtmasv
            // 
            txtmasv.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtmasv.Location = new Point(454, 157);
            txtmasv.Margin = new Padding(3, 5, 3, 5);
            txtmasv.Name = "txtmasv";
            txtmasv.Size = new Size(323, 34);
            txtmasv.TabIndex = 27;
            txtmasv.TextChanged += txtmasv_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(94, 453);
            dataGridView1.Margin = new Padding(3, 5, 3, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1656, 665);
            dataGridView1.TabIndex = 29;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(257, 157);
            label2.Name = "label2";
            label2.Size = new Size(104, 31);
            label2.TabIndex = 23;
            label2.Text = "Mã Môn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 128);
            label1.Location = new Point(21, 29);
            label1.Name = "label1";
            label1.Size = new Size(324, 50);
            label1.TabIndex = 24;
            label1.Text = "Quản lý Môn Học";
            // 
            // UC_QLMonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(txthotensv);
            Controls.Add(guna2Button2);
            Controls.Add(label4);
            Controls.Add(txtmasv);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_QLMonHoc";
            Size = new Size(2230, 1259);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txthotensv;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Label label4;
        private TextBox txtmasv;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
    }
}
