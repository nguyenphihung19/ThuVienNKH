using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class FrmMainAdmin : Form
    {
        string hoTenUser = "";
        string quyenUser = "";
        public FrmMainAdmin()
        {
            InitializeComponent();
        }

        public FrmMainAdmin(string ten, string quyen)
        {
            InitializeComponent();
            this.hoTenUser = ten;
            this.quyenUser = quyen;

            // Hiển thị lên Label ngay khi khởi tạo
            lblHoTen.Text = "Họ tên: " + hoTenUser;
            lblQuyen.Text = "Quyền: " + quyenUser;
        }

        private void BtnMuonTraSach_Click(object sender, EventArgs e)
        {

        }

        private void BtnTLS_Click(object sender, EventArgs e)
        {

        }

        private void BtnTkBc_Click(object sender, EventArgs e)
        {

        }

        private void BtnQLSV_Click(object sender, EventArgs e)
        {

        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {

        }

        private void FrmMainAdmin_Load(object sender, EventArgs e)
        {
            lblHoTen.Text = hoTenUser;
            lblQuyen.Text = quyenUser;

            // PHÂN QUYỀN: Nếu là Sinh viên thì ẩn bớt nút đi
            if (quyenUser == "SinhVien")
            {
                BtnQLNV.Visible = false;
                BtnCDQD.Visible = false;
                BtnTLS.Enabled = false; // Vô hiệu hóa nút

                // Có thể đổi màu nền để phân biệt
                panel3.BackColor = Color.LightCyan;
            }
            else if (quyenUser == "Admin" || quyenUser == "Giảng viên")
            {
                // Admin thì hiện hết
                BtnQLNV.Visible = true;
            }
        }
    }
}
