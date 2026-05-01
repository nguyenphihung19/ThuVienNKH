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
    public partial class ucDoiMatKhau : UserControl
    {
        DBConnect db = new DBConnect();
        public ucDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // SỬA CHỖ NÀY: Dùng LEFT JOIN cho cả 2 bảng và ISNULL để kiểm tra số điện thoại
                // Dù là Độc giả hay Nhân viên thì đều lấy được SĐT để đối chiếu
                string sql = $@"SELECT T.MaTaiKhoan 
                                FROM TAIKHOAN T 
                                LEFT JOIN DOCGIA D ON T.MaTaiKhoan = D.MaTaiKhoan 
                                LEFT JOIN NHANVIEN N ON T.MaTaiKhoan = N.MaTaiKhoan 
                                WHERE T.TenDangNhap = '{txtTenDN.Text.Trim()}' 
                                AND (D.SoDT = '{txtSDT.Text.Trim()}' OR N.SoDT = '{txtSDT.Text.Trim()}')";

                DataTable dt = db.getTable(sql);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Thông tin chính xác! Vui lòng nhập mật khẩu mới.");
                    txtMatKhauMoi.Enabled = true;
                    txtXacNhanMK.Enabled = true;
                    btnDoiMatKhau.Enabled = true;

                    // Khóa luôn 2 ô nhập thông tin cũ để người dùng không sửa lung tung lúc đang đổi MK
                    txtTenDN.Enabled = false;
                    txtSDT.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Thông tin không khớp với hệ thống!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                return;
            }

            if (txtMatKhauMoi.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            try
            {
                string sqlUpdate = $@"UPDATE TAIKHOAN 
                                     SET MatKhau = '{txtMatKhauMoi.Text.Trim()}' 
                                     WHERE TenDangNhap = '{txtTenDN.Text.Trim()}'";

                if (db.update(sqlUpdate) > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công! Hãy đăng nhập lại.");
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }
    }
}
