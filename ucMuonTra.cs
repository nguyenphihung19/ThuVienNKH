using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class ucMuonTra : UserControl
    {
        DBConnect db = new DBConnect();
        public ucMuonTra()
        {
            InitializeComponent();
            HienThiDanhSachMuon();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            string maPhieuMuon = txtMaPhieuMuon.Text.Trim();

            if (maPhieuMuon == "")
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Mã Phiếu Mượn để in!");
                return;
            }

            string sql = @"SELECT pm.MaPhieuMuon, pm.MaDG, dg.HoTen, pm.NgayMuon, ct.MaSach, ds.TenDauSach
                   FROM PHIEUMUON pm
                   INNER JOIN DOCGIA dg ON pm.MaDG = dg.MaDG
                   INNER JOIN CHITIETPHIEUMUON ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
                   INNER JOIN SACH s ON ct.MaSach = s.MaSach
                   INNER JOIN DAUSACH ds ON s.MaDauSach = ds.MaDauSach
                   WHERE pm.MaPhieuMuon = " + maPhieuMuon;

            DataTable dt = db.getTable(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu mượn!");
                return;
            }

            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, ev) =>
            {
                Font font = new Font("Arial", 12);
                float y = 50;

                ev.Graphics.DrawString("PHIẾU MƯỢN SÁCH",
                    new Font("Arial", 16, FontStyle.Bold),
                    Brushes.Black, 200, y);
                y += 40;

                DataRow row = dt.Rows[0];

                ev.Graphics.DrawString("Mã Phiếu Mượn: " + row["MaPhieuMuon"], font, Brushes.Black, 50, y); y += 25;
                ev.Graphics.DrawString("Đọc Giả: " + row["HoTen"], font, Brushes.Black, 50, y); y += 25;
                ev.Graphics.DrawString("Ngày Mượn: " +
                    Convert.ToDateTime(row["NgayMuon"]).ToString("dd/MM/yyyy"),
                    font, Brushes.Black, 50, y); y += 40;

                ev.Graphics.DrawString("Danh sách sách mượn:", font, Brushes.Black, 50, y); y += 25;

                foreach (DataRow r in dt.Rows)
                {
                    ev.Graphics.DrawString("- " + r["TenDauSach"], font, Brushes.Black, 70, y);
                    y += 25;
                }
            };

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;

            if (preview.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Đã in phiếu mượn thành công!");
            }

        }

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            string maDG = txtMaDG.Text.Trim();
            string maSach = txtMaSach.Text.Trim();
            string maNV = txtMaNV.Text.Trim();

            if (maDG == "" || maSach == "" || maNV == "")
            {
                MessageBox.Show("Vui lòng nhập Mã Đọc Giả, Mã Sách và Mã Nhân Viên!");
                return;
            }

            DateTime ngayTra = dtpNgayTra.Value;
            DateTime ngayMuonn = dtpNgayMuon.Value;

            // Kiểm tra ngày mượn > ngày trả
            if (ngayMuonn > ngayTra)
            {
                MessageBox.Show("Ngày trả phải lớn hơn hoặc bằng ngày mượn!");
                return;
            }

            // Kiểm tra Đọc Giả
            string sqlDG = "SELECT * FROM DOCGIA WHERE MaDG = '" + maDG + "'";
            DataTable dtDG = db.getTable(sqlDG);

            // Kiểm tra Sách
            string sqlSach = "SELECT * FROM SACH WHERE MaSach = '" + maSach + "'";
            DataTable dtSach = db.getTable(sqlSach);

            // Kiểm tra Nhân Viên
            string sqlNV = "SELECT * FROM NHANVIEN WHERE MaNV = '" + maNV + "'";
            DataTable dtNV = db.getTable(sqlNV);

            if (dtDG.Rows.Count == 0 || dtSach.Rows.Count == 0 || dtNV.Rows.Count == 0)
            {
                MessageBox.Show("Mã Đọc Giả, Mã Sách hoặc Mã Nhân Viên không tồn tại!");
                return;
            }

           
            string sqlCheckMuon = @"
        SELECT ct.MaSach
        FROM CHITIETPHIEUMUON ct
        INNER JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
        LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
        WHERE ct.MaSach = '" + maSach + @"'
        AND pt.MaPhieuMuon IS NULL";

            DataTable dtCheckMuon = db.getTable(sqlCheckMuon);

            if (dtCheckMuon.Rows.Count > 0)
            {
                MessageBox.Show("Mã sách này đang được mượn, không thể mượn tiếp!");
                return;
            }

            DateTime ngayMuon = dtpNgayMuon.Value;

            // Thêm phiếu mượn
            string sqlInsertPM = "INSERT INTO PHIEUMUON(MaDG, MaNV, NgayMuon, NgayPhaiTra) " +
                                 "VALUES('" + maDG + "', '" + maNV + "', '" +
                                 ngayMuon.ToString("yyyy-MM-dd") + "', '" +
                                 ngayTra.ToString("yyyy-MM-dd") + "'); " +
                                 "SELECT SCOPE_IDENTITY() AS NewID;";

            DataTable dtPM = db.getTable(sqlInsertPM);
            int maPhieuMuon = Convert.ToInt32(dtPM.Rows[0]["NewID"]);

            // Thêm chi tiết phiếu mượn
            string sqlInsertCT = "INSERT INTO CHITIETPHIEUMUON(MaPhieuMuon, MaSach) VALUES(" +
                                 maPhieuMuon + ", '" + maSach + "')";

            db.update(sqlInsertCT);

            // Cập nhật trạng thái sách
            string sqlUpdateSach = "UPDATE SACH SET TinhTrang = N'Đang mượn' WHERE MaSach = '" + maSach + "'";
            db.update(sqlUpdateSach);

            MessageBox.Show("Cho mượn sách thành công!");
            HienThiDanhSachMuon();
        }

        void HienThiDanhSachMuon()
        {
            string sql = @"
            SELECT ROW_NUMBER() OVER(ORDER BY pm.MaPhieuMuon) AS STT,
                   pm.MaPhieuMuon,
                   pm.MaDG,
                   ct.MaSach,
                   pm.NgayMuon,
                   pm.NgayPhaiTra,

                   CASE
                       WHEN pt.MaPhieuMuon IS NULL THEN N'Chưa trả'
                       ELSE N'Đã trả'
                   END AS TrangThaiTra,

                   ISNULL(pt.TienPhatKyNay,0) AS TienPhat

            FROM PHIEUMUON pm
            INNER JOIN CHITIETPHIEUMUON ct
                ON pm.MaPhieuMuon = ct.MaPhieuMuon
            LEFT JOIN PHIEUTRA pt
                ON pm.MaPhieuMuon = pt.MaPhieuMuon";

            DgvMuonTra.DataSource = db.getTable(sql);
        }

        private void btnXacNhanTra_Click(object sender, EventArgs e)
        {
            string maPhieuMuon = txtMaPhieuMuon.Text.Trim();
            string maNV = txtMaNV.Text.Trim();

            if (maPhieuMuon == "" || maNV == "")
            {
                MessageBox.Show("Vui lòng nhập Mã Phiếu Mượn và Mã Nhân Viên!");
                return;
            }

            // Kiểm tra Phiếu Mượn
            string sqlPM = "SELECT * FROM PHIEUMUON WHERE MaPhieuMuon = " + maPhieuMuon;
            DataTable dtPM = db.getTable(sqlPM);
            if (dtPM.Rows.Count == 0)
            {
                MessageBox.Show("Mã Phiếu Mượn không tồn tại!");
                return;
            }

            // Kiểm tra Nhân Viên
            string sqlNV = "SELECT * FROM NHANVIEN WHERE MaNV = '" + maNV + "'";
            DataTable dtNV = db.getTable(sqlNV);
            if (dtNV.Rows.Count == 0)
            {
                MessageBox.Show("Mã Nhân Viên không tồn tại!");
                return;
            }

            DateTime ngayTra = dtpNgayTra.Value;

            // Tính tiền phạt (ví dụ: quá hạn 7 ngày thì phạt 5000/ngày)
            DateTime ngayMuon = Convert.ToDateTime(dtPM.Rows[0]["NgayMuon"]);
            int soNgayTre = (ngayTra - ngayMuon).Days - 7;
            int tienPhat = (soNgayTre > 0) ? soNgayTre * 5000 : 0;

            // Thêm phiếu trả
            string sqlInsertPT = "INSERT INTO PHIEUTRA(MaPhieuMuon, MaNV, NgayTra, TienPhatKyNay) " +
                                 "VALUES(" + maPhieuMuon + ", '" + maNV + "', '" +
                                 ngayTra.ToString("yyyy-MM-dd") + "', " + tienPhat + ")";
            db.update(sqlInsertPT);

            // Cập nhật tình trạng sách về 'Có sẵn'
            string sqlCT = "SELECT MaSach FROM CHITIETPHIEUMUON WHERE MaPhieuMuon = " + maPhieuMuon;
            DataTable dtCT = db.getTable(sqlCT);
            foreach (DataRow row in dtCT.Rows)
            {
                string maSach = row["MaSach"].ToString();
                string sqlUpdateSach = "UPDATE SACH SET TinhTrang = N'Có sẵn' WHERE MaSach = '" + maSach + "'";
                db.update(sqlUpdateSach);
            }

            MessageBox.Show("Trả sách thành công!");
            HienThiDanhSachMuon(); // refresh lại danh sách
        }

        private void btnXemDs_Click(object sender, EventArgs e)
        {
            HienThiDanhSachMuon();
        }
    }
}
