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

            dgvThanhLy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadHistoryFromSQL();

            TaoMaPhieuMoi();
        }

        void TaoMaPhieuMoi()
        {
            txtMaPhieu.Text = "PTL" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void txtMaSach_Leave(object sender, EventArgs e)
        {
            string maS = txtMaSach.Text.Trim();

            if (string.IsNullOrEmpty(maS))
                return;

            try
            {
                string sql = $@"
                    SELECT d.TenDauSach, s.TinhTrang
                    FROM SACH s
                    JOIN DAUSACH d ON s.MaDauSach = d.MaDauSach
                    WHERE s.MaSach = '{maS}'";

                DataTable dt = db.getTable(sql);

                if (dt.Rows.Count > 0)
                {
                    txtTenSach.Text = dt.Rows[0]["TenDauSach"].ToString();
                    txtTinhTrang.Text = dt.Rows[0]["TinhTrang"].ToString();
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy mã sách!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtTenSach.Clear();
                    txtTinhTrang.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải thông tin sách: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadHistoryFromSQL()
        {
            try
            {
                string sql = @"
                    SELECT 
                        ct.MaPhieuTL,
                        t.NgayTL,
                        ct.MaSach,
                        d.TenDauSach,
                        s.TinhTrang,
                        ct.LyDoTL,
                        ct.TrangThaiThanhLy
                    FROM CHITIETTHANHLY ct
                    LEFT JOIN THANHLY t 
                        ON ct.MaPhieuTL = t.MaPhieuTL
                    LEFT JOIN SACH s 
                        ON ct.MaSach = s.MaSach
                    LEFT JOIN DAUSACH d 
                        ON s.MaDauSach = d.MaDauSach";

                dgvThanhLy.DataSource = db.getTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load dữ liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show(
                    "Mã sách không hợp lệ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (cboLyDo.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn lý do thanh lý!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!radCo.Checked && !radKhong.Checked)
            {
                MessageBox.Show(
                    "Vui lòng chọn trạng thái thanh lý!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string maS = txtMaSach.Text.Trim();

            string checkSql =
                $"SELECT COUNT(*) FROM CHITIETTHANHLY WHERE MaSach = '{maS}'";

            int count = Convert.ToInt32(db.getScalar(checkSql));

            if (count > 0)
            {
                MessageBox.Show(
                    "Sách này đã được thanh lý trước đó!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string trangThaiThanhLy =
                radCo.Checked ? "Có" : "Không";

            string tinhTrangSachMoi =
                radCo.Checked ? "Đã thanh lý" : txtTinhTrang.Text.Trim();

            try
            {
                db.open();

                string maP = txtMaPhieu.Text.Trim();
                string lyDo = cboLyDo.Text.Trim();
                string ngay = DateTime.Now.ToString("yyyy-MM-dd");

                // Thêm phiếu thanh lý
                string sqlPhieu = $@"
                    IF NOT EXISTS
                    (
                        SELECT 1
                        FROM THANHLY
                        WHERE MaPhieuTL = '{maP}'
                    )
                    INSERT INTO THANHLY
                    (
                        MaPhieuTL,
                        NgayTL,
                        MaNV
                    )
                    VALUES
                    (
                        '{maP}',
                        '{ngay}',
                        '{Session.MaNV}'
                    )";

                db.update(sqlPhieu);

                // Thêm chi tiết thanh lý
                string sqlChiTiet = $@"
                    INSERT INTO CHITIETTHANHLY
                    (
                        MaPhieuTL,
                        MaSach,
                        LyDoTL,
                        TrangThaiThanhLy
                    )
                    VALUES
                    (
                        '{maP}',
                        '{maS}',
                        N'{lyDo}',
                        N'{trangThaiThanhLy}'
                    )";

                db.update(sqlChiTiet);

                // Cập nhật tình trạng sách
                string sqlUpdateSach = $@"
                    UPDATE SACH
                    SET TinhTrang = N'{tinhTrangSachMoi}'
                    WHERE MaSach = '{maS}'";

                db.update(sqlUpdateSach);

                MessageBox.Show(
                    "Thanh lý sách thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadHistoryFromSQL();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thêm thanh lý: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                db.close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn sách cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa thanh lý sách này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rs == DialogResult.No)
                return;

            string maS = txtMaSach.Text.Trim();

            try
            {
                db.open();

                string sqlDelete =
                    $"DELETE FROM CHITIETTHANHLY WHERE MaSach = '{maS}'";

                db.update(sqlDelete);

                string sqlUpdateSach = $@"
                    UPDATE SACH
                    SET TinhTrang = N'Bình thường'
                    WHERE MaSach = '{maS}'";

                db.update(sqlUpdateSach);

                MessageBox.Show(
                    "Xóa thanh lý thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadHistoryFromSQL();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xóa thanh lý: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                db.close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtMaSach.Text.Trim();

                string sql = $@"
                    SELECT
                        ct.MaPhieuTL,
                        t.NgayTL,
                        ct.MaSach,
                        d.TenDauSach,
                        s.TinhTrang,
                        ct.LyDoTL,
                        ct.TrangThaiThanhLy
                    FROM CHITIETTHANHLY ct
                    JOIN THANHLY t
                        ON ct.MaPhieuTL = t.MaPhieuTL
                    JOIN SACH s
                        ON ct.MaSach = s.MaSach
                    JOIN DAUSACH d
                        ON s.MaDauSach = d.MaDauSach
                    WHERE ct.MaSach LIKE '%{tuKhoa}%'";

                dgvThanhLy.DataSource = db.getTable(sql);

                if (dgvThanhLy.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy dữ liệu!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm kiếm: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvThanhLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dgvThanhLy.Rows.Count - 1)
                return;

            DataGridViewRow row = dgvThanhLy.Rows[e.RowIndex];

            txtMaPhieu.Text =
                row.Cells["MaPhieuTL"].Value?.ToString();

            txtMaSach.Text =
                row.Cells["MaSach"].Value?.ToString();

            txtTenSach.Text =
                row.Cells["TenDauSach"].Value?.ToString();

            txtTinhTrang.Text =
                row.Cells["TinhTrang"].Value?.ToString();

            cboLyDo.Text =
                row.Cells["LyDoTL"].Value?.ToString();

            string status =
                row.Cells["TrangThaiThanhLy"].Value?.ToString();

            radCo.Checked = (status == "Có");
            radKhong.Checked = (status == "Không");
        }

        private void ClearInput()
        {
            TaoMaPhieuMoi();

            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTinhTrang.Clear();

            cboLyDo.SelectedIndex = -1;

            radCo.Checked = false;
            radKhong.Checked = false;

            txtMaSach.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}