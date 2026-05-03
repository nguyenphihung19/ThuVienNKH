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
    public partial class frmMainReader : Form
    {
        string hoTenUser = "";
        string quyenUser = "";

        public frmMainReader()
        {
            InitializeComponent();
        }

        // Hàm nhận tên và quyền từ Form Login truyền sang
        public frmMainReader(string ten, string quyen)
        {
            InitializeComponent();
            this.hoTenUser = ten;
            this.quyenUser = quyen;

            lblHoTenReader.Text = "Độc giả: " + hoTenUser;
            lblQuyenReader.Text = "Đối tượng: " + quyenUser;
            LoadNoiQuyHeThong();
        }

        private void BtnTraCuu_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            ucTraCuuSach uc = new ucTraCuuSach();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            pnlContent.PerformLayout();
            uc.BringToFront();
        }

        private void BtnCaNhan_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            ucTheoDoiCaNhan uc = new ucTheoDoiCaNhan();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            pnlContent.PerformLayout();
            uc.BringToFront();
        }

        private void BtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            ucDoiMatKhau uc = new ucDoiMatKhau();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            pnlContent.PerformLayout();
            uc.BringToFront();
        }

        private void BtnDangXuat_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmMainReader_Load(object sender, EventArgs e)
        {
            LoadNoiQuyHeThong();
        }

        private void GbNoiQuy_Enter(object sender, EventArgs e)
        {
            // Sự kiện của GroupBox
        }

        private void lblNoiQuy_Click(object sender, EventArgs e)
        {

        }
        // Khai báo kết nối (đặt dưới chỗ hoTenUser)
        DBConnect db = new DBConnect();

        private void LoadNoiQuyHeThong()
        {
            try
            {
                // 1. Lấy dữ liệu từ bảng QUYDINH
                string sql = "SELECT TenQD, GiaTri FROM QUYDINH";
                DataTable dt = db.getTable(sql);

                // 2. Kiểm tra xem có dòng nào không
                if (dt != null && dt.Rows.Count > 0)
                {
                    string chuoiNoiQuy = "📜 QUY ĐỊNH THƯ VIỆN:\n\n";
                    foreach (DataRow r in dt.Rows)
                    {
                        chuoiNoiQuy += $"• {r["TenQD"]}: {r["GiaTri"]}\n\n";
                    }
                    lblNoiQuy.Text = chuoiNoiQuy;
                }
                else
                {
                    lblNoiQuy.Text = "Hệ thống chưa cập nhật nội quy.";
                }
            }
            catch (Exception ex)
            {
                lblNoiQuy.Text = "Lỗi kết nối nội quy!";
            }
        }
        private void LoadNoiQuy()
        {
            try
            {
                // Lấy TenQD để hiển thị cho độc giả thấy chữ, thay vì chỉ lấy MaQD
                string query = "SELECT TenQD, GiaTri FROM QUYDINH";
                DataTable dt = db.getTable(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string content = "📜 NỘI QUY THƯ VIỆN:\n\n";
                    foreach (DataRow row in dt.Rows)
                    {
                        content += $"• {row["TenQD"]}: {row["GiaTri"]}\n";
                    }
                    lblNoiQuy.Text = content;
                }
            }
            catch
            {
                lblNoiQuy.Text = "Không thể tải nội quy.";
            }
        }
    }
}