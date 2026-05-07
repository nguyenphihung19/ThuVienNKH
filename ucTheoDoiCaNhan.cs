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

            // Đăng ký sự kiện Load
            this.Load += UcTheoDoiCaNhan_Load;
        }

        private void UcTheoDoiCaNhan_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đăng nhập
                if (!string.IsNullOrEmpty(Session.MaDocGia))
                {
                    LoadData(Session.MaDocGia);
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy thông tin đăng nhập của độc giả!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }

                SetReadOnly(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải giao diện: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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

                    TxtHoTen.Text = row["HoTen"]?.ToString();
                    TxtDocGia.Text = row["MaDG"]?.ToString();
                    TxtDiaChi.Text = row["DiaChi"]?.ToString();
                    TxtEmail.Text = row["Email"]?.ToString();
                    TxtSDT.Text = row["SoDT"]?.ToString();

                    // Gán ngày sinh
                    if (row["NgaySinh"] != DBNull.Value)
                        DtpNgaysinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                    else
                        DtpNgaysinh.Value = DateTime.Now;

                    // Gán ngày lập thẻ
                    if (row["NgayLapThe"] != DBNull.Value)
                        Dtpngaylapthe.Value = Convert.ToDateTime(row["NgayLapThe"]);
                    else
                        Dtpngaylapthe.Value = DateTime.Now;

                    // Gán ngày hết hạn
                    if (row["NgayHetHan"] != DBNull.Value)
                        DtpNgayhethan.Value = Convert.ToDateTime(row["NgayHetHan"]);
                    else
                        DtpNgayhethan.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy dữ liệu độc giả!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SetReadOnly(bool readOnly)
        {
            TxtHoTen.ReadOnly = readOnly;
            TxtDiaChi.ReadOnly = readOnly;
            TxtEmail.ReadOnly = readOnly;
            TxtSDT.ReadOnly = readOnly;

            DtpNgaysinh.Enabled = !readOnly;

            // Luôn khóa mã độc giả
            TxtDocGia.ReadOnly = true;

            // Không cho sửa ngày lập thẻ và ngày hết hạn
            Dtpngaylapthe.Enabled = false;
            DtpNgayhethan.Enabled = false;
        }

        private void BtnChinhSua_Click_1(object sender, EventArgs e)
        {
            SetReadOnly(false);

            MessageBox.Show(
                "Đã bật chế độ chỉnh sửa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void BtnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra rỗng
                if (string.IsNullOrWhiteSpace(TxtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(TxtEmail.Text))
                {
                    MessageBox.Show(
                        "Vui lòng nhập đầy đủ Họ tên và Email!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // SQL cập nhật
                string sql = string.Format(
                    @"UPDATE DOCGIA 
                      SET HoTen = N'{0}',
                          NgaySinh = '{1}',
                          DiaChi = N'{2}',
                          Email = '{3}',
                          SoDT = N'{4}'
                      WHERE MaDG = '{5}'",

                    TxtHoTen.Text.Trim().Replace("'", "''"),
                    DtpNgaysinh.Value.ToString("yyyy-MM-dd"),
                    TxtDiaChi.Text.Trim().Replace("'", "''"),
                    TxtEmail.Text.Trim().Replace("'", "''"),
                    TxtSDT.Text.Trim().Replace("'", "''"),
                    TxtDocGia.Text.Trim()
                );

                int ketQua = db.update(sql);

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Cập nhật thông tin thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    SetReadOnly(true);

                    // Load lại dữ liệu mới
                    LoadData(TxtDocGia.Text.Trim());
                }
                else
                {
                    MessageBox.Show(
                        "Cập nhật thất bại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi lưu dữ liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}