public class ExamBox : UserControl
{
    private Label lblTenLop;
    private Label lblThoiGian;
    private Button btnLamBai;

    public ExamBox()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.BackColor = Color.FromArgb(255, 253, 231); // Light yellow background
        this.BorderStyle = BorderStyle.FixedSingle;
        this.Size = new Size(800, 80); // Adjust height to be smaller
        this.Margin = new Padding(0, 0, 0, 10); // Add space between boxes

        // Class Label
        lblTenLop = new Label
        {
            AutoSize = true,
            Location = new Point(15, 15),
            Font = new Font("Segoe UI", 11, FontStyle.Regular)
        };

        // Time Label
        lblThoiGian = new Label
        {
            AutoSize = true,
            Location = new Point(15, 45),
            Font = new Font("Segoe UI", 10),
            ForeColor = Color.Gray
        };

        // Take Exam Button
        btnLamBai = new Button
        {
            Text = "LÀM BÀI",
            BackColor = Color.Red,
            ForeColor = Color.White,
            Size = new Size(80, 30),
            Location = new Point(this.Width - 100, (this.Height - 30) / 2),
            FlatStyle = FlatStyle.Flat
        };
        btnLamBai.FlatAppearance.BorderSize = 0;

        // Add controls
        this.Controls.Add(lblTenLop);
        this.Controls.Add(lblThoiGian);
        this.Controls.Add(btnLamBai);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        if (btnLamBai != null)
        {
            btnLamBai.Location = new Point(this.Width - 100, (this.Height - 30) / 2);
        }
    }

    public string TenLop
    {
        get { return lblTenLop.Text; }
        set { lblTenLop.Text = value; }
    }

    public string ThoiGian
    {
        get { return lblThoiGian.Text; }
        set { lblThoiGian.Text = "Thời gian: " + value; }
    }

    public event EventHandler OnLamBaiClick
    {
        add { btnLamBai.Click += value; }
        remove { btnLamBai.Click -= value; }
    }
}
