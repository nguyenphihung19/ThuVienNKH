using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class UCPowerBI : UserControl
    {
        DBConnect db = new DBConnect();

        SqlConnection conn;

       
        public UCPowerBI()
        {
            InitializeComponent();
        }

      

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void UCPowerBI_Load_1(object sender, EventArgs e)
        {
            LoadAllDashboard();
            //panel1.Controls.Clear();
            //UCPowerBI uc = new ucQuanLySinhVien();
            //uc.Dock = DockStyle.Fill;
            //panel1.Controls.Add(pa);
            //panel1.PerformLayout();
            //uc.BringToFront();
        }

        void LoadAllDashboard()
        {
            LoadTongQuan();

            LoadTopSach();

            LoadChartMuonTheoThang();

            LoadChartLoaiSach();

            LoadChartTrangThai();

            LoadGridSach();
        }

        void LoadTongQuan()
        {
            try
            {
                // ================= TỔNG SÁCH =================

                lblTongSach.Text =
                    db.getScalar(
                        "SELECT COUNT(*) FROM SACH"
                    ).ToString();

                // ================= TỔNG ĐỘC GIẢ =================

                lblTongDocGia.Text =
                    db.getScalar(
                        "SELECT COUNT(*) FROM DOCGIA"
                    ).ToString();

                // ================= TỔNG PHIẾU MƯỢN =================

                lblTongMuon.Text =
                    db.getScalar(
                        "SELECT COUNT(*) FROM PHIEUMUON"
                    ).ToString();

                // ================= SÁCH QUÁ HẠN =================
                // Chỉ tính sách chưa trả

                lblSachTre.Text =
                    db.getScalar(@"
                        SELECT COUNT(*)
                        FROM PHIEUMUON pm
                        WHERE pm.NgayPhaiTra < GETDATE()
                        AND NOT EXISTS
                        (
                            SELECT *
                            FROM PHIEUTRA pt
                            WHERE pt.MaPhieuMuon = pm.MaPhieuMuon
                        )
                    ").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi LoadTongQuan:\n" +
                    ex.Message
                );
            }
        }

        // =====================================================
        // LOAD TOP SÁCH MƯỢN
        // =====================================================

        void LoadTopSach()
        {
            try
            {
                // =================================================
                // SỬA LỖI:
                // Bảng SACH KHÔNG CÓ TenSach
                // TenSach nằm ở bảng DAUSACH
                // =================================================

                string sql = @"
                    SELECT TOP 5
                           ds.TenDauSach,
                           COUNT(*) AS SoLuong
                    FROM CHITIETPHIEUMUON ct
                    INNER JOIN SACH s
                        ON s.MaSach = ct.MaSach
                    INNER JOIN DAUSACH ds
                        ON ds.MaDauSach = s.MaDauSach
                    GROUP BY ds.TenDauSach
                    ORDER BY SoLuong DESC";

                DataTable dt = db.getTable(sql);

                chartTopSach.Series.Clear();

                chartTopSach.Titles.Clear();

                chartTopSach.Titles.Add("TOP 5 SÁCH MƯỢN");

                Series series =
                    new Series("Top Sách");

                series.ChartType =
                    SeriesChartType.Column;

                series.IsValueShownAsLabel = true;

                series.Font =
                    new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold
                    );

                series.Color =
                    Color.FromArgb(52, 152, 219);

                chartTopSach.Series.Add(series);

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(
                        row["TenDauSach"].ToString(),
                        Convert.ToInt32(row["SoLuong"])
                    );
                }

                chartTopSach.ChartAreas[0].AxisX.Interval = 1;

                chartTopSach.ChartAreas[0].AxisX.Title =
                    "Tên Sách";

                chartTopSach.ChartAreas[0].AxisY.Title =
                    "Số Lượt Mượn";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi LoadTopSach:\n" +
                    ex.Message
                );
            }
        }

        // =====================================================
        // LOAD CHART MƯỢN THEO THÁNG
        // =====================================================

        void LoadChartMuonTheoThang()
        {
            try
            {
                string sql = @"
                    SELECT MONTH(NgayMuon) AS Thang,
                           COUNT(*) AS SoLuong
                    FROM PHIEUMUON
                    GROUP BY MONTH(NgayMuon)
                    ORDER BY Thang";

                DataTable dt = db.getTable(sql);

                chartMuonTheoThang.Series.Clear();

                chartMuonTheoThang.Titles.Clear();

                chartMuonTheoThang.Titles.Add(
                    "THỐNG KÊ MƯỢN SÁCH THEO THÁNG"
                );

                Series series =
                    new Series("Mượn Sách");

                series.ChartType =
                    SeriesChartType.Line;

                series.BorderWidth = 4;

                series.MarkerStyle =
                    MarkerStyle.Circle;

                series.MarkerSize = 8;

                series.IsValueShownAsLabel = true;

                series.Color =
                    Color.FromArgb(231, 76, 60);

                chartMuonTheoThang.Series.Add(series);

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(
                        "T" + row["Thang"].ToString(),
                        Convert.ToInt32(row["SoLuong"])
                    );
                }

                chartMuonTheoThang.ChartAreas[0].AxisX.Interval = 1;

                chartMuonTheoThang.ChartAreas[0].AxisX.Title =
                    "Tháng";

                chartMuonTheoThang.ChartAreas[0].AxisY.Title =
                    "Số Lượt Mượn";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi LoadChartMuonTheoThang:\n" +
                    ex.Message
                );
            }
        }

        // =====================================================
        // LOAD CHART LOẠI SÁCH
        // =====================================================

        void LoadChartLoaiSach()
        {
            try
            {
                // =================================================
                // SỬA LỖI:
                // Bảng SACH KHÔNG CÓ TheLoai
                // Phải JOIN LOAISACH
                // =================================================

                string sql = @"
                    SELECT TOP 5
                           ls.TenLoaiSach,
                           COUNT(*) AS SoLuong
                    FROM SACH s
                    INNER JOIN DAUSACH ds
                        ON ds.MaDauSach = s.MaDauSach
                    INNER JOIN LOAISACH ls
                        ON ls.MaLoaiSach = ds.MaLoaiSach
                    GROUP BY ls.TenLoaiSach
                    ORDER BY SoLuong DESC";

                DataTable dt = db.getTable(sql);

                chartLoaiSach.Series.Clear();

                chartLoaiSach.Titles.Clear();

                chartLoaiSach.Titles.Add(
                    "THỂ LOẠI SÁCH"
                );

                Series series =
                    new Series("Thể Loại");

                series.ChartType =
                    SeriesChartType.Doughnut;

                series.IsValueShownAsLabel = true;

                series.Font =
                    new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold
                    );

                chartLoaiSach.Series.Add(series);

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(
                        row["TenLoaiSach"].ToString(),
                        Convert.ToInt32(row["SoLuong"])
                    );
                }

                chartLoaiSach.Legends[0].Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi LoadChartLoaiSach:\n" +
                    ex.Message
                );
            }
        }

        // =====================================================
        // LOAD CHART TRẠNG THÁI
        // =====================================================

        void LoadChartTrangThai()
        {
            try
            {
                string sql = @"
                    SELECT TinhTrang,
                           COUNT(*) AS SoLuong
                    FROM SACH
                    GROUP BY TinhTrang";

                DataTable dt = db.getTable(sql);

                chartTrangThai.Series.Clear();

                chartTrangThai.Titles.Clear();

                chartTrangThai.Titles.Add(
                    "TRẠNG THÁI SÁCH"
                );

                Series series =
                    new Series("Trạng Thái");

                series.ChartType =
                    SeriesChartType.Doughnut;

                series.IsValueShownAsLabel = true;

                series.Font =
                    new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold
                    );

                chartTrangThai.Series.Add(series);

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(
                        row["TinhTrang"].ToString(),
                        Convert.ToInt32(row["SoLuong"])
                    );
                }

                chartTrangThai.Legends[0].Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi LoadChartTrangThai:\n" +
                    ex.Message
                );
            }
        }

        // =====================================================
        // LOAD DATAGRIDVIEW
        // =====================================================

        void LoadGridSach()
        {
            try
            {
                // =================================================
                // SỬA LỖI:
                // DB là Sosachmuon
                // không phải SoSachMuon
                // =================================================

                string sql = @"
                    SELECT TOP 20
                           MaDG,
                           HoTen,
                           ISNULL(Sosachmuon,0) AS Sosachmuon,
                           SoDT,
                           LoaiDG
                    FROM DOCGIA
                    ORDER BY ISNULL(Sosachmuon,0) DESC";

                DataTable dt = db.getTable(sql);

                dgvTopSach.DataSource = dt;

                dgvTopSach.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvTopSach.AllowUserToAddRows = false;

                dgvTopSach.RowHeadersVisible = false;

                dgvTopSach.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvTopSach.MultiSelect = false;

                dgvTopSach.ReadOnly = true;

                dgvTopSach.DefaultCellStyle.Font =
                    new Font("Segoe UI", 10);

                dgvTopSach.ColumnHeadersDefaultCellStyle.Font =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold
                    );

                dgvTopSach.Columns["MaDG"].HeaderText =
                    "Mã Độc Giả";

                dgvTopSach.Columns["HoTen"].HeaderText =
                    "Họ Tên";

                dgvTopSach.Columns["Sosachmuon"].HeaderText =
                    "Số Sách Mượn";

                dgvTopSach.Columns["SoDT"].HeaderText =
                    "Số Điện Thoại";

                dgvTopSach.Columns["LoaiDG"].HeaderText =
                    "Loại Độc Giả";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi LoadGridSach:\n" +
                    ex.Message
                );
            }
        }

        // =====================================================
        // EVENT
        // =====================================================

        private void chartTopSach_Click(
            object sender,
            EventArgs e)
        {

        }

        // =====================================================
        // BUTTON REFRESH
        // =====================================================

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            LoadAllDashboard();

            MessageBox.Show(
                "Đã tải lại dữ liệu!"
            );
        }
    

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllDashboard();

            MessageBox.Show(
                "Đã tải lại dữ liệu!"
            );
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                // ============================================
                // MỞ POWER BI DESKTOP
                // ============================================
                // Nhớ đổi tên với đường dẫn zô 

                Process.Start(new ProcessStartInfo
                {
                    FileName = "cuoiky.pbix",
                    UseShellExecute = true
                });
            }
            catch
            {
                try
                {
                    // ============================================
                    // ĐƯỜNG DẪN POWER BI THÔNG DỤNG
                    // ============================================

                    string path1 =
                        @"D:\Menu\School\Couse\III (2)\Power BI\cuoiky.pbix";

                    string path2 =
                        @"C:\Program Files\WindowsApps\Microsoft.MicrosoftPowerBIDesktop_*";

                    // ============================================
                    // MỞ FILE EXE
                    // ============================================

                    Process.Start(path1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không tìm thấy Power BI Desktop!\n\n" +
                        "Vui lòng cài Power BI trước.\n\n" +
                        ex.Message,
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void lblSubTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void lblCard1Content_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

