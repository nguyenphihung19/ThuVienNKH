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
    public partial class ucThongKeBaoCao : UserControl
    {
        DBConnect db = new DBConnect();

        // Biến lưu dòng đang chọn
        private DataGridViewRow selectedRow;

        public ucThongKeBaoCao()
        {
            InitializeComponent();
        }

        private void ucThongKeBaoCao_Load(object sender, EventArgs e)
        {
            LoadAllData();
            LoadStatistics();
        }

        private void LoadAllData()
        {
            try
            {
                string sql = @"
                SELECT 
                s.MaSach, ds.TenDauSach, 
                ISNULL(dg.MaDG, '') AS MaDG,
                ISNULL(dg.HoTen, '') AS HoTen,
                ISNULL(pm.NgayMuon, '') AS NgayMuon,
                ISNULL(pm.NgayPhaiTra, '') AS NgayPhaiTra,
                CASE 
                WHEN pt.MaPhieuTra IS NOT NULL THEN N'Đã trả'
                WHEN pm.MaPhieuMuon IS NOT NULL AND GETDATE() > pm.NgayPhaiTra THEN N'Quá hạn'
                WHEN pm.MaPhieuMuon IS NOT NULL THEN N'Đang mượn'
                ELSE N'Còn'
                END AS TinhTrang
                FROM SACH s
                INNER JOIN DAUSACH ds ON s.MaDauSach = ds.MaDauSach
                LEFT JOIN CHITIETPHIEUMUON ct ON s.MaSach = ct.MaSach
                LEFT JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
                LEFT JOIN DOCGIA dg ON pm.MaDG = dg.MaDG
                GROUP BY s.MaSach, ds.TenDauSach, dg.MaDG, dg.HoTen, 
                pm.NgayMuon, pm.NgayPhaiTra, pt.MaPhieuTra, pm.MaPhieuMuon
                ORDER BY s.MaSach";

                DataTable dt = db.getTable(sql);
                gridviewThongKe.DataSource = dt;
                SetColumns();
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê: " + ex.Message);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                // 1. Tổng số sách
                string sqlTongSach = "SELECT COUNT(*) FROM SACH";
                DataTable dtTongSach = db.getTable(sqlTongSach);
                int tongSach = dtTongSach.Rows.Count > 0 ? Convert.ToInt32(dtTongSach.Rows[0][0]) : 0;

                // 2. Số sách đang được mượn
                string sqlDangMuon = @"
                SELECT COUNT(DISTINCT ct.MaSach) 
                FROM CHITIETPHIEUMUON ct
                INNER JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
                WHERE pt.MaPhieuTra IS NULL";
                DataTable dtDangMuon = db.getTable(sqlDangMuon);
                int dangMuon = dtDangMuon.Rows.Count > 0 ? Convert.ToInt32(dtDangMuon.Rows[0][0]) : 0;

                // 3. Số sách quá hạn
                string sqlQuaHan = @"
                SELECT COUNT(DISTINCT ct.MaSach) 
                FROM CHITIETPHIEUMUON ct
                INNER JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
                WHERE pt.MaPhieuTra IS NULL 
                AND GETDATE() > pm.NgayPhaiTra";
                DataTable dtQuaHan = db.getTable(sqlQuaHan);
                int quaHan = dtQuaHan.Rows.Count > 0 ? Convert.ToInt32(dtQuaHan.Rows[0][0]) : 0;

                // 4. Tổng doanh thu
                string sqlDoanhThu = @"SELECT ISNULL(SUM(TienPhatKyNay), 0) FROM PHIEUTRA";
                DataTable dtDoanhThu = db.getTable(sqlDoanhThu);
                long doanhThu = dtDoanhThu.Rows.Count > 0 ? Convert.ToInt64(dtDoanhThu.Rows[0][0]) : 0;

                // Hiển thị lên Label
                lblTongSach.Text = $"Tổng số sách: {tongSach}";
                lblDangMuon.Text = $"Sách đang mượn: {dangMuon}";
                lblQuaHan.Text = $"Sách quá hạn: {quaHan}";
                lblDoanhThu.Text = $"Doanh thu: {doanhThu:N0} VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetColumns()
        {
            // Đặt HeaderText cho các cột
            if (gridviewThongKe.Columns.Contains("MaSach"))
            {
                gridviewThongKe.Columns["MaSach"].HeaderText = "Mã Sách";
                gridviewThongKe.Columns["MaSach"].DataPropertyName = "MaSach";
            }

            if (gridviewThongKe.Columns.Contains("TenDauSach"))
            {
                gridviewThongKe.Columns["TenDauSach"].HeaderText = "Tên Sách";
                gridviewThongKe.Columns["TenDauSach"].DataPropertyName = "TenDauSach";
            }

            if (gridviewThongKe.Columns.Contains("MaDG"))
            {
                gridviewThongKe.Columns["MaDG"].HeaderText = "Mã Độc Giả";
                gridviewThongKe.Columns["MaDG"].DataPropertyName = "MaDG";
            }

            if (gridviewThongKe.Columns.Contains("HoTen"))
            {
                gridviewThongKe.Columns["HoTen"].HeaderText = "Người Mượn";
                gridviewThongKe.Columns["HoTen"].DataPropertyName = "HoTen";
            }

            if (gridviewThongKe.Columns.Contains("NgayMuon"))
            {
                gridviewThongKe.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                gridviewThongKe.Columns["NgayMuon"].DataPropertyName = "NgayMuon";
                gridviewThongKe.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                gridviewThongKe.Columns["NgayMuon"].DefaultCellStyle.NullValue = "";
            }

            if (gridviewThongKe.Columns.Contains("NgayPhaiTra"))
            {
                gridviewThongKe.Columns["NgayPhaiTra"].HeaderText = "Hạn Trả";
                gridviewThongKe.Columns["NgayPhaiTra"].DataPropertyName = "NgayPhaiTra";
                gridviewThongKe.Columns["NgayPhaiTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                gridviewThongKe.Columns["NgayPhaiTra"].DefaultCellStyle.NullValue = "";
            }

            if (gridviewThongKe.Columns.Contains("TinhTrang"))
            {
                gridviewThongKe.Columns["TinhTrang"].HeaderText = "Tình Trạng";
                gridviewThongKe.Columns["TinhTrang"].DataPropertyName = "TinhTrang";
            }

            // Sự kiện tô màu
            gridviewThongKe.CellFormatting -= GridViewThongKe_CellFormatting; // Tránh trùng lặp
            gridviewThongKe.CellFormatting += GridViewThongKe_CellFormatting;
        }

        private void GridViewThongKe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && gridviewThongKe.Rows[e.RowIndex].Cells["TinhTrang"].Value != null)
            {
                string tinhTrang = gridviewThongKe.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString();

                if (tinhTrang == "Đang mượn")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                    e.CellStyle.Font = new Font(gridviewThongKe.Font, FontStyle.Bold);
                }
                else if (tinhTrang == "Còn")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (tinhTrang == "Quá hạn")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(gridviewThongKe.Font, FontStyle.Bold);
                }
            }
        }

        // Sự kiện chọn dòng trên gridview
        private void gridviewThongKe_SelectionChanged(object sender, EventArgs e)
        {
            if (gridviewThongKe.SelectedRows.Count > 0)
            {
                selectedRow = gridviewThongKe.SelectedRows[0];
            }
        }

        // TÌM KIẾM
        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string textname = txtSearch.Text.Trim();

                string sql = @"
                SELECT 
                s.MaSach, 
                ds.TenDauSach, 
                ISNULL(dg.MaDG, '') AS MaDG,
                ISNULL(dg.HoTen, '') AS HoTen,
                ISNULL(pm.NgayMuon, '') AS NgayMuon,
                ISNULL(pm.NgayPhaiTra, '') AS NgayPhaiTra,
                CASE 
                WHEN pt.MaPhieuTra IS NOT NULL THEN N'Đã trả'
                WHEN pm.MaPhieuMuon IS NOT NULL AND GETDATE() > pm.NgayPhaiTra THEN N'Quá hạn'
                WHEN pm.MaPhieuMuon IS NOT NULL THEN N'Đang mượn'
                ELSE N'Còn'
                END AS TinhTrang
                FROM SACH s
                INNER JOIN DAUSACH ds ON s.MaDauSach = ds.MaDauSach
                LEFT JOIN CHITIETPHIEUMUON ct ON s.MaSach = ct.MaSach
                LEFT JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
                LEFT JOIN DOCGIA dg ON pm.MaDG = dg.MaDG";

                if (!string.IsNullOrEmpty(textname))
                {
                    sql += @"
                WHERE (s.MaSach LIKE N'%" + textname + @"%' 
                OR ds.TenDauSach LIKE N'%" + textname + @"%' 
                OR dg.HoTen LIKE N'%" + textname + @"%' 
                OR dg.MaDG LIKE N'%" + textname + @"%')";
                }

                sql += @"
                GROUP BY s.MaSach, ds.TenDauSach, dg.MaDG, dg.HoTen, 
                pm.NgayMuon, pm.NgayPhaiTra, pt.MaPhieuTra, pm.MaPhieuMuon
                ORDER BY s.MaSach";

                DataTable dt = db.getTable(sql);
                gridviewThongKe.DataSource = dt;
                SetColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // THÊM 
        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string maSach = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã sách:", "Thêm sách", "");
        //        string tenSach = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên sách:", "Thêm sách", "");
        //        string tacGia = Microsoft.VisualBasic.Interaction.InputBox("Nhập tác giả:", "Thêm sách", "");
        //        string soLuong = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng:", "Thêm sách", "1");

        //        if (!string.IsNullOrEmpty(maSach) && !string.IsNullOrEmpty(tenSach))
        //        {
        //            string sql = $@"INSERT INTO SACH (MaSach, MaDauSach, TinhTrang) 
        //                           VALUES ('{maSach}', (SELECT MaDauSach FROM DAUSACH WHERE TenDauSach = N'{tenSach}'), N'Còn')";

        //            db.executeNonQuery(sql);
        //            MessageBox.Show("Thêm sách thành công!");
        //            LoadAllData(); // Refresh lại dữ liệu
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi thêm sách: " + ex.Message);
        //    }
        //}

        // XÓA 
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRow != null)
                {
                    string maSach = selectedRow.Cells["MaSach"].Value.ToString();
                    string tinhTrang = selectedRow.Cells["TinhTrang"].Value.ToString();

                    // Kiểm tra nếu sách đang được mượn thì không cho xóa
                    if (tinhTrang == "Đang mượn" || tinhTrang == "Quá hạn")
                    {
                        MessageBox.Show("Không thể xóa sách đang được mượn!", "Cảnh báo",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sách {maSach}?",
                                                          "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string sql = $"DELETE FROM SACH WHERE MaSach = '{maSach}'";
                        //db.ExecuteNonQuery(sql);
                        MessageBox.Show("Xóa sách thành công!");
                        LoadAllData(); // Refresh lại dữ liệu
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sách: " + ex.Message);
            }
        }

        // SỬA 
        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (selectedRow != null)
        //        {
        //            string maSach = selectedRow.Cells["MaSach"].Value.ToString();
        //            string tenSachHienTai = selectedRow.Cells["TenDauSach"].Value.ToString();

        //            string tenSachMoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên sách mới:", "Sửa sách", tenSachHienTai);

        //            if (!string.IsNullOrEmpty(tenSachMoi) && tenSachMoi != tenSachHienTai)
        //            {
        //                // Cập nhật tên sách trong bảng DAUSACH
        //                string sql = $@"UPDATE DAUSACH SET TenDauSach = N'{tenSachMoi}' 
        //                               WHERE MaDauSach = (SELECT MaDauSach FROM SACH WHERE MaSach = '{maSach}')";

        //                db.executeNonQuery(sql);
        //                MessageBox.Show("Sửa sách thành công!");
        //                LoadAllData(); // Refresh lại dữ liệu
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Vui lòng chọn sách cần sửa!", "Thông báo",
        //                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi sửa sách: " + ex.Message);
        //    }
        //}

        // RESET 
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadAllData();
        }

        // EXPORT EXCEL (nếu có)
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel Files|*.xlsx|Excel 97-2003|*.xls";
                saveFile.Title = "Export dữ liệu ra Excel";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    // Code export Excel ở đây
                    MessageBox.Show("Export thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi export: " + ex.Message);
            }
        }
    }
}