using QL_Trac_Nghiem.UserControls;
using QTV.Models;
using QTV.Usercontrol.giangVien;
using QTV.Views.General;
using QuanLyTracNghiem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Trac_Nghiem
{
    public partial class frmMonHoc : Form
    {
        private Guna.UI2.WinForms.Guna2Button selectedButton = null;

        private Stack<UserControl> controlStackMonHoc = new Stack<UserControl>();

        public frmMonHoc()
        {
            InitializeComponent();
            UC_MonHoc uc = new UC_MonHoc();
            addUserControl(uc);
            //ShowUCMonHoc();
            SelectTab(btnMonHoc, borderMonHoc);
        }

        private void ShowUserControl<T>(T userControl, Action<T> setupEvents = null) where T : UserControl
        {
            // Lưu `UserControl` hiện tại vào stack
            if (panelContainer.Controls.Count > 0)
            {
                var currentControl = panelContainer.Controls[0] as UserControl;
                if (currentControl != null)
                    controlStackMonHoc.Push(currentControl);
            }

            // Cấu hình các sự kiện nếu cần
            setupEvents?.Invoke(userControl);

            // Hiển thị UserControl mới
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();
        }

        private void GoBack()
        {
            if (controlStackMonHoc.Count > 0)
            {
                // Lấy UserControl trước đó từ Stack
                var previousControl = controlStackMonHoc.Pop();
                panelContainer.Controls.Clear();
                panelContainer.Controls.Add(previousControl);
                previousControl.BringToFront();
            }
            else
            {
                MessageBox.Show("Không còn màn hình để quay lại.", "Thông báo");
            }
        }
        private void ShowUCMonHoc()
        {
            var ucMonHoc = new UC_MonHoc();
            ShowUserControl(ucMonHoc, control =>
            {
                // control.ItemClicked += (monHoc) => ShowUcMonHocCuThe(monHoc);
            });
        }
        private void ShowUcMonHocCuThe(MonHoc monHoc)
        {
            var ucDetail = new UcMonHocCuThe(monHoc);
            ShowUserControl(ucDetail, control =>
            {
                // control.BackClicked += GoBack;
                //control.DeThiClicked += (deThi) => ShowUcDeThiCuThe(deThi);
                //control.HPClicked += (hocPhan) => ShowUcHPCuThe(hocPhan);
            });
        }
        private void ShowUcDeThiCuThe(DeThi deThi)
        {
            //var ucDeThi = new UcDeThiCuThe(deThi);
            //ShowUserControl(ucDeThi, control =>
            //{
            //    control.BackClicked += GoBack;
            //});
        }
        private void ShowUcHPCuThe(LopHP lopHP)
        {
            //var ucHPCuThe = new UcHPCuThe(hocPhan);
            //ShowUserControl(ucHPCuThe, control =>
            //{
            //    control.BackClicked += GoBack;
            //});
        }




        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void SelectTab(Guna.UI2.WinForms.Guna2Button btn, Guna.UI2.WinForms.Guna2Panel panel)
        {
            ResetTabs(); // Đặt lại trạng thái cho tất cả các nút

            // Đổi màu chữ của nút được chọn
            btn.ForeColor = ColorTranslator.FromHtml("#395A7F"); // Màu xanh đậm

            // Hiển thị border của nút được chọn
            panel.Visible = true;

            // Lưu nút đang được chọn
            selectedButton = btn;
        }

        private void ResetTabs()
        {
            // Đặt lại trạng thái cho tất cả các nút
            btnMonHoc.ForeColor = ColorTranslator.FromHtml("#ACACAC"); // Màu xám
            btnBaoCao.ForeColor = ColorTranslator.FromHtml("#ACACAC");

            // Ẩn tất cả các border
            borderMonHoc.Visible = false;
            borderBaoCao.Visible = false;
        }

        private void frmMonHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi đóng form
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi màn hình này và quay lại trang phân quyền không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Hủy việc đóng form
                e.Cancel = true;
                return;
            }

            // Nếu người dùng xác nhận, mở form phân quyền
            frmPhanquyen phanquyen = new frmPhanquyen();
            phanquyen.Show();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            container.Left = (guna2ShadowPanel2.Width - container.Width) / 2;
            container.Top = container.Top;

            //container.Left = (this.ClientSize.Width - container.Width) / 2;
            //container.Top = container.Top;
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            UC_MonHoc uc = new UC_MonHoc();
            addUserControl(uc);
            SelectTab(btnMonHoc, borderMonHoc);
            loadingBox.Close();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            UC_BaoCao uc = new UC_BaoCao();
            addUserControl(uc);
            SelectTab(btnBaoCao, borderBaoCao);
            loadingBox.Close();
        }

        private void btnMonHoc_MouseHover(object sender, EventArgs e)
        {
            btnMonHoc.ForeColor = ColorTranslator.FromHtml("#404080");
        }

        private void btnBaoCao_MouseHover_1(object sender, EventArgs e)
        {
            btnBaoCao.ForeColor = ColorTranslator.FromHtml("#404080");
        }

        private void btnMonHoc_MouseEnter(object sender, EventArgs e)
        {
            btnMonHoc.ForeColor = ColorTranslator.FromHtml("#404080");
        }
    }
}
