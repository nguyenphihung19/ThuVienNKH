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
        }

        private void BtnMuonTraSach_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            ucMuonTra uc = new ucMuonTra();
            uc.Dock = DockStyle.Fill;
            panel4.Controls.Add(uc);
            panel4.PerformLayout();
            uc.BringToFront();
        }

        private void BtnTLS_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            ucThanhLySach uc = new ucThanhLySach();
            uc.Dock = DockStyle.Fill;
            panel4.Controls.Add(uc);
            panel4.PerformLayout();
            uc.BringToFront();
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close(); // Đóng form main để quay về login
            }
        }   

        private void BtnQLSV_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            ucQuanLySinhVien uc = new ucQuanLySinhVien();
            uc.Dock = DockStyle.Fill;
            panel4.Controls.Add(uc);
            panel4.PerformLayout();
            uc.BringToFront();
        }
        private void FrmMainAdmin_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị thông tin người dùng lên các Label ở góc trái
            lblHoTen.Text = "Chào: " + hoTenUser;
            lblQuyen.Text = "Quyền: " + quyenUser;

            // 2. PHÂN QUYỀN CHÍNH XÁC:
            // Lưu ý: Chữ "Thủ Thư" và "Quản Trị" phải viết Y CHANG trong Database SQL của bạn
            if (quyenUser == "Thủ Thư")
            {
                // Nếu là Thủ thư: Mở phần thủ thư, Khóa phần Quản trị
                grpLibrarian.Enabled = true;
                grpAdmin.Enabled = false; // Làm mờ, không cho ấn, không cho bấm

                // Bạn có thể thông báo nhỏ ở Label nếu muốn
                lblQuyen.ForeColor = Color.OrangeRed;
            }
            else if (quyenUser == "Quản Trị")
            {
                // Nếu là Quản trị: Mở hết toàn bộ
                grpAdmin.Enabled = true;
                grpLibrarian.Enabled = true;

                lblQuyen.ForeColor = Color.Blue;
            }
        }

        private void BtnQLS_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            ucQuanLySach uc = new ucQuanLySach();
            uc.Dock = DockStyle.Fill;
            panel4.Controls.Add(uc);
            panel4.PerformLayout();
            uc.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnQLNV_Click(object sender, EventArgs e)
        {
            // 1. Xóa nội dung cũ trong panel
            panel4.Controls.Clear();

            // 2. Gọi cái UC mới tạo
            ucQuanLyNhanVien uc = new ucQuanLyNhanVien();

            // 3. Thiết lập để nó nở to ra hết cỡ
            uc.Dock = DockStyle.Fill;

            // 4. Dán vào và hiển thị
            panel4.Controls.Add(uc);
            panel4.PerformLayout(); // Ép nó tính toán lại kích thước
            uc.BringToFront();
        }

        private void BtnQLTK_Click(object sender, EventArgs e)
        {
            // 1. Xóa nội dung cũ trong panel
            panel4.Controls.Clear();

            // 2. Gọi cái UC mới tạo
            ucQuanLyTaiKhoan uc = new ucQuanLyTaiKhoan();

            // 3. Thiết lập để nó nở to ra hết cỡ
            uc.Dock = DockStyle.Fill;

            // 4. Dán vào và hiển thị
            panel4.Controls.Add(uc);
            panel4.PerformLayout(); // Ép nó tính toán lại kích thước
            uc.BringToFront();
        }

        private void BtnCDQD_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();

            // 2. Gọi cái UC mới tạo
            ucCaiDatQuyDinh uc = new ucCaiDatQuyDinh();

            // 3. Thiết lập để nó nở to ra hết cỡ
            uc.Dock = DockStyle.Fill;

            // 4. Dán vào và hiển thị
            panel4.Controls.Add(uc);
            panel4.PerformLayout(); // Ép nó tính toán lại kích thước
            uc.BringToFront();
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            ucThongKeBaoCao uc = new ucThongKeBaoCao();
            uc.Dock = DockStyle.Fill;
            panel4.Controls.Add(uc);
            panel4.PerformLayout();
            uc.BringToFront();
        }
    }
}
