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
    public partial class ucTheoDoiCaNhan : UserControl
    {
        DBConnect db = new DBConnect();

        public ucTheoDoiCaNhan()
        {
            InitializeComponent();
            SetReadOnly(true);
        }

        // --- HÀM TẢI DỮ LIỆU (QUAN TRỌNG NHẤT) ---
        public void LoadData(string maDG)
        {
            try
            {
                // 1. Lấy thông tin cá nhân (Đã có sẵn)
                string sql = "SELECT * FROM DOCGIA WHERE MaDG = N'" + maDG + "'";
                DataTable dt = db.getTable(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    TxtHoTen.Text = row["HoTen"].ToString();
                    TxtDocGia.Text = row["MaDG"].ToString();
                    DtpNgaysinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                    TxtDiachi.Text = row["DiaChi"].ToString();
                    TxtEmail.Text = row["Email"].ToString();
                    Dtpngaylapthe.Value = Convert.ToDateTime(row["NgayLapThe"]);
                    DtpNgayhethan.Value = Convert.ToDateTime(row["NgayHetHan"]);
                }

                // 2. Lấy thống kê vào Label (Đã có sẵn)
                string sqlStats = @"
            SELECT 
                (SELECT COUNT(*) FROM CHITIETPHIEUMUON ct JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon WHERE pm.MaDG = N'" + maDG + @"' AND ct.TrangThai = N'Đang mượn') AS SoSachMuon,
                (SELECT SUM(TienNo) FROM PHIEUTRA pt JOIN PHIEUMUON pm ON pt.MaPhieuMuon = pm.MaPhieuMuon WHERE pm.MaDG = N'" + maDG + @"') AS TongTienPhat,
                (SELECT COUNT(*) FROM CHITIETPHIEUMUON ct JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon WHERE pm.MaDG = N'" + maDG + @"' AND pm.NgayPhaiTra < GETDATE()) AS SoSachQuaHan";

                DataTable dtStats = db.getTable(sqlStats);
                if (dtStats != null && dtStats.Rows.Count > 0)
                {
                    DataRow rowStats = dtStats.Rows[0];
                    lblSachMuon.Text = rowStats["SoSachMuon"].ToString();
                    lblTienPhat.Text = string.Format("{0:N0} VNĐ", rowStats["TongTienPhat"] == DBNull.Value ? 0 : rowStats["TongTienPhat"]);
                    lblSachQuaHan.Text = rowStats["SoSachQuaHan"].ToString();
                }

                // 3. ĐỔ DỮ LIỆU VÀO RICHTEXTBOX (ĐÂY LÀ ĐOẠN ÔNG CẦN)
                string sqlLichSu = @"
            SELECT s.TenSach, pm.NgayMuon, pm.NgayPhaiTra, ct.TrangThai 
            FROM CHITIETPHIEUMUON ct
            JOIN PHIEUMUON pm ON ct.MaPhieuMuon = pm.MaPhieuMuon
            JOIN SACH s ON ct.MaSach = s.MaSach
            WHERE pm.MaDG = N'" + maDG + @"'";

                DataTable dtLichSu = db.getTable(sqlLichSu);

                // LƯU Ý: Thay "rtbLichSu" bằng tên RichTextBox trên form của ông
                rtbLichSu.Clear();
                rtbLichSu.AppendText("📜 LỊCH SỬ MƯỢN SÁCH CỦA BẠN:\n\n");

                if (dtLichSu != null && dtLichSu.Rows.Count > 0)
                {
                    foreach (DataRow r in dtLichSu.Rows)
                    {
                        string dòng = string.Format("- Sách: {0}\n  Ngày mượn: {1:dd/MM/yyyy}\n  Trạng thái: {2}\n\n",
                            r["TenSach"], r["NgayMuon"], r["TrangThai"]);
                        rtbLichSu.AppendText(dòng);
                    }
                }
                else
                {
                    rtbLichSu.AppendText("Hiện tại bạn chưa có lịch sử mượn sách.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }

        // --- CÁC HÀM XỬ LÝ SỰ KIỆN ---
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string sql = string.Format("UPDATE DOCGIA SET HoTen=N'{0}', NgaySinh='{1}', DiaChi=N'{2}', Email='{3}' WHERE MaDG='{4}'",
                TxtHoTen.Text, DtpNgaysinh.Value.ToString("yyyy-MM-dd"), TxtDiachi.Text, TxtEmail.Text, TxtDocGia.Text);

            int n = db.update(sql);
            if (n > 0)
            {
                MessageBox.Show("Lưu thông tin thành công!");
                SetReadOnly(true);
            }
            else
            {
                MessageBox.Show("Lưu thất bại!");
            }
        }

        private void BtnChinhSuaThongTin_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
            TxtDocGia.Enabled = false;
        }

        private void SetReadOnly(bool readOnly)
        {
            TxtHoTen.ReadOnly = readOnly;
            TxtDiachi.ReadOnly = readOnly;
            TxtEmail.ReadOnly = readOnly;
            DtpNgaysinh.Enabled = !readOnly;
        }

        // Các event trống (không xóa để tránh lỗi Designer)
        private void TxtHoTen_TextChanged(object sender, EventArgs e) { }
        private void TxtDocGia_TextChanged(object sender, EventArgs e) { }
        private void DtpNgaysinh_ValueChanged(object sender, EventArgs e) { }
        private void TxtDiachi_TextChanged(object sender, EventArgs e) { }
        private void TxtEmail_TextChanged(object sender, EventArgs e) { }
        private void Dtpngaylapthe_ValueChanged(object sender, EventArgs e) { }
        private void DtpNgayhethan_ValueChanged(object sender, EventArgs e) { }
        private void Pnlphiphat_Paint(object sender, PaintEventArgs e) { }
        private void Pnlsachmuon_Paint(object sender, PaintEventArgs e) { }
        private void Pnlsachquahan_Paint(object sender, PaintEventArgs e) { }
        private void Rtbhienthongtin_TextChanged(object sender, EventArgs e) { }
        private void ucTheoDoiCaNhan_Load(object sender, EventArgs e) { }
    }
}