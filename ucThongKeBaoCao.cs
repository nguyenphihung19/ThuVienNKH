using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class ucThongKeBaoCao : UserControl
    {
        DBConnect db = new DBConnect();
        private DataGridViewRow selectedRow;

        public ucThongKeBaoCao()
        {
            InitializeComponent();
            ExcelPackage.License.SetNonCommercialPersonal("Bài TH Quản Lý Thư Viện");
        }

        private void ucThongKeBaoCao_Load(object sender, EventArgs e)
        {
            LoadAllData();
            LoadStatistics();

            btnSua.Visible = false;
            btnXoa.Visible = false;
        }

        private void LoadAllData()
        {
            try
            {
                string sql = @"
                SELECT 
                    s.MaSach, 
                    ds.TenDauSach, 
                    ISNULL(dg.HoTen, '') AS NguoiMuon,
                    CONVERT(varchar(10), pm.NgayMuon, 103) AS NgayMuon,
                    CONVERT(varchar(10), pm.NgayPhaiTra, 103) AS HanTra,
                    ISNULL(pt.TienPhatKyNay, 0) AS SoTien,
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
                GROUP BY s.MaSach, ds.TenDauSach, dg.HoTen, pm.NgayMuon, pm.NgayPhaiTra, pt.MaPhieuTra, pm.MaPhieuMuon, pt.TienPhatKyNay
                ORDER BY s.MaSach";

                DataTable dt = db.getTable(sql);
                gridviewThongKe.DataSource = dt;
                SetColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                int tongSach = Convert.ToInt32(db.getScalar("SELECT COUNT(*) FROM SACH"));
                int dangMuon = Convert.ToInt32(db.getScalar(@"
                    SELECT COUNT(DISTINCT ct.MaSach) 
                    FROM CHITIETPHIEUMUON ct
                    INNER JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                    LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
                    WHERE pt.MaPhieuTra IS NULL"));

                int quaHan = Convert.ToInt32(db.getScalar(@"
                    SELECT COUNT(DISTINCT ct.MaSach) 
                    FROM CHITIETPHIEUMUON ct
                    INNER JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
                    LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
                    WHERE pt.MaPhieuTra IS NULL AND GETDATE() > pm.NgayPhaiTra"));

                long doanhThu = Convert.ToInt64(db.getScalar("SELECT ISNULL(SUM(TienPhatKyNay), 0) FROM PHIEUTRA"));

                lblTongSach.Text = $"Tổng sách: {tongSach}";
                lblDangMuon.Text = $"Đang mượn: {dangMuon}";
                lblQuaHan.Text = $"Quá hạn: {quaHan}";
                lblDoanhThu.Text = $"Doanh thu: {doanhThu:N0} VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void SetColumns()
        {
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
            if (gridviewThongKe.Columns.Contains("NguoiMuon"))
            {
                gridviewThongKe.Columns["NguoiMuon"].HeaderText = "Người Mượn";
                gridviewThongKe.Columns["NguoiMuon"].DataPropertyName = "NguoiMuon";
            }
            if (gridviewThongKe.Columns.Contains("NgayMuon"))
            {
                gridviewThongKe.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                gridviewThongKe.Columns["NgayMuon"].DataPropertyName = "NgayMuon";
            }
            if (gridviewThongKe.Columns.Contains("HanTra"))
            {
                gridviewThongKe.Columns["HanTra"].HeaderText = "Hạn Trả";
                gridviewThongKe.Columns["HanTra"].DataPropertyName = "HanTra";
            }
            if (gridviewThongKe.Columns.Contains("TinhTrang"))
            {
                gridviewThongKe.Columns["TinhTrang"].HeaderText = "Tình Trạng";
                gridviewThongKe.Columns["TinhTrang"].DataPropertyName = "TinhTrang";
            }
            if (gridviewThongKe.Columns.Contains("SoTien"))
            {
                gridviewThongKe.Columns["SoTien"].HeaderText = "Số Tiền";
                gridviewThongKe.Columns["SoTien"].DataPropertyName = "SoTien";
                gridviewThongKe.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                gridviewThongKe.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Tô màu
            gridviewThongKe.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && gridviewThongKe.Rows[e.RowIndex].Cells["TinhTrang"].Value != null)
                {
                    string tt = gridviewThongKe.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString();
                    if (tt == "Đang mượn") e.CellStyle.ForeColor = Color.Blue;
                    else if (tt == "Còn") e.CellStyle.ForeColor = Color.Green;
                    else if (tt == "Quá hạn") e.CellStyle.ForeColor = Color.Red;
                }
            };
        }

        private void gridviewThongKe_SelectionChanged(object sender, EventArgs e)
        {
            if (gridviewThongKe.SelectedRows.Count > 0)
                selectedRow = gridviewThongKe.SelectedRows[0];
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                string sql = @"
                SELECT 
                    s.MaSach, ds.TenDauSach, ISNULL(dg.HoTen, '') AS NguoiMuon,
                    CONVERT(varchar(10), pm.NgayMuon, 103) AS NgayMuon,
                    CONVERT(varchar(10), pm.NgayPhaiTra, 103) AS HanTra,
                    ISNULL(pt.TienPhatKyNay, 0) AS SoTien,
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
                    WHERE s.MaSach LIKE @key OR ds.TenDauSach LIKE @key OR dg.HoTen LIKE @key
                    GROUP BY s.MaSach, ds.TenDauSach, dg.HoTen, pm.NgayMuon, pm.NgayPhaiTra, pt.MaPhieuTra, pm.MaPhieuMuon, pt.TienPhatKyNay
                    ORDER BY s.MaSach";

                SqlParameter[] param = { new SqlParameter("@key", "%" + keyword + "%") };
                DataTable dt = db.getTable(sql, param);
                gridviewThongKe.DataSource = dt;
                SetColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //if (selectedRow == null)
            //{
            //    MessageBox.Show("Vui lòng chọn sách cần xóa!");
            //    return;
            //}

            //string maSach = selectedRow.Cells["MaSach"].Value.ToString();
            //string tinhTrang = selectedRow.Cells["TinhTrang"].Value.ToString();

            //if (tinhTrang != "Còn")
            //{
            //    MessageBox.Show("Chỉ xóa được sách có tình trạng 'Còn'!");
            //    return;
            //}

            //// Kiểm tra đã từng mượn chưa
            //int count = Convert.ToInt32(db.getScalar("SELECT COUNT(*) FROM CHITIETPHIEUMUON WHERE MaSach = @MaSach",
            //    new SqlParameter("@MaSach", maSach)));

            //if (count > 0)
            //{
            //    MessageBox.Show("Sách đã từng được mượn, không thể xóa!");
            //    return;
            //}

            //if (MessageBox.Show($"Xóa sách {maSach}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    // Lấy MaDauSach
            //    DataTable dt = db.getTable("SELECT MaDauSach FROM SACH WHERE MaSach = @MaSach",
            //        new SqlParameter("@MaSach", maSach));
            //    string maDauSach = dt.Rows[0][0].ToString();

            //    // Xóa sách
            //    db.update("DELETE FROM SACH WHERE MaSach = @MaSach", new SqlParameter("@MaSach", maSach));

            //    // Xóa đầu sách nếu không còn sách nào
            //    int remaining = Convert.ToInt32(db.getScalar("SELECT COUNT(*) FROM SACH WHERE MaDauSach = @MaDauSach",
            //        new SqlParameter("@MaDauSach", maDauSach)));

            //    if (remaining == 0)
            //        db.update("DELETE FROM DAUSACH WHERE MaDauSach = @MaDauSach", new SqlParameter("@MaDauSach", maDauSach));

            //    MessageBox.Show("Xóa thành công!");
            //    LoadAllData();
            //    LoadStatistics();
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //if (selectedRow == null)
            //{
            //    MessageBox.Show("Vui lòng chọn sách cần sửa!");
            //    return;
            //}

            //string maSach = selectedRow.Cells["MaSach"].Value.ToString();
            //string tenSachCu = selectedRow.Cells["TenDauSach"].Value.ToString();
            //string tinhTrang = selectedRow.Cells["TinhTrang"].Value.ToString();

            //if (tinhTrang != "Còn")
            //{
            //    MessageBox.Show("Chỉ sửa được sách có tình trạng 'Còn'!");
            //    return;
            //}

            //// Tạo form nhập liệu
            //Form inputForm = new Form();
            //inputForm.Text = "Sửa tên sách";
            //inputForm.Width = 400;
            //inputForm.Height = 130;
            //inputForm.StartPosition = FormStartPosition.CenterParent;
            //inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;

            //Label lbl = new Label() { Text = "Tên sách mới:", Location = new Point(20, 20), Size = new Size(100, 25) };
            //TextBox txt = new TextBox() { Text = tenSachCu, Location = new Point(20, 50), Size = new Size(340, 23) };
            //Button btnOK = new Button() { Text = "OK", Location = new Point(260, 80), Size = new Size(80, 30), DialogResult = DialogResult.OK };
            //Button btnCancel = new Button() { Text = "Hủy", Location = new Point(170, 80), Size = new Size(80, 30), DialogResult = DialogResult.Cancel };

            //inputForm.Controls.Add(lbl);
            //inputForm.Controls.Add(txt);
            //inputForm.Controls.Add(btnOK);
            //inputForm.Controls.Add(btnCancel);

            //if (inputForm.ShowDialog() == DialogResult.OK)
            //{
            //    string tenSachMoi = txt.Text.Trim();

            //    if (!string.IsNullOrEmpty(tenSachMoi) && tenSachMoi != tenSachCu)
            //    {
            //        // Kiểm tra tên sách mới đã tồn tại chưa
            //        int exists = Convert.ToInt32(db.getScalar("SELECT COUNT(*) FROM DAUSACH WHERE TenDauSach = @TenSach",
            //            new SqlParameter("@TenSach", tenSachMoi)));

            //        if (exists > 0)
            //        {
            //            // Gộp vào đầu sách đã có
            //            string maDauSachMoi = db.getTable("SELECT MaDauSach FROM DAUSACH WHERE TenDauSach = @TenSach",
            //                new SqlParameter("@TenSach", tenSachMoi)).Rows[0][0].ToString();

            //            db.update("UPDATE SACH SET MaDauSach = @MaDauSachMoi WHERE MaSach = @MaSach",
            //                new SqlParameter("@MaDauSachMoi", maDauSachMoi),
            //                new SqlParameter("@MaSach", maSach));
            //        }
            //        else
            //        {
            //            // Cập nhật tên sách
            //            db.update(@"UPDATE DAUSACH SET TenDauSach = @TenSachMoi 
            //                       WHERE MaDauSach = (SELECT MaDauSach FROM SACH WHERE MaSach = @MaSach)",
            //                new SqlParameter("@TenSachMoi", tenSachMoi),
            //                new SqlParameter("@MaSach", maSach));
            //        }

            //        MessageBox.Show("Sửa thành công!");
            //        LoadAllData();
            //        LoadStatistics();
            //    }
            //}
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadAllData();
            LoadStatistics();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (gridviewThongKe.Rows.Count > 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save as Excel File";
                    saveFileDialog.FileName = $"ThongKeSach_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcel(gridviewThongKe, saveFileDialog.FileName);
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Your Name");

            using (ExcelPackage excel = new ExcelPackage())
            {
                // Tạo worksheet
                ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("ThongKeSach");

                // Thêm tiêu đề chính
                worksheet.Cells[1, 1].Value = "BẢNG THỐNG KÊ SÁCH THƯ VIỆN";
                worksheet.Cells[1, 1, 1, dgv.Columns.Count].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Size = 14;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Thêm ngày xuất
                worksheet.Cells[2, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                worksheet.Cells[2, 1, 2, dgv.Columns.Count].Merge = true;
                worksheet.Cells[2, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Thêm header (tên cột)
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cells[4, i + 1].Value = dgv.Columns[i].HeaderText;
                    worksheet.Cells[4, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[4, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[4, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Thêm dữ liệu - KIỂM TRA KỸ HƠN
                int row = 5;
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            var cellValue = dgvRow.Cells[j].Value;

                            // Xử lý giá trị null
                            if (cellValue == null || cellValue == DBNull.Value)
                            {
                                worksheet.Cells[row, j + 1].Value = "";
                                continue;
                            }

                            string columnName = dgv.Columns[j].HeaderText;
                            string stringValue = cellValue.ToString();

                            // Xử lý cột Số Tiền
                            if (columnName == "Số Tiền")
                            {
                                decimal sotien;
                                if (decimal.TryParse(stringValue, out sotien))
                                {
                                    worksheet.Cells[row, j + 1].Value = sotien;
                                    worksheet.Cells[row, j + 1].Style.Numberformat.Format = "#,##0";
                                    worksheet.Cells[row, j + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                }
                                else
                                {
                                    worksheet.Cells[row, j + 1].Value = 0;
                                }
                            }

                            // Xử lý cột Ngày tháng
                            else if (columnName == "Ngày Mượn" || columnName == "Hạn Trả")
                            {
                                if (!string.IsNullOrWhiteSpace(stringValue))
                                {
                                    DateTime dateValue;
                                    if (DateTime.TryParse(stringValue, out dateValue))
                                    {
                                        worksheet.Cells[row, j + 1].Value = dateValue;
                                        worksheet.Cells[row, j + 1].Style.Numberformat.Format = "dd/MM/yyyy";
                                    }
                                    else
                                    {
                                        worksheet.Cells[row, j + 1].Value = stringValue;
                                    }
                                }
                                else
                                {
                                    worksheet.Cells[row, j + 1].Value = "";
                                }
                            }
                            // Các cột khác
                            else
                            {
                                worksheet.Cells[row, j + 1].Value = stringValue;
                            }
                        }
                        row++;
                    }
                }

                // Tự động căn chỉnh độ rộng cột
                worksheet.Cells[4, 1, row - 1, dgv.Columns.Count].AutoFitColumns();

                // Lưu file
                FileInfo excelFile = new FileInfo(filePath);
                excel.SaveAs(excelFile);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}