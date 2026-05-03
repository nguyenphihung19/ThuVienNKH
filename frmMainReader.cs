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
        DBConnect db = new DBConnect();

        public frmMainReader()
        {
            InitializeComponent();
        }

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

            // --- CHỖ CẦN THÊM: GỌI HÀM LOAD DỮ LIỆU ---
            // Vì ông đã lưu Mã Độc Giả vào Session ở Form Login, 
            // nên giờ chỉ cần lấy ra và nạp vào UserControl thôi.
            if (!string.IsNullOrEmpty(Session.MaDocGia))
            {
                uc.LoadData(Session.MaDocGia);
            }
            else
            {
                MessageBox.Show("Lỗi: Không tìm thấy Mã Độc Giả trong Session!");
            }
            // -----------------------------------------

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

        private void LoadNoiQuyHeThong()
        {
            try
            {
                string sql = "SELECT TenQD, GiaTri FROM QUYDINH";
                DataTable dt = db.getTable(sql);

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

        // Các hàm sự kiện giữ nguyên
        private void GbNoiQuy_Enter(object sender, EventArgs e) { }
        private void lblNoiQuy_Click(object sender, EventArgs e) { }
        private void LoadNoiQuy() { }
    }
}