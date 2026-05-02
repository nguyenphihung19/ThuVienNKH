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
            // Thiết lập giá trị mặc định cho các ô ngày tháng
            dtpNgayLapThe.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now.AddMonths(6); // Mặc định hạn 6 tháng
        }
        public void LoadData()
        {
            try
            {
                string sql = "SELECT MaDG, HoTen, NgaySinh, DiaChi, Email, NgayLapThe, NgayHetHan, LoaiDG, SoDT FROM DOCGIA";
                DataTable dt = db.getTable(sql); // Giả định db.getTable trả về DataTable

                if (dt != null)
                {
                    dgvDocGia.DataSource = dt;
                    // Tùy chỉnh hiển thị tiêu đề cột cho chuyên nghiệp
                    dgvDocGia.Columns["MaDG"].HeaderText = "Mã Độc Giả";
                    dgvDocGia.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvDocGia.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvDocGia.Columns["SoDT"].HeaderText = "Số Điện Thoại";

                    // Tự động dãn cột đều bảng
                    dgvDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị bảng: " + ex.Message);
            }
        }
        private void LamMoi()
        {
            txtMaDG.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSoDT.Clear();
            txtMaDG.ReadOnly = false; // Cho phép nhập mã mới
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

                // Ép kiểu ngày tháng an toàn
                if (DateTime.TryParse(row.Cells["NgaySinh"].Value.ToString(), out DateTime ns)) dtpNgaySinh.Value = ns;
                if (DateTime.TryParse(row.Cells["NgayLapThe"].Value.ToString(), out DateTime nlt)) dtpNgayLapThe.Value = nlt;
                if (DateTime.TryParse(row.Cells["NgayHetHan"].Value.ToString(), out DateTime nhh)) dtpNgayHetHan.Value = nhh;

                txtMaDG.ReadOnly = true; // Khóa mã độc giả khi đang ở chế độ chỉnh sửa
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maDG = txtMaDG.Text.Trim();
                if (string.IsNullOrEmpty(maDG) || string.IsNullOrEmpty(txtHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên độc giả!");
                    return;
                }

                // Kiểm tra trùng mã độc giả
                DataTable dt = db.getTable("SELECT * FROM DOCGIA WHERE MaDG='" + maDG + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã độc giả này đã tồn tại!");
                    return;
                }

                string sqlInsert = string.Format(
                    "INSERT INTO DOCGIA (MaDG, HoTen, NgaySinh, DiaChi, Email, NgayLapThe, NgayHetHan, LoaiDG, SoDT) " +
                    "VALUES ('{0}', N'{1}', '{2}', N'{3}', '{4}', '{5}', '{6}', N'{7}', '{8}')",
                    maDG, txtHoTen.Text.Trim(), dtpNgaySinh.Value.ToString("yyyy-MM-dd"),
                    txtDiaChi.Text.Trim(), txtEmail.Text.Trim(), dtpNgayLapThe.Value.ToString("yyyy-MM-dd"),
                    dtpNgayHetHan.Value.ToString("yyyy-MM-dd"), cboLoaiDG.Text, txtSoDT.Text.Trim()
                );

                if (db.update(sqlInsert) > 0) // Giả định db.update trả về số dòng bị tác động
                {
                    MessageBox.Show("Thêm mới độc giả thành công!");
                    LoadData();
                    LamMoi();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi thêm: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maDG = txtMaDG.Text.Trim();
                if (string.IsNullOrEmpty(maDG))
                {
                    MessageBox.Show("Vui lòng chọn một độc giả từ danh sách để sửa!");
                    return;
                }

                string sqlUpdate = string.Format(
                    "UPDATE DOCGIA SET HoTen=N'{1}', NgaySinh='{2}', DiaChi=N'{3}', Email='{4}', " +
                    "NgayLapThe='{5}', NgayHetHan='{6}', LoaiDG=N'{7}', SoDT='{8}' WHERE MaDG='{0}'",
                    maDG, txtHoTen.Text.Trim(), dtpNgaySinh.Value.ToString("yyyy-MM-dd"),
                    txtDiaChi.Text.Trim(), txtEmail.Text.Trim(), dtpNgayLapThe.Value.ToString("yyyy-MM-dd"),
                    dtpNgayHetHan.Value.ToString("yyyy-MM-dd"), cboLoaiDG.Text, txtSoDT.Text.Trim()
                );

                if (db.update(sqlUpdate) > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    LoadData();
                    LamMoi();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi sửa: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maDG = txtMaDG.Text.Trim();
            if (string.IsNullOrEmpty(maDG))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã độc giả cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa độc giả " + maDG + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sqlDelete = "DELETE FROM DOCGIA WHERE MaDG = '" + maDG + "'";
                try
                {
                    if (db.update(sqlDelete) > 0)
                    {
                        MessageBox.Show("Đã xóa độc giả thành công!");
                        LoadData();
                        LamMoi();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã độc giả để xóa!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (có thể độc giả này đang có dữ liệu liên quan ở bảng khác): " + ex.Message);
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy giá trị từ ComboBox Loại Độc Giả
                string loaiSelected = cboLoaiDG.Text.Trim();

                // 2. Kiểm tra nếu chưa chọn gì thì báo lỗi hoặc load lại tất cả
                if (string.IsNullOrEmpty(loaiSelected))
                {
                    MessageBox.Show("Vui lòng chọn Loại Độc Giả cần lọc!");
                    LoadData(); // Load lại toàn bộ nếu để trống
                    return;
                }

                // 3. Tạo câu lệnh SQL có điều kiện WHERE
                // Lưu ý: N'{0}' dùng để lọc tiếng Việt có dấu
                string sqlFilter = string.Format(
                    "SELECT MaDG, HoTen, NgaySinh, DiaChi, Email, NgayLapThe, NgayHetHan, LoaiDG, SoDT " +
                    "FROM DOCGIA WHERE LoaiDG = N'{0}'",
                    loaiSelected
                );

                // 4. Thực thi lấy dữ liệu
                DataTable dt = db.getTable(sqlFilter);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvDocGia.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu cho loại: " + loaiSelected);
                    dgvDocGia.DataSource = null; // Xóa bảng nếu không có kết quả
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }
    }
}
