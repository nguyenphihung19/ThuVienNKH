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
                    DtpNgaysinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                    TxtDiaChi.Text = row["DiaChi"].ToString();
                    TxtEmail.Text = row["Email"].ToString();
                    TxtSDT.Text = row["SoDT"].ToString(); // Dùng SoDT cho khớp với DB
                    Dtpngaylapthe.Value = Convert.ToDateTime(row["NgayLapThe"]);
                    DtpNgayhethan.Value = Convert.ToDateTime(row["NgayHetHan"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnChinhSua_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);

            TxtDocGia.Enabled = false; // Mã độc giả thường không được phép sửa
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Sửa SoDienThoai thành SoDT trong câu lệnh SQL
            string sql = string.Format("UPDATE DOCGIA SET HoTen=N'{0}', NgaySinh='{1}', DiaChi=N'{2}', Email='{3}', SoDT=N'{4}' WHERE MaDG='{5}'",
                TxtHoTen.Text,
                DtpNgaysinh.Value.ToString("yyyy-MM-dd"),
                TxtDiaChi.Text,
                TxtEmail.Text,
                TxtSDT.Text,         // Giá trị mới cho số điện thoại
                TxtDocGia.Text);     // Điều kiện MaDG

        }
        private void SetReadOnly(bool readOnly)
        {
            TxtHoTen.ReadOnly = readOnly;
            TxtDiaChi.ReadOnly = readOnly;
            TxtEmail.ReadOnly = readOnly;
            TxtSDT.ReadOnly = readOnly;
            DtpNgaysinh.Enabled = !readOnly;
        }
    }
}
