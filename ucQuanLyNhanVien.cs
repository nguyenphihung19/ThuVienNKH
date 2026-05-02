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
    public partial class ucQuanLyNhanVien : UserControl
    {
        DBConnect db = new DBConnect();
        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            this.Load += ucQuanLyNhanVien_Load;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void ucQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.ReadOnly = false;
            LoadBoPhan();
            LoadData();
        }
        void LoadData()
        {
            // Ghi rõ từng cột, KHÔNG dùng SELECT *
            string sql = "SELECT MaNV, HoTen, NgaySinh, DiaChi, SoDT, BangCap, MaBP, Email FROM NHANVIEN";
            dgvNhanVien.DataSource = db.getTable(sql);
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Làm bảng full màn hình
        }
        void LoadBoPhan()
        {
            cboBoPhan.DataSource = db.getTable("SELECT * FROM BOPHAN");
            cboBoPhan.DisplayMember = "TenBP";
            cboBoPhan.ValueMember = "MaBP";
        }
        void ClearText()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoDT.Clear();
            txtEmail.Clear();
            txtTimKiem.Clear();

            cboBangCap.SelectedIndex = -1;
            // Đã xóa txtTenDangNhap, txtMatKhau, cboQuyen

            if (cboBoPhan.Items.Count > 0)
                cboBoPhan.SelectedIndex = 0;
        }
        bool IsMaNVExist(string maNV)
        {
            object result = db.getScalar($"SELECT COUNT(*) FROM NHANVIEN WHERE MaNV='{maNV}'");
            int count = 0;
            if (result != null) int.TryParse(result.ToString(), out count);
            return count > 0;
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvNhanVien.Rows[e.RowIndex];

            txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            txtSoDT.Text = row.Cells["SoDT"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            cboBangCap.Text = row.Cells["BangCap"].Value?.ToString();
            cboBoPhan.SelectedValue = row.Cells["MaBP"].Value?.ToString();

            if (row.Cells["NgaySinh"].Value != DBNull.Value)
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã NV và Họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra trùng mã
            if (IsMaNVExist(maNV))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Lấy giá trị từ các control
            string maBP = cboBoPhan.SelectedValue?.ToString() ?? "";
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string bangCap = cboBangCap.Text;
            string diaChi = txtDiaChi.Text.Trim();
            string soDT = txtSoDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            // 4. Xây dựng câu lệnh SQL (CHỈ CÁC CỘT CÓ TRONG BẢNG)
            // Lưu ý: Đảm bảo bảng NHANVIEN của bạn không bắt buộc nhập các cột Tài Khoản
            string sql = $@"INSERT INTO NHANVIEN (MaNV, HoTen, NgaySinh, DiaChi, SoDT, BangCap, MaBP, Email) 
                    VALUES ('{maNV}', N'{hoTen}', '{ngaySinh}', N'{diaChi}', '{soDT}', N'{bangCap}', '{maBP}', '{email}')";

            // 5. Debug: Hiện câu lệnh để kiểm tra nếu lỗi
            // MessageBox.Show(sql); 

            // 6. Thực thi
            try
            {
                if (db.update(sql) > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại giao diện
                    LoadData();
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Không thể thêm dữ liệu. Kiểm tra lại kết nối hoặc ràng buộc bảng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maBP = cboBoPhan.SelectedValue?.ToString() ?? "";

            // Dùng lệnh UPDATE với dữ liệu đang hiển thị trên TextBox
            // Lưu ý: Đảm bảo khi bạn chọn dòng trong Grid, dữ liệu đã hiện đầy đủ lên các TextBox
            string sql = $@"UPDATE NHANVIEN SET 
                    HoTen = N'{txtHoTen.Text.Replace("'", "''")}', 
                    NgaySinh = '{dtpNgaySinh.Value:yyyy-MM-dd}', 
                    DiaChi = N'{txtDiaChi.Text.Replace("'", "''")}', 
                    SoDT = '{txtSoDT.Text.Replace("'", "''")}', 
                    BangCap = N'{cboBangCap.Text.Replace("'", "''")}', 
                    MaBP = '{maBP}', 
                    Email = '{txtEmail.Text.Replace("'", "''")}' 
                    WHERE MaNV = '{maNV}'";

            if (db.update(sql) > 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFields();
                LoadData(); // Load lại để thấy thay đổi
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string maNV = txtMaNV.Text.Trim();
            if (maNV == "" || MessageBox.Show("Bạn chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (db.update($"DELETE FROM NHANVIEN WHERE MaNV='{maNV}'") > 0)
            {
                LoadData();
                ClearText();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();
            string sql = "SELECT MaNV, HoTen, NgaySinh, DiaChi, SoDT, BangCap, MaBP, Email FROM NHANVIEN WHERE MaNV LIKE '%" + key + "%' OR HoTen LIKE N'%" + key + "%'";
            dgvNhanVien.DataSource = db.getTable(sql);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra để tránh lỗi khi ComboBox chưa có dữ liệu
            if (cboBoPhan.SelectedValue == null) return;

            string maBP = cboBoPhan.SelectedValue.ToString();

            // Thay vì dùng *, hãy liệt kê đúng các cột bạn cần hiển thị
            string sql;
            if (maBP == "ALL")
            {
                sql = "SELECT MaNV, HoTen, NgaySinh, DiaChi, SoDT, BangCap, MaBP, Email FROM NHANVIEN";
            }
            else
            {
                sql = $@"SELECT MaNV, HoTen, NgaySinh, DiaChi, SoDT, BangCap, MaBP, Email 
                 FROM NHANVIEN 
                 WHERE MaBP = '{maBP}'";
            }

            dgvNhanVien.DataSource = db.getTable(sql);
        }
        private void ResetFields()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoDT.Clear();
            txtEmail.Clear();
           

            // Đưa ComboBox về giá trị mặc định (thường là chọn phần tử đầu tiên hoặc trống)
            if (cboBoPhan.Items.Count > 0) cboBoPhan.SelectedIndex = -1;
            if (cboBangCap.Items.Count > 0) cboBangCap.SelectedIndex = -1;

            // Đưa DateTimePicker về ngày hiện tại
            dtpNgaySinh.Value = DateTime.Now;

            // Nếu bạn muốn cho phép nhập lại mã NV sau khi sửa xong:
            txtMaNV.Enabled = true;
        }

        private void cboBangCap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
