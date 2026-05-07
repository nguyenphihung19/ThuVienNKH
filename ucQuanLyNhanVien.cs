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
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            if (cboBoPhan.Items.Count > 0)
                cboBoPhan.SelectedIndex = 0;
        }

        bool IsMaNVExist(string maNV)
        {
            object result = db.getScalar($"SELECT COUNT(*) FROM NHANVIEN WHERE MaNV='{maNV}'");

            int count = 0;

            if (result != null)
                int.TryParse(result.ToString(), out count);

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
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ Mã NV và Họ tên!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2. Kiểm tra trùng mã
            if (IsMaNVExist(maNV))
            {
                MessageBox.Show(
                    "Mã nhân viên này đã tồn tại!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 3. Lấy giá trị từ các control
            string maBP = cboBoPhan.SelectedValue?.ToString() ?? "";
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string bangCap = cboBangCap.Text;
            string diaChi = txtDiaChi.Text.Trim();
            string soDT = txtSoDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            // 4. SQL thêm dữ liệu
            string sql = $@"INSERT INTO NHANVIEN 
                    (MaNV, HoTen, NgaySinh, DiaChi, SoDT, BangCap, MaBP, Email) 
                    VALUES 
                    ('{maNV}', N'{hoTen}', '{ngaySinh}', N'{diaChi}', 
                    '{soDT}', N'{bangCap}', '{maBP}', '{email}')";

            try
            {
                if (db.update(sql) > 0)
                {
                    MessageBox.Show(
                        "Thêm nhân viên thành công!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    LoadData();
                    ClearText();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể thêm dữ liệu. Kiểm tra lại kết nối hoặc ràng buộc bảng!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra: " + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên cần sửa từ bảng!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string maBP = cboBoPhan.SelectedValue?.ToString() ?? "";

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
                MessageBox.Show(
                    "Cập nhật thành công!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                ResetFields();
                LoadData();
            }
            else
            {
                MessageBox.Show(
                    "Cập nhật thất bại!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (maNV == "" || MessageBox.Show(
                "Bạn chắc chắn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) == DialogResult.No)
                return;

            if (db.update($"DELETE FROM NHANVIEN WHERE MaNV='{maNV}'") > 0)
            {
                LoadData();
                ClearText();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim();

            string sql = "SELECT MaNV, HoTen, NgaySinh, DiaChi, SoDT, BangCap, MaBP, Email " +
                         "FROM NHANVIEN " +
                         "WHERE MaNV LIKE '%" + key + "%' " +
                         "OR HoTen LIKE N'%" + key + "%'";

            dgvNhanVien.DataSource = db.getTable(sql);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (cboBoPhan.SelectedValue == null) return;

            string maBP = cboBoPhan.SelectedValue.ToString();

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

            if (cboBoPhan.Items.Count > 0)
                cboBoPhan.SelectedIndex = -1;

            if (cboBangCap.Items.Count > 0)
                cboBangCap.SelectedIndex = -1;

            dtpNgaySinh.Value = DateTime.Now;

            txtMaNV.Enabled = true;
        }

        private void cboBangCap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}