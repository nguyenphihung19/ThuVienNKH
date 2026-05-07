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
            //            string maDG = txtMaDG.Text.Trim();
            //            string maSach = txtMaSach.Text.Trim();


            //            if (maDG == "" || maSach == "" )
            //            {
            //                MessageBox.Show("Vui lòng nhập Mã Đọc Giả, Mã Sách và Mã Nhân Viên!");
            //                return;
            //            }

            //            DateTime ngayTra = dtpNgayTra.Value;
            //            DateTime ngayMuonn = dtpNgayMuon.Value;

            //            // Kiểm tra ngày mượn > ngày trả
            //            if (ngayMuonn > ngayTra)
            //            {
            //                MessageBox.Show("Ngày trả phải lớn hơn hoặc bằng ngày mượn!");
            //                return;
            //            }

            //            // Kiểm tra Đọc Giả
            //            string sqlDG = "SELECT * FROM DOCGIA WHERE MaDG = '" + maDG + "'";
            //            DataTable dtDG = db.getTable(sqlDG);

            //            // Kiểm tra Sách
            //            string sqlSach = "SELECT * FROM SACH WHERE MaSach = '" + maSach + "'";
            //            DataTable dtSach = db.getTable(sqlSach);

            //            // Kiểm tra Nhân Viên
            //            //string sqlNV = "SELECT * FROM NHANVIEN WHERE MaNV = '" + maNV + "'";
            //            //DataTable dtNV = db.getTable(sqlNV);

            //            if (dtDG.Rows.Count == 0 || dtSach.Rows.Count == 0 )
            //            {
            //                MessageBox.Show("Mã Đọc Giả, Mã Sách hoặc Mã Nhân Viên không tồn tại!");
            //                return;
            //            }


            //            // --- Kiểm tra số sách mượn tối đa ---
            //            string sqlSoSachHienTai = @"
            //SELECT SoSachMuon
            //FROM DOCGIA
            //WHERE MaDG = '" + maDG + "'";
            //            int soSachHienTai = Convert.ToInt32(db.getScalar(sqlSoSachHienTai));

            //            string sqlQuyDinh = "SELECT SoSachMuonToiDa FROM QUYDINH";
            //            int soSachToiDa = Convert.ToInt32(db.getScalar(sqlQuyDinh));

            //            if (soSachHienTai + 1 > soSachToiDa)
            //            {
            //                MessageBox.Show("Không thể mượn thêm sách. Đã vượt quá số sách quy định!");
            //                return;
            //            }

            //            // --- Kiểm tra sách đã mượn chưa trả ---
            //            string sqlCheckMuon = @"
            //SELECT ct.MaSach
            //FROM CHITIETPHIEUMUON ct
            //INNER JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
            //LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
            //WHERE ct.MaSach = '" + maSach + "' AND pt.MaPhieuMuon IS NULL";

            //            DataTable dtCheckMuon = db.getTable(sqlCheckMuon);

            //            if (dtCheckMuon.Rows.Count > 0)
            //            {
            //                MessageBox.Show("Sách này đang được mượn và chưa trả!");
            //                return;
            //            }

            //            // Nếu qua hết kiểm tra thì tiến hành thêm phiếu mượn
            //            // ...

            string maDG = txtMaDG.Text.Trim();
            string maSach = txtMaSach.Text.Trim();

            // Kiểm tra rỗng
            if (maDG == "" || maSach == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Đọc Giả và Mã Sách!");
                return;
            }

            DateTime ngayMuon = dtpNgayMuon.Value.Date;
            DateTime ngayTra = dtpNgayTra.Value.Date;
        
            // Kiểm tra ngày trả
            if (ngayTra > ngayMuon)
            {
                MessageBox.Show("Ngày trả phải lớn hơn hoặc bằng ngày mượn!");
                return;
            }

            //DateTime ngayMuon = dtpNgayMuon.Value.Date;
            //DateTime ngayTra = dtpNgayTra.Value.Date;

            // Kiểm tra ngày trả
          
       

            Console.WriteLine(ngayMuon + " " + ngayTra);

            string sqlQDNgayMuon = @"
SELECT GiaTri
FROM QUYDINH
WHERE MaQD = 'QD06'";

            int soNgayMuonToiDa =
                Convert.ToInt32(db.getScalar(sqlQDNgayMuon));

            // Tính số ngày mượn
            //int soNgayMuon = (ngayTra - ngayMuon).Days;
            int soNgayMuon = (ngayMuon - ngayTra).Days;
            // Kiểm tra vượt quy định
            if (soNgayMuon > soNgayMuonToiDa)
            {
                MessageBox.Show(
                    "Không được mượn quá "
                    + soNgayMuonToiDa
                    + " ngày theo quy định!"
                );
                return;
            }

            Console.WriteLine("so ngay muon" + soNgayMuon + "so ngay toi da" + soNgayMuonToiDa);

            string sqlDG = @"
    SELECT *
    FROM DOCGIA
    WHERE MaDG = '" + maDG + "'";

            DataTable dtDG = db.getTable(sqlDG);

            if (dtDG.Rows.Count == 0)
            {
                MessageBox.Show("Mã đọc giả không tồn tại!");
                return;
            }


            string sqlSach = @"
    SELECT *
    FROM SACH
    WHERE MaSach = '" + maSach + "'";

            DataTable dtSach = db.getTable(sqlSach);

            if (dtSach.Rows.Count == 0)
            {
                MessageBox.Show("Mã sách không tồn tại!");
                return;
            }

            string sqlCheckMuon = @"
    SELECT ct.MaSach
    FROM CHITIETPHIEUMUON ct
    INNER JOIN PHIEUMUON pm 
        ON ct.MaPhieuMuon = pm.MaPhieuMuon
    LEFT JOIN PHIEUTRA pt 
        ON pm.MaPhieuMuon = pt.MaPhieuMuon
    WHERE ct.MaSach = '" + maSach + @"'
          AND pt.MaPhieuMuon IS NULL";

            DataTable dtCheckMuon = db.getTable(sqlCheckMuon);

            if (dtCheckMuon.Rows.Count > 0)
            {
                MessageBox.Show("Sách này đang được mượn và chưa trả!");
                return;
            }

            string sqlSoSachDangMuon = @"
    SELECT SoSachMuon
    FROM DOCGIA
    WHERE MaDG = '" + maDG + "'";

            int soSachDangMuon = Convert.ToInt32(db.getScalar(sqlSoSachDangMuon));


            string sqlQuyDinh = @"
    SELECT GiaTri
    FROM QUYDINH
    WHERE MaQD = 'QD05'";

            int soSachToiDa = Convert.ToInt32(db.getScalar(sqlQuyDinh));

            // Kiểm tra vượt quá quy định
            if (soSachDangMuon >= soSachToiDa)
            {
                MessageBox.Show("Đọc giả đã mượn tối đa số sách cho phép!");
                return;
            }



            MessageBox.Show("Kiểm tra thành công, có thể cho mượn sách!");

            try
            {

                string sqlInsertPM = @"
    INSERT INTO PHIEUMUON(MaDG, NgayMuon, NgayPhaiTra)
    VALUES(
        '" + maDG + @"',
        '" + ngayMuon.ToString("yyyy-MM-dd") + @"',
        '" + ngayTra.ToString("yyyy-MM-dd") + @"'
    );

    SELECT SCOPE_IDENTITY() AS NewID;
    ";

                DataTable dtPM = db.getTable(sqlInsertPM);

                // Kiểm tra tạo phiếu mượn
                if (dtPM.Rows.Count == 0)
                {
                    MessageBox.Show("Không thể tạo phiếu mượn!");
                    return;
                }

                // Lấy mã phiếu mượn mới
                int maPhieuMuon = Convert.ToInt32(dtPM.Rows[0]["NewID"]);


                string sqlInsertCT = @"
    INSERT INTO CHITIETPHIEUMUON(MaPhieuMuon, MaSach)
    VALUES(
        " + maPhieuMuon + @",
        '" + maSach + @"'
    )";

                int kqCT = db.update(sqlInsertCT);

                if (kqCT <= 0)
                {
                    MessageBox.Show("Không thể thêm chi tiết phiếu mượn!");
                    return;
                }


                string sqlUpdateDG = @"
    UPDATE DOCGIA
    SET SoSachMuon = SoSachMuon + 1
    WHERE MaDG = '" + maDG + @"'";

                db.update(sqlUpdateDG);


                MessageBox.Show("Cho mượn sách thành công!");
                HienThiDanhSachMuon();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            doiMa();
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
            END AS TrangThaiTra

            FROM PHIEUMUON pm
            INNER JOIN CHITIETPHIEUMUON ct
            ON pm.MaPhieuMuon = ct.MaPhieuMuon
            LEFT JOIN PHIEUTRA pt
            ON pm.MaPhieuMuon = pt.MaPhieuMuon";



            DgvMuonTra.DataSource = db.getTable(sql);
        }

        private void btnXacNhanTra_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieuMuon = txtMaPhieuMuon.Text.Trim();


                if (maPhieuMuon == "")
                {
                    MessageBox.Show("Vui lòng nhập Mã Phiếu Mượn!");
                    return;
                }

                string sqlPM = @"
    SELECT *
    FROM PHIEUMUON
    WHERE MaPhieuMuon = " + maPhieuMuon;

                DataTable dtPM = db.getTable(sqlPM);

                if (dtPM.Rows.Count == 0)
                {
                    MessageBox.Show("Mã Phiếu Mượn không tồn tại!");
                    return;
                }

                string sqlCheckTra = @"
    SELECT *
    FROM PHIEUTRA
    WHERE MaPhieuMuon = " + maPhieuMuon;

                DataTable dtCheckTra = db.getTable(sqlCheckTra);

                if (dtCheckTra.Rows.Count > 0)
                {
                    MessageBox.Show("Sách đã được trả trước đó!");
                    return;
                }

                DateTime ngayTra = dtpNgayTra.Value.Date;

                DateTime ngayPhaiTra =
                    Convert.ToDateTime(dtPM.Rows[0]["NgayPhaiTra"]);

                string maDG = dtPM.Rows[0]["MaDG"].ToString();


                int soNgayTre = (ngayTra - ngayPhaiTra).Days;

                if (soNgayTre < 0)
                    soNgayTre = 0;


                string sqlTienPhatQD = @"
    SELECT GiaTri
    FROM QUYDINH
    WHERE MaQD = 'QD07'";

                int tienPhatMoiNgay =
                    Convert.ToInt32(db.getScalar(sqlTienPhatQD));

                int tienPhat = soNgayTre * tienPhatMoiNgay;


                string sqlInsertPT = @"
    INSERT INTO PHIEUTRA
    (
        MaPhieuMuon,
        NgayTra,
        TienPhatKyNay
    )
    VALUES
    (
        " + maPhieuMuon + @",
        '" + ngayTra.ToString("yyyy-MM-dd") + @"',
        " + tienPhat + @"
    )";

                int kqPT = db.update(sqlInsertPT);

                if (kqPT <= 0)
                {
                    MessageBox.Show("Không thể tạo phiếu trả!");
                    return;
                }


                string sqlCT = @"
    SELECT MaSach
    FROM CHITIETPHIEUMUON
    WHERE MaPhieuMuon = " + maPhieuMuon;

                DataTable dtCT = db.getTable(sqlCT);

                foreach (DataRow row in dtCT.Rows)
                {
                    string maSach = row["MaSach"].ToString();

                    string sqlUpdateSach = @"
        UPDATE SACH
        SET TinhTrang = N'Có sẵn'
        WHERE MaSach = '" + maSach + "'";

                    db.update(sqlUpdateSach);
                }

                string sqlUpdateDG = @"
    UPDATE DOCGIA
    SET SoSachMuon = SoSachMuon - 1
    WHERE MaDG = '" + maDG + "'";

                db.update(sqlUpdateDG);


                MessageBox.Show("Trả sách thành công!");

                HienThiDanhSachMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            doiMa();
        }

        private void btnXemDs_Click(object sender, EventArgs e)
        {
            HienThiDanhSachMuon();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void DgvMuonTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaDG_TextChanged(object sender, EventArgs e)
        {
            string maDG = txtMaDG.Text.Trim();

            if (string.IsNullOrEmpty(maDG))
            {
                txtTenDocGIa.Text = "";
                txtSSDM.Text = "";
                return;
            }

            // Lấy tên độc giả
            string sqlTenDG = @"SELECT HoTen FROM DOCGIA WHERE MaDG = '" + maDG + "'";
            DataTable dtTenDG = db.getTable(sqlTenDG);

            if (dtTenDG.Rows.Count > 0)
            {
                txtTenDocGIa.Text = dtTenDG.Rows[0]["HoTen"].ToString();
            }
            else
            {
                txtTenDocGIa.Text = ""; // không tìm thấy thì để trống
            }

            // Lấy số sách đã mượn (chưa trả)
            string sqlSoSachHienTai = @"
    SELECT COUNT(*) 
    FROM PHIEUMUON pm
    INNER JOIN CHITIETPHIEUMUON ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
    LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
    WHERE pm.MaDG = '" + maDG + @"' AND pt.MaPhieuMuon IS NULL";

            int soSachHienTai = Convert.ToInt32(db.getScalar(sqlSoSachHienTai));

            // Hiển thị lên TextBox txtSSDM
            txtSSDM.Text = soSachHienTai.ToString();
        }

        private void doiMa()
        {
            string maDG = txtMaDG.Text.Trim();

            if (string.IsNullOrEmpty(maDG))
            {
                txtTenDocGIa.Text = "";
                txtSSDM.Text = "";
                return;
            }

            // Lấy tên độc giả
            string sqlTenDG = @"SELECT HoTen FROM DOCGIA WHERE MaDG = '" + maDG + "'";
            DataTable dtTenDG = db.getTable(sqlTenDG);

            if (dtTenDG.Rows.Count > 0)
            {
                txtTenDocGIa.Text = dtTenDG.Rows[0]["HoTen"].ToString();
            }
            else
            {
                txtTenDocGIa.Text = ""; // không tìm thấy thì để trống
            }

            // Lấy số sách đã mượn (chưa trả)
            string sqlSoSachHienTai = @"
    SELECT COUNT(*) 
    FROM PHIEUMUON pm
    INNER JOIN CHITIETPHIEUMUON ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
    LEFT JOIN PHIEUTRA pt ON pm.MaPhieuMuon = pt.MaPhieuMuon
    WHERE pm.MaDG = '" + maDG + @"' AND pt.MaPhieuMuon IS NULL";

            int soSachHienTai = Convert.ToInt32(db.getScalar(sqlSoSachHienTai));

            // Hiển thị lên TextBox txtSSDM
            txtSSDM.Text = soSachHienTai.ToString();
        }
        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text.Trim();

            if (string.IsNullOrEmpty(maSach))
            {
                txtTensach.Text = "";
                return;
            }

            // Lấy tên sách theo mã sách
            string sql = @"
        SELECT ds.TenDauSach
        FROM SACH s
        INNER JOIN DAUSACH ds ON s.MaDauSach = ds.MaDauSach
        WHERE s.MaSach = N'" + maSach + "'";

            DataTable dt = db.getTable(sql);

            if (dt.Rows.Count > 0)
            {
                txtTensach.Text = dt.Rows[0]["TenDauSach"].ToString();
            }
            else
            {
                txtTensach.Text = "";
            }
        }

        private void btnXemSachDaMuon_Click(object sender, EventArgs e)
        {

        }

        private void btnXemSachDaMuon_Click_1(object sender, EventArgs e)
        {
            string maDG = txtMaDG.Text.Trim();

            // Kiểm tra rỗng
            if (maDG == "")
            {
                MessageBox.Show("Vui lòng nhập Mã Đọc Giả!");
                return;
            }

            // Kiểm tra đọc giả tồn tại
            string sqlDG = @"
    SELECT *
    FROM DOCGIA
    WHERE MaDG = '" + maDG + "'";

            DataTable dtDG = db.getTable(sqlDG);

            if (dtDG.Rows.Count == 0)
            {
                MessageBox.Show("Mã Đọc Giả không tồn tại!");
                return;
            }

            // Lấy danh sách sách đang mượn
            //        string sql = @"
            //SELECT 
            //    ROW_NUMBER() OVER(ORDER BY pm.MaPhieuMuon) AS STT,
            //    pm.MaPhieuMuon,
            //    ct.MaSach,
            //    s.TenDauSach,
            //    pm.NgayMuon,
            //    pm.NgayPhaiTra
            //FROM PHIEUMUON pm
            //INNER JOIN CHITIETPHIEUMUON ct
            //    ON pm.MaPhieuMuon = ct.MaPhieuMuon
            //INNER JOIN SACH s
            //    ON ct.MaSach = s.MaSach
            //LEFT JOIN PHIEUTRA pt
            //    ON pm.MaPhieuMuon = pt.MaPhieuMuon
            //WHERE pm.MaDG = '" + maDG + @"'
            //      AND pt.MaPhieuMuon IS NULL";

            string sql = @"
SELECT 
    ROW_NUMBER() OVER(ORDER BY pm.MaPhieuMuon) AS STT,
    pm.MaPhieuMuon,
    ct.MaSach,
    ds.TenDauSach,
    pm.NgayMuon,
    pm.NgayPhaiTra
FROM PHIEUMUON pm

INNER JOIN CHITIETPHIEUMUON ct
    ON pm.MaPhieuMuon = ct.MaPhieuMuon

INNER JOIN SACH s
    ON ct.MaSach = s.MaSach

INNER JOIN DAUSACH ds
    ON s.MaDauSach = ds.MaDauSach

LEFT JOIN PHIEUTRA pt
    ON pm.MaPhieuMuon = pt.MaPhieuMuon

WHERE pm.MaDG = '" + maDG + @"'
      AND pt.MaPhieuMuon IS NULL";

            DataTable dt = db.getTable(sql);

            // Hiển thị lên DataGridView
            DgvMuonTra.DataSource = db.getTable(sql);

            // Nếu không có sách
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Đọc giả hiện không mượn sách nào!");
            }
        }
    }
}
    
