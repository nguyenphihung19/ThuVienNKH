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
    public partial class ucThanhLySach : UserControl
    {
        DBConnect db = new DBConnect();
        public ucThanhLySach()
        {
            InitializeComponent();
            this.Load += ucThanhLySach_Load;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ucThanhLySach_Load(object sender, EventArgs e)
        {
            // Hiển thị mã NV từ Session (nếu là SV/Khách thì Session.MaNV rỗng)
            txtMaNV.Text = Session.MaNV;
            txtMaNV.Enabled = false;

            // Load dữ liệu
            LoadHistoryFromSQL();

            // Tạo mã phiếu mới tự động
            txtMaPhieu.Text = "PTL" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private void LoadHistoryFromSQL()
        {
            try
            {
                // Sử dụng JOIN đúng với cấu trúc bảng thông thường
                string sql = @"SELECT ct.MaPhieuTL, t.NgayTL, t.MaNV, ct.MaSach, ct.LyDoTL 
                               FROM CHITIETTHANHLY ct 
                               LEFT JOIN THANHLY t ON ct.MaPhieuTL = t.MaPhieuTL";

                DataTable dt = db.getTable(sql);
                dgvThanhLy.DataSource = dt;

                if (dgvThanhLy.Columns.Count > 0)
                {
                    dgvThanhLy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvThanhLy.Columns["MaPhieuTL"].HeaderText = "Mã Phiếu";
                    dgvThanhLy.Columns["NgayTL"].HeaderText = "Ngày TL";
                    dgvThanhLy.Columns["MaNV"].HeaderText = "Mã NV";
                    dgvThanhLy.Columns["MaSach"].HeaderText = "Mã Sách";
                    dgvThanhLy.Columns["LyDoTL"].HeaderText = "Lý Do";
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi do tên bảng, hãy kiểm tra lại tên trong SQL Server
                MessageBox.Show("Lỗi load dữ liệu (kiểm tra tên bảng trong SQL): " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền (chỉ nhân viên mới được thêm)
            if (string.IsNullOrEmpty(Session.MaNV))
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");
                return;
            }

            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Sách!");
                return;
            }

            try
            {
                db.open();
                string maP = txtMaPhieu.Text;
                string maS = txtMaSach.Text;
                string lyDo = cboLyDo.Text;
                string ngay = DateTime.Now.ToString("yyyy-MM-dd");

                // Thực thi các câu lệnh SQL
                db.update($"INSERT INTO THANHLY (MaPhieuTL, NgayTL, MaNV) VALUES ('{maP}','{ngay}','{Session.MaNV}')");
                db.update($"INSERT INTO CHITIETTHANHLY (MaPhieuTL, MaSach, LyDoTL) VALUES ('{maP}','{maS}',N'{lyDo}')");
                db.update($"UPDATE SACH SET TinhTrang = N'Đã thanh lý' WHERE MaSach='{maS}'");

                MessageBox.Show("Thêm thành công!");

                // --- ĐOẠN CODE RESET DỮ LIỆU ---
                txtMaSach.Clear();             // Xóa trắng ô Mã Sách
                cboLyDo.SelectedIndex = -1;    // Bỏ chọn trong ComboBox (hoặc đặt = 0 nếu muốn về mặc định)

                // Sinh mã phiếu mới tự động để chuẩn bị cho lần thêm tiếp theo
                txtMaPhieu.Text = "PTL" + DateTime.Now.ToString("yyyyMMddHHmmss");
                // -------------------------------

                LoadHistoryFromSQL(); // Tải lại lưới để hiển thị dữ liệu mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                db.close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSachCanXoa = txtMaSach.Text.Trim();

            if (string.IsNullOrEmpty(maSachCanXoa))
            {
                MessageBox.Show("Vui lòng nhập Mã Sách cần xóa!");
                txtMaSach.Focus();
                return;
            }

            try
            {
                db.open();

                // 1. Kiểm tra tồn tại
                string checkQuery = $"SELECT COUNT(*) FROM CHITIETTHANHLY WHERE MaSach = '{maSachCanXoa}'";
                int exists = Convert.ToInt32(db.getScalar(checkQuery));

                if (exists > 0)
                {
                    DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa sách {maSachCanXoa} khỏi danh sách thanh lý?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        // 2. Xóa dữ liệu và cập nhật trạng thái sách
                        db.update($"DELETE FROM CHITIETTHANHLY WHERE MaSach = '{maSachCanXoa}'");
                        db.update($"UPDATE SACH SET TinhTrang = N'Bình thường' WHERE MaSach = '{maSachCanXoa}'");

                        MessageBox.Show("Đã xóa sách thành công!");

                        // 3. Nạp lại lưới để thấy sự thay đổi
                        LoadHistoryFromSQL();

                        // 4. GỌI HÀM CLEAR ĐỂ LÀM TRẮNG FORM
                        ClearInput();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách này trong danh sách thanh lý!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                db.close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            try
            {
                // Câu lệnh SQL lọc kết hợp JOIN
                string sql = @"SELECT ct.MaPhieuTL, t.NgayTL, t.MaNV, ct.MaSach, ct.LyDoTL 
                       FROM CHITIETTHANHLY ct 
                       JOIN THANHLY t ON ct.MaPhieuTL = t.MaPhieuTL 
                       WHERE ct.MaSach LIKE '%" + tuKhoa + "%' OR ct.MaPhieuTL LIKE '%" + tuKhoa + "%'";

                DataTable dt = db.getTable(sql);
                dgvThanhLy.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
        private void dgvThanhLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThanhLy.Rows[e.RowIndex];

                // Đây là đoạn code khiến dữ liệu bị đẩy lên
                txtMaPhieu.Text = row.Cells["MaPhieuTL"].Value.ToString();
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();

                // Chỗ này khiến ComboBox nhảy theo giá trị của dòng được chọn
                cboLyDo.Text = row.Cells["LyDoTL"].Value.ToString();
            }
        }
        private void ClearInput()
        {
            // Reset lại mã phiếu cho lần thêm mới
            txtMaPhieu.Text = "PTL" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Xóa trắng mã sách
            txtMaSach.Clear();

            // Đặt chỉ số về -1 để ComboBox không hiển thị nội dung gì
            cboLyDo.SelectedIndex = -1;

            // Đưa con trỏ chuột về lại ô mã sách để nhập tiếp
            txtMaSach.Focus();
        }
    }
}
