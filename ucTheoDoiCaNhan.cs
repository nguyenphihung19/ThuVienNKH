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

        // --- HÀM TẢI DỮ LIỆU ---
        public void LoadData(string maDG)
        {
            try
            {
                // Chỉ còn lại việc lấy thông tin cá nhân
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
            TxtDocGia.Enabled = false; // Mã độc giả thường không được phép sửa
        }

        private void SetReadOnly(bool readOnly)
        {
            TxtHoTen.ReadOnly = readOnly;
            TxtDiachi.ReadOnly = readOnly;
            TxtEmail.ReadOnly = readOnly;
            DtpNgaysinh.Enabled = !readOnly;
        }

        private void TxtHoTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}