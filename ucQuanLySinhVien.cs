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
    public partial class ucQuanLySinhVien : UserControl
    {
        DBConnect db = new DBConnect();

        public ucQuanLySinhVien()
        {
            InitializeComponent();
            LoadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpNgayHetHan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ucQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadData();

            dtpNgayLapThe.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now.AddMonths(6);
        }

        public void LoadData()
        {
            try
            {
                string sql = "SELECT MaDG, HoTen, NgaySinh, DiaChi, Email, NgayLapThe, NgayHetHan, LoaiDG, SoDT " +
                             "FROM DOCGIA " +
                             "WHERE LoaiDG IN (N'Sinh viên', N'Giảng viên', N'Khách')";

                DataTable dt = db.getTable(sql);

                if (dt != null)
                {
                    dgvDocGia.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi hiển thị bảng: " + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void LamMoi()
        {
            txtMaDG.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSoDT.Clear();

            txtMaDG.ReadOnly = false;

            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayLapThe.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now.AddMonths(6);

            txtMaDG.Focus();
        }

        private void dtpNgayLapThe_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayHetHan.Value = dtpNgayLapThe.Value.AddMonths(6);
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];

                txtMaDG.Text = row.Cells["MaDG"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSoDT.Text = row.Cells["SoDT"].Value.ToString();
                cboLoaiDG.Text = row.Cells["LoaiDG"].Value.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value.ToString(), out DateTime ns))
                    dtpNgaySinh.Value = ns;

                if (DateTime.TryParse(row.Cells["NgayLapThe"].Value.ToString(), out DateTime nlt))
                    dtpNgayLapThe.Value = nlt;

                if (DateTime.TryParse(row.Cells["NgayHetHan"].Value.ToString(), out DateTime nhh))
                    dtpNgayHetHan.Value = nhh;

                txtMaDG.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDG.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ Mã và Tên độc giả!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string loaiDG = cboLoaiDG.Text.Trim();

            if (loaiDG == "Admin" || loaiDG == "Thủ thư")
            {
                MessageBox.Show(
                    "Module này chỉ dành cho Sinh viên, Giảng viên, Khách. Vui lòng thêm Admin/Thủ thư tại module Quản lý Nhân viên!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string checkSql = "SELECT MaDG FROM DOCGIA WHERE MaDG = '" + txtMaDG.Text.Trim() + "'";

            if (db.getTable(checkSql).Rows.Count > 0)
            {
                MessageBox.Show(
                    "Mã độc giả đã tồn tại!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                string sql = string.Format(
                    "INSERT INTO DOCGIA (MaDG, HoTen, NgaySinh, DiaChi, Email, NgayLapThe, NgayHetHan, LoaiDG, SoDT) " +
                    "VALUES ('{0}', N'{1}', '{2}', N'{3}', '{4}', '{5}', '{6}', N'{7}', '{8}')",
                    txtMaDG.Text.Trim(),
                    txtHoTen.Text.Trim(),
                    dtpNgaySinh.Value.ToString("yyyy-MM-dd"),
                    txtDiaChi.Text.Trim(),
                    txtEmail.Text.Trim(),
                    dtpNgayLapThe.Value.ToString("yyyy-MM-dd"),
                    dtpNgayHetHan.Value.ToString("yyyy-MM-dd"),
                    loaiDG,
                    txtSoDT.Text.Trim()
                );

                if (db.update(sql) > 0)
                {
                    MessageBox.Show(
                        "Thêm độc giả thành công!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    LoadData();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show(
                        "Thêm thất bại!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối: " + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maDG = txtMaDG.Text.Trim();

                if (string.IsNullOrEmpty(maDG))
                {
                    MessageBox.Show(
                        "Vui lòng chọn một độc giả từ danh sách để sửa!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                string sqlUpdate = string.Format(
                    "UPDATE DOCGIA SET HoTen=N'{1}', NgaySinh='{2}', DiaChi=N'{3}', Email='{4}', " +
                    "NgayLapThe='{5}', NgayHetHan='{6}', LoaiDG=N'{7}', SoDT='{8}' WHERE MaDG='{0}'",
                    maDG,
                    txtHoTen.Text.Trim(),
                    dtpNgaySinh.Value.ToString("yyyy-MM-dd"),
                    txtDiaChi.Text.Trim(),
                    txtEmail.Text.Trim(),
                    dtpNgayLapThe.Value.ToString("yyyy-MM-dd"),
                    dtpNgayHetHan.Value.ToString("yyyy-MM-dd"),
                    cboLoaiDG.Text,
                    txtSoDT.Text.Trim()
                );

                if (db.update(sqlUpdate) > 0)
                {
                    MessageBox.Show(
                        "Cập nhật thông tin thành công!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    LoadData();
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi sửa: " + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maDG = txtMaDG.Text.Trim();

            if (string.IsNullOrEmpty(maDG))
            {
                MessageBox.Show(
                    "Vui lòng chọn hoặc nhập Mã độc giả cần xóa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (MessageBox.Show(
                "Bạn có chắc chắn muốn xóa độc giả " + maDG + "?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) == DialogResult.Yes)
            {
                string sqlDelete = "DELETE FROM DOCGIA WHERE MaDG = '" + maDG + "'";

                try
                {
                    if (db.update(sqlDelete) > 0)
                    {
                        MessageBox.Show(
                            "Đã xóa độc giả thành công!",
                            "Cảnh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        LoadData();
                        LamMoi();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Không tìm thấy mã độc giả để xóa!",
                            "Cảnh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể xóa: " + ex.Message,
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string loaiSelected = cboLoaiDG.Text.Trim();

                if (string.IsNullOrEmpty(loaiSelected))
                {
                    MessageBox.Show(
                        "Vui lòng chọn Loại Độc Giả cần lọc!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    LoadData();
                    return;
                }

                string sqlFilter = string.Format(
                    "SELECT MaDG, HoTen, NgaySinh, DiaChi, Email, NgayLapThe, NgayHetHan, LoaiDG, SoDT " +
                    "FROM DOCGIA WHERE LoaiDG = N'{0}'",
                    loaiSelected
                );

                DataTable dt = db.getTable(sqlFilter);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvDocGia.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy dữ liệu cho loại: " + loaiSelected,
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    dgvDocGia.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi lọc dữ liệu: " + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        public string TaoMaDocGiaMoi()
        {
            string sql = "SELECT TOP 1 MaDG FROM DOCGIA ORDER BY MaDG DESC";

            DataTable dt = db.getTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                string maCu = dt.Rows[0]["MaDG"].ToString();
                string so = maCu.Substring(2);

                int soMoi = int.Parse(so) + 1;

                return "DG" + soMoi.ToString();
            }

            return "DG01";
        }
    }
}