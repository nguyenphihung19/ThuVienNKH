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

            // Kiểm tra đã chọn trạng thái thanh lý chưa
            if (!radCo.Checked && !radKhong.Checked)
            {
                MessageBox.Show("Vui lòng chọn trạng thái thanh lý (Có/Không)!");
                return;
            }

            string maS = txtMaSach.Text.Trim();
            string trangThaiThanhLy = radCo.Checked ? "Có" : "Không";

            // BIẾN QUYẾT ĐỊNH TÌNH TRẠNG SÁCH
            string tinhTrangSachMoi;

            if (radCo.Checked)
            {
                // Nếu chọn "Có" -> Chuyển thành "Đã thanh lý"
                tinhTrangSachMoi = "Đã thanh lý";
            }
            else
            {
                // Nếu chọn "Không" -> GIỮ NGUYÊN tình trạng cũ
                // Ta lấy giá trị từ TextBox tình trạng đã được load lúc Leave (txtMaSach_Leave)
                tinhTrangSachMoi = txtTinhTrang.Text.Trim();
            }

            // Kiểm tra trùng mã sách trong chi tiết thanh lý
            string checkSql = $"SELECT COUNT(*) FROM CHITIETTHANHLY WHERE MaSach = '{maS}'";
            int count = Convert.ToInt32(db.getScalar(checkSql));

            if (count > 0)
            {
                MessageBox.Show("Sách này đã có trong phiếu thanh lý rồi!");
                return;
            }

            try
            {
                db.open();
                string maP = txtMaPhieu.Text;
                string lyDo = cboLyDo.Text;
                string ngay = DateTime.Now.ToString("yyyy-MM-dd");

                // 1. Thêm phiếu thanh lý (nếu chưa tồn tại)
                string sqlPhieu = $@"IF NOT EXISTS (SELECT 1 FROM THANHLY WHERE MaPhieuTL = '{maP}') 
                             INSERT INTO THANHLY (MaPhieuTL, NgayTL, MaNV) VALUES ('{maP}','{ngay}','{Session.MaNV}')";
                db.update(sqlPhieu);

                // 2. Thêm vào chi tiết thanh lý
                string sqlChiTiet = $@"INSERT INTO CHITIETTHANHLY (MaPhieuTL, MaSach, LyDoTL, TrangThaiThanhLy) 
                               VALUES ('{maP}','{maS}', N'{lyDo}', N'{trangThaiThanhLy}')";
                db.update(sqlChiTiet);

                // 3. Cập nhật tình trạng sách vào bảng SACH
                string sqlUpdateSach = $"UPDATE SACH SET TinhTrang = N'{tinhTrangSachMoi}' WHERE MaSach = '{maS}'";
                db.update(sqlUpdateSach);

                MessageBox.Show("Cập nhật thành công!");

                ClearInput();
                LoadHistoryFromSQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                db.close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text)) return;

            string maS = txtMaSach.Text.Trim();
            try
            {
                db.open();
                // Xóa chi tiết thanh lý
                db.update($"DELETE FROM CHITIETTHANHLY WHERE MaSach = '{maS}'");
                // Khi xóa thanh lý, trả trạng thái sách về "Bình thường" (hoặc trạng thái mặc định của bạn)
                db.update($"UPDATE SACH SET TinhTrang = N'Bình thường' WHERE MaSach = '{maS}'");

                MessageBox.Show("Đã xóa và cập nhật lại trạng thái sách!");
                LoadHistoryFromSQL();
                ClearInput();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
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