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
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text) || cboRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            try
            {
                string user = txtUser.Text.Trim();
                string pass = txtPass.Text.Trim();
                string role = cboRole.SelectedItem.ToString();
                DataTable dt;

                if (role == "Giảng viên")
                {
                    string sql = $"SELECT HoTen, QuyenTruyCap FROM NHANVIEN WHERE TenDangNhap='{user}' AND MatKhau='{pass}'";
                    dt = db.getTable(sql);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string ten = dt.Rows[0]["HoTen"].ToString();
                        string quyen = dt.Rows[0]["QuyenTruyCap"].ToString();

                        MessageBox.Show($"Chào mừng cán bộ: {ten}");
                        this.Hide();
                        // Mở Form Admin
                        FrmMainAdmin adminForm = new FrmMainAdmin(ten, quyen);
                        adminForm.Show();
                    }
                    else { MessageBox.Show("Sai tài khoản hoặc mật khẩu Giảng viên!"); }
                }
                else // Vai trò Sinh viên
                {
                    string sql = $"SELECT HoTen FROM DOCGIA WHERE TenDangNhap='{user}' AND MatKhau='{pass}'";
                    dt = db.getTable(sql);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string ten = dt.Rows[0]["HoTen"].ToString();

                        MessageBox.Show($"Chào bạn sinh viên: {ten}");
                        this.Hide();
                        // Mở Form Sinh viên (frmMainReader)
                        // Lưu ý: Nếu frmMainReader chưa có hàm nhận (ten), hãy tạo thêm cho nó giống FrmMainAdmin
                        frmMainReader readerForm = new frmMainReader(ten);
                        readerForm.Show();
                    }
                    else { MessageBox.Show("Sai tài khoản hoặc mật khẩu Sinh viên!"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
