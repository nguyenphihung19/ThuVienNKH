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
                string user = txtUser.Text.Trim();
                string pass = txtPass.Text.Trim();

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
                    return;
                }

                // SỬA SQL: Dùng đúng tên cột là MaDG
                string sql = $@"SELECT T.QuyenTruyCap, 
                               ISNULL(N.HoTen, D.HoTen) AS HoTenResult,
                               N.MaNV,
                               D.MaDG -- Đã sửa từ MaDocGia thành MaDG
                        FROM TAIKHOAN T 
                        LEFT JOIN NHANVIEN N ON T.MaTaiKhoan = N.MaTaiKhoan
                        LEFT JOIN DOCGIA D ON T.MaTaiKhoan = D.MaTaiKhoan
                        WHERE T.TenDangNhap = '{user}' AND T.MatKhau = '{pass}'";

                DataTable dt = db.getTable(sql);

                if (dt.Rows.Count > 0)
                {
                    // Cập nhật Session
                    Session.TenDangNhap = user;
                    Session.HoTen = dt.Rows[0]["HoTenResult"].ToString();
                    Session.Quyen = dt.Rows[0]["QuyenTruyCap"].ToString();

                    // Gán mã tương ứng
                    Session.MaNV = dt.Rows[0]["MaNV"] != DBNull.Value ? dt.Rows[0]["MaNV"].ToString() : "";

                    // SỬA TÊN CỘT Ở ĐÂY: Dùng MaDG thay vì MaDocGia
                    Session.MaDocGia = dt.Rows[0]["MaDG"] != DBNull.Value ? dt.Rows[0]["MaDG"].ToString() : "";

                    MessageBox.Show($"Đăng nhập thành công! Chào {Session.HoTen}");

                    // Điều hướng form
                    if (Session.Quyen == "Quản Trị" || Session.Quyen == "Thủ Thư")
                    {
                        FrmMainAdmin fAdmin = new FrmMainAdmin(Session.HoTen, Session.Quyen);
                        this.Hide();
                        fAdmin.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        frmMainReader fReader = new frmMainReader(Session.HoTen, Session.Quyen);
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


        // Các hàm sự kiện khác giữ nguyên
        private void cboRole_SelectedIndexChanged(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void txtUser_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
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