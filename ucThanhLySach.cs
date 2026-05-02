using System;
using System.Data;
using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class ucThanhLySach : UserControl
    {
        DBConnect db = new DBConnect();

        public ucThanhLySach()
        {
            InitializeComponent();
            this.Load += ucThanhLySach_Load;
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvThanhLy.CellClick += dgvThanhLy_CellClick;
            txtMaSach.Leave += txtMaSach_Leave;
        }

        private void ucThanhLySach_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = Session.MaNV;
            txtMaNV.Enabled = false;
            txtTenSach.ReadOnly = true;
            txtTinhTrang.ReadOnly = true;
            LoadHistoryFromSQL();
            txtMaPhieu.Text = "PTL" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dgvThanhLy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtMaSach_Leave(object sender, EventArgs e)
        {
            string maS = txtMaSach.Text.Trim();
            if (string.IsNullOrEmpty(maS)) return;

            string sql = $@"SELECT d.TenDauSach, s.TinhTrang FROM SACH s 
                           JOIN DAUSACH d ON s.MaDauSach = d.MaDauSach WHERE s.MaSach = '{maS}'";
            DataTable dt = db.getTable(sql);
            if (dt.Rows.Count > 0)
            {
                txtTenSach.Text = dt.Rows[0]["TenDauSach"].ToString();
                txtTinhTrang.Text = dt.Rows[0]["TinhTrang"].ToString();
            }
        }

        private void LoadHistoryFromSQL()
        {
            try
            {
                // Truy vấn lấy dữ liệu. Nếu chưa có cột TrangThaiThanhLy, 
                // bạn có thể tạm thời xóa tên cột đó trong dòng SELECT này để chạy trước
                string sql = @"SELECT ct.MaPhieuTL, t.NgayTL, ct.MaSach, d.TenDauSach, s.TinhTrang, ct.LyDoTL, ct.TrangThaiThanhLy 
                       FROM CHITIETTHANHLY ct 
                       LEFT JOIN THANHLY t ON ct.MaPhieuTL = t.MaPhieuTL
                       LEFT JOIN SACH s ON ct.MaSach = s.MaSach
                       LEFT JOIN DAUSACH d ON s.MaDauSach = d.MaDauSach";

                DataTable dt = db.getTable(sql);
                dgvThanhLy.DataSource = dt; // Đảm bảo gán lại DataSource sau khi lấy bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lưới: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sách!");
                return;
            }

            string maS = txtMaSach.Text.Trim();

            // SỬ DỤNG HÀM getScalar CỦA BẠN ĐỂ KIỂM TRA TRÙNG
            string checkSql = $"SELECT COUNT(*) FROM CHITIETTHANHLY WHERE MaSach = '{maS}'";
            object result = db.getScalar(checkSql);

            // Chuyển đổi result sang int để so sánh
            int count = (result != null) ? Convert.ToInt32(result) : 0;

            if (count > 0)
            {
                MessageBox.Show("Sách này đã có trong phiếu thanh lý rồi, không thể thêm trùng!");
                return;
            }

            // Nếu không trùng thì mới thực hiện thêm
            string trangThai = radCo.Checked ? "Có" : "Không";
            try
            {
                db.open();
                string maP = txtMaPhieu.Text;
                string lyDo = cboLyDo.Text;
                string ngay = DateTime.Now.ToString("yyyy-MM-dd");

                db.update($"INSERT INTO THANHLY (MaPhieuTL, NgayTL, MaNV) VALUES ('{maP}','{ngay}','{Session.MaNV}')");
                db.update($"INSERT INTO CHITIETTHANHLY (MaPhieuTL, MaSach, LyDoTL, TrangThaiThanhLy) VALUES ('{maP}','{maS}',N'{lyDo}',N'{trangThai}')");
                db.update($"UPDATE SACH SET TinhTrang = N'Đã thanh lý' WHERE MaSach='{maS}'");

                MessageBox.Show("Thêm thành công!");
                ClearInput();
                LoadHistoryFromSQL();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            finally { db.close(); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maS = txtMaSach.Text.Trim();
            try
            {
                db.open();
                db.update($"DELETE FROM CHITIETTHANHLY WHERE MaSach = '{maS}'");
                db.update($"UPDATE SACH SET TinhTrang = N'Bình thường' WHERE MaSach = '{maS}'");
                LoadHistoryFromSQL();
            }
            finally { db.close(); }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtMaSach.Text.Trim();
            string sql = $@"SELECT ct.MaPhieuTL, t.NgayTL, ct.MaSach, d.TenDauSach, s.TinhTrang, ct.LyDoTL, ct.TrangThaiThanhLy 
                           FROM CHITIETTHANHLY ct 
                           JOIN THANHLY t ON ct.MaPhieuTL = t.MaPhieuTL 
                           JOIN SACH s ON ct.MaSach = s.MaSach
                           JOIN DAUSACH d ON s.MaDauSach = d.MaDauSach
                           WHERE ct.MaSach LIKE '%{tuKhoa}%'";
            dgvThanhLy.DataSource = db.getTable(sql);
        }

        private void dgvThanhLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvThanhLy.Rows.Count - 1)
            {
                DataGridViewRow row = dgvThanhLy.Rows[e.RowIndex];
                txtMaPhieu.Text = row.Cells["MaPhieuTL"].Value?.ToString();
                txtMaSach.Text = row.Cells["MaSach"].Value?.ToString();
                txtTenSach.Text = row.Cells["TenDauSach"].Value?.ToString();
                txtTinhTrang.Text = row.Cells["TinhTrang"].Value?.ToString();
                cboLyDo.Text = row.Cells["LyDoTL"].Value?.ToString();

                // Hiển thị lại lên RadioButton khi click vào lưới
                string status = row.Cells["TrangThaiThanhLy"].Value?.ToString();
                radCo.Checked = (status == "Có");
                radKhong.Checked = (status == "Không");
            }
        }

        private void ClearInput()
        {
            txtMaPhieu.Text = "PTL" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTinhTrang.Clear();
            cboLyDo.SelectedIndex = -1;
            radCo.Checked = false;
            radKhong.Checked = false;
        }
    }
}