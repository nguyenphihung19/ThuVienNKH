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
    public partial class frmLogin : Form
    {
        DBConnect db = new DBConnect();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect db = new DBConnect();
                string user = txtUser.Text.Trim();
                string pass = txtPass.Text.Trim();

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
                    return;
                }

                // Dùng ISNULL để ưu tiên lấy HoTen từ NHANVIEN, nếu không có thì lấy từ DOCGIA
                // Kết nối 3 bảng thông qua MaTaiKhoan
                string sql = $@"SELECT T.QuyenTruyCap, 
                               ISNULL(N.HoTen, D.HoTen) AS HoTenResult
                        FROM TAIKHOAN T 
                        LEFT JOIN NHANVIEN N ON T.MaTaiKhoan = N.MaTaiKhoan 
                        LEFT JOIN DOCGIA D ON T.MaTaiKhoan = D.MaTaiKhoan
                        WHERE T.TenDangNhap = '{user}' AND T.MatKhau = '{pass}'";

                DataTable dt = db.getTable(sql);

                if (dt.Rows.Count > 0)
                {
                    string hoTen = dt.Rows[0]["HoTenResult"].ToString();
                    string quyen = dt.Rows[0]["QuyenTruyCap"].ToString();

                    // Trường hợp cả 2 bảng đều chưa điền tên thật
                    if (string.IsNullOrEmpty(hoTen)) hoTen = user;

                    MessageBox.Show($"Đăng nhập thành công! Chào {hoTen}");

                    if (quyen == "Quản Trị" || quyen == "Thủ Thư")
                    {
                        FrmMainAdmin fAdmin = new FrmMainAdmin(hoTen, quyen);
                        this.Hide();
                        fAdmin.ShowDialog();
                        this.Show();
                    }
                    else // Sinh Viên, Giảng Viên, Khách...
                    {
                        frmMainReader fReader = new frmMainReader(hoTen, quyen);
                        this.Hide();
                        fReader.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close(); // Hoặc Application.Exit();
            }
        }

        private void BtnQuenMatKhau_Click(object sender, EventArgs e)
        {
            frmQuenMatKhau f = new frmQuenMatKhau();
            f.ShowDialog();
        }

        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy f = new frmDangKy();
            f.ShowDialog();
        }
    }
}
