using System.Windows.Forms;

namespace BCTK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tạo cột "Mã sinh viên"
            DataGridViewTextBoxColumn STTColumn = new DataGridViewTextBoxColumn();
            STTColumn.HeaderText = "STT";
            STTColumn.Name = "STTColumn";
            // Tạo cột "Họ và tên"
            DataGridViewTextBoxColumn MSVColumn = new DataGridViewTextBoxColumn();
            MSVColumn.HeaderText = "Mã sinh viên";
            MSVColumn.Name = "MSVColumn";
            // Tạo cột "Email"
            DataGridViewTextBoxColumn HTColumn = new DataGridViewTextBoxColumn();
            HTColumn.HeaderText = "Họ và tên";
            HTColumn.Name = "HTColumn";

            DataGridViewTextBoxColumn TGColumn = new DataGridViewTextBoxColumn();
            TGColumn.HeaderText = "Thời gian làm bài";
            TGColumn.Name = "TGColumn";
            DataGridViewTextBoxColumn DColumn = new DataGridViewTextBoxColumn();
            DColumn.HeaderText = "Điểm";
            DColumn.Name = "TGColumn";
            // Thêm các cột vào DataGridView
            dataGridView1.Columns.Add(STTColumn);
            dataGridView1.Columns.Add(MSVColumn);
            dataGridView1.Columns.Add(HTColumn);
            dataGridView1.Columns.Add(TGColumn);
            dataGridView1.Columns.Add(DColumn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Roman", 9, FontStyle.Bold);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
