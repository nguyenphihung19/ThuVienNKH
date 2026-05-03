using System;
using System.Data;
using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class ucTheoDoiCaNhan : UserControl
    {
        DBConnect db = new DBConnect();

        public ucTheoDoiCaNhan()
        {
            InitializeComponent();
            // Đăng ký sự kiện Load để tự động chạy khi hiển thị
            this.Load += UcTheoDoiCaNhan_Load;
        }

        private void UcTheoDoiCaNhan_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có MaDocGia trong Session chưa
            if (!string.IsNullOrEmpty(Session.MaDocGia))
            {
                LoadData(Session.MaDocGia);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin đăng nhập của độc giả!");
            }
            SetReadOnly(true);
        }

        public void LoadData(string maDG)
        {
            try
            {
                string sql = "SELECT * FROM DOCGIA WHERE MaDG = N'" + maDG + "'";
                DataTable dt = db.getTable(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    TxtHoTen.Text = row["HoTen"].ToString();
                    TxtDocGia.Text = row["MaDG"].ToString();
                    TxtDiaChi.Text = row["DiaChi"].ToString();
                    TxtEmail.Text = row["Email"].ToString();
                    TxtSDT.Text = row["SoDT"].ToString();

                    // Gán ngày tháng an toàn
                    DtpNgaysinh.Value = (row["NgaySinh"] != DBNull.Value) ? Convert.ToDateTime(row["NgaySinh"]) : DateTime.Now;
                    Dtpngaylapthe.Value = (row["NgayLapThe"] != DBNull.Value) ? Convert.ToDateTime(row["NgayLapThe"]) : DateTime.Now;
                    DtpNgayhethan.Value = (row["NgayHetHan"] != DBNull.Value) ? Convert.ToDateTime(row["NgayHetHan"]) : DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void SetReadOnly(bool readOnly)
        {
            TxtHoTen.ReadOnly = readOnly;
            TxtDiaChi.ReadOnly = readOnly;
            TxtEmail.ReadOnly = readOnly;
            TxtSDT.ReadOnly = readOnly;
            DtpNgaysinh.Enabled = !readOnly;
        }

        private void BtnChinhSua_Click_1(object sender, EventArgs e)
        {
            SetReadOnly(false);
            TxtDocGia.Enabled = false; // Luôn khóa mã vì không được sửa ID
        }

        private void BtnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("UPDATE DOCGIA SET HoTen=N'{0}', NgaySinh='{1}', DiaChi=N'{2}', Email='{3}', SoDT=N'{4}' WHERE MaDG='{5}'",
                    TxtHoTen.Text, DtpNgaysinh.Value.ToString("yyyy-MM-dd"), TxtDiaChi.Text, TxtEmail.Text, TxtSDT.Text, TxtDocGia.Text);

                int ketQua = db.update(sql); // Gọi đúng hàm update trong DBConnect của bạn

                if (ketQua > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    SetReadOnly(true);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại, vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message);
            }
        }
    }
}