using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        string connStr = @"Data Source=.;Initial Catalog=TodayFunny;Integrated Security=True";

        SqlConnection conn;

       
        public UCPowerBI()
        {
            InitializeComponent();
            conn = new SqlConnection(connStr); //Phần này sẽ bỏ



        }
     
        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void UCPowerBI_Load_1(object sender, EventArgs e)
        {
            LoadTongQuan();
            LoadTopSach();
            LoadChartMuonTheoThang();
            LoadChartLoaiSach();
            LoadChartTrangThai();
            LoadGridSach();
        }

        // ================= TỔNG QUAN =================

        void LoadTongQuan()
        {
            conn.Open();

            // Tổng sách
            SqlCommand cmdSach = new SqlCommand(
                "SELECT COUNT(*) FROM SACH", conn);

            lblTongSach.Text = cmdSach.ExecuteScalar().ToString();

            // Tổng độc giả
            SqlCommand cmdDG = new SqlCommand(
                "SELECT COUNT(*) FROM DOCGIA", conn);

            lblTongDocGia.Text = cmdDG.ExecuteScalar().ToString();

            // Tổng phiếu mượn
            SqlCommand cmdMuon = new SqlCommand(
                "SELECT COUNT(*) FROM PHIEUMUON", conn);

            lblTongMuon.Text = cmdMuon.ExecuteScalar().ToString();

            // Sách quá hạn
            SqlCommand cmdTre = new SqlCommand(@"
                SELECT COUNT(*)
                FROM PHIEUMUON
                WHERE NgayPhaiTra < GETDATE()", conn);

            lblSachTre.Text = cmdTre.ExecuteScalar().ToString();

            conn.Close();
        }

        // ================= TOP SÁCH =================

        void LoadTopSach()
        {
            string sql = @"
                SELECT TOP 5
                       s.TenSach,
                       COUNT(*) AS SoLuong
                FROM CHITIETPHIEUMUON ct
                JOIN SACH s
                    ON s.MaSach = ct.MaSach
                GROUP BY s.TenSach
                ORDER BY SoLuong DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            chartTopSach.Series.Clear();

            Series series = new Series("Top Sách");

            series.ChartType = SeriesChartType.Column;

            chartTopSach.Series.Add(series);

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(
                    row["TenSach"].ToString(),
                    row["SoLuong"]
                );
            }
        }

        // ================= BIỂU ĐỒ THEO THÁNG =================

        void LoadChartMuonTheoThang()
        {
            string sql = @"
                SELECT MONTH(NgayMuon) AS Thang,
                       COUNT(*) AS SoLuong
                FROM PHIEUMUON
                GROUP BY MONTH(NgayMuon)
                ORDER BY Thang";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            chartMuonTheoThang.Series.Clear();

            Series series = new Series("Mượn sách");

            series.ChartType = SeriesChartType.Line;

            chartMuonTheoThang.Series.Add(series);

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(
                    "T" + row["Thang"].ToString(),
                    row["SoLuong"]
                );
            }
        }

        // ================= DONUT LOẠI SÁCH =================

        void LoadChartLoaiSach()
        {
            string sql = @"
                SELECT TOP 5
                       TheLoai,
                       COUNT(*) AS SoLuong
                FROM SACH
                GROUP BY TheLoai";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            chartLoaiSach.Series.Clear();

            Series series = new Series("Thể loại");

            series.ChartType = SeriesChartType.Doughnut;

            chartLoaiSach.Series.Add(series);

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(
                    row["TheLoai"].ToString(),
                    row["SoLuong"]
                );
            }
        }

        // ================= DONUT TRẠNG THÁI =================

        void LoadChartTrangThai()
        {
            string sql = @"
                SELECT TinhTrang,
                       COUNT(*) AS SoLuong
                FROM SACH
                GROUP BY TinhTrang";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            chartTrangThai.Series.Clear();

            Series series = new Series("Trạng thái");

            series.ChartType = SeriesChartType.Doughnut;

            chartTrangThai.Series.Add(series);

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(
                    row["TinhTrang"].ToString(),
                    row["SoLuong"]
                );
            }
        }

        // ================= DATA GRID =================

        void LoadGridSach()
        {
            string sql = @"
                SELECT TOP 20
                       MaSach,
                       TenSach,
                       TacGia,
                       TheLoai,
                       SoLuong
                FROM SACH";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvTopSach.DataSource = dt;
        }
    }

}

