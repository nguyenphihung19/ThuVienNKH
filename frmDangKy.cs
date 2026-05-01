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
    public partial class frmDangKy : Form
    {
        DBConnect db = new DBConnect();

        public frmDangKy()
        {
            InitializeComponent();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra không được để trống
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtTenDangNhap.Text) ||
                string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả thông tin!");
                return;
            }

            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            try
            {
                // 2. Kiểm tra trùng tên đăng nhập
                string sqlCheck = $"SELECT * FROM TAIKHOAN WHERE TenDangNhap = '{txtTenDangNhap.Text.Trim()}'";
                DataTable dtCheck = db.getTable(sqlCheck);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show("Tên đăng nhập này đã có người sử dụng!");
                    return;
                }

                // 3. Thêm vào bảng TAIKHOAN - Mặc định là 'Khách'
                // Tui thêm cái Email giả dựa theo tên đăng nhập để tránh lỗi UNIQUE KEY bị NULL
                string emailGia = txtTenDangNhap.Text.Trim() + "@gmail.com";
                string sqlTK = string.Format("INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, QuyenTruyCap, Email) VALUES ('{0}', '{1}', N'Khách', '{2}')",
                                 txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim(), emailGia);
                db.update(sqlTK);

                // 4. Lấy MaTaiKhoan vừa sinh ra
                string sqlGetID = "SELECT MAX(MaTaiKhoan) FROM TAIKHOAN";
                DataTable dtID = db.getTable(sqlGetID);
                string maTKHienTai = dtID.Rows[0][0].ToString();

                // 5. Thêm vào bảng DOCGIA - Đồng bộ toàn bộ là 'Khách'
                // Khớp chính xác các cột SoDT, LoaiDG, QuyenTruyCap
                string sqlDG = string.Format(
                    "INSERT INTO DOCGIA (MaDG, HoTen, SoDT, MaTaiKhoan, LoaiDG, QuyenTruyCap) " +
                    "VALUES ('DG{0}', N'{1}', '{2}', {0}, N'Khách', N'Khách')",
                    maTKHienTai, txtHoTen.Text.Trim(), txtSDT.Text.Trim());

                if (db.update(sqlDG) > 0)
                {
                    MessageBox.Show("Chúc mừng Kamon! Đăng ký tài khoản Khách thành công.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Hiện lỗi chi tiết để Kamon dễ debug
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}