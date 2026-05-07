using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class ucQuanLySach : UserControl
    {
        DBConnect db = new DBConnect();

        public ucQuanLySach()
        {
            InitializeComponent();
            loadData(); // Gọi hàm này khi UC bắt đầu chạy
        }

        void loadData()
        {
            try
            {
                string sql = @"SELECT S.MaSach, D.TenDauSach, L.TenLoaiSach, S.TriGia, S.TinhTrang 
                        FROM SACH S 
                        JOIN DAUSACH D ON S.MaDauSach = D.MaDauSach 
                        JOIN LOAISACH L ON D.MaLoaiSach = L.MaLoaiSach";

                DataTable dt = db.getTable(sql);
                dgvSach.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load dữ liệu: " + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSach.Rows.Count - 1)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];

                txtMaSach.Text = row.Cells[0].Value?.ToString();
                textBox1.Text = row.Cells[4].Value?.ToString();
                textBox2.Text = row.Cells[2].Value?.ToString();

                // 1. Số sách (Trị giá) - Cột số 3 trên bảng
                textBox4.Text = row.Cells[3].Value?.ToString();

                // 2. Tình Trạng - Cột số 4 trên bảng
                CboTinhTrangSach.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Xóa sạch nội dung các ô
            txtMaSach.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();

            // Đưa ComboBox về trạng thái chưa chọn hoặc mặc định
            CboTinhTrangSach.SelectedIndex = -1;
            CboTinhTrangSach.Text = "";

            // Load lại bảng
            loadData();

            // Focus
            txtMaSach.Focus();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (CboTinhTrangSach.Text == "Đã thanh lý")
            {
                MessageBox.Show(
                    "Vui lòng thực hiện thanh lý tại màn hình Thanh Lý Sách!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                SqlConnection conn = db.conn;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "UPDATE SACH SET TinhTrang = @tinhTrang, TriGia = @gia WHERE MaSach = @ma";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@tinhTrang", CboTinhTrangSach.Text);
                cmd.Parameters.AddWithValue("@gia", textBox4.Text);
                cmd.Parameters.AddWithValue("@ma", txtMaSach.Text);

                int kq = cmd.ExecuteNonQuery();

                if (kq > 0)
                {
                    MessageBox.Show(
                        "Sửa thành công!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    loadData();
                }
                else
                {
                    MessageBox.Show(
                        "Không tìm thấy mã sách để sửa!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn cuốn sách cần xóa trên bảng!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Hỏi lại trước khi xóa
            DialogResult dr = MessageBox.Show(
                "Ông có chắc muốn xóa sách có mã " + txtMaSach.Text + " không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = db.conn;

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string sql = "DELETE FROM SACH WHERE MaSach = @ma";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaSach.Text.Trim());

                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show(
                            "Đã xóa xong!",
                            "Cảnh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        loadData();
                        BtnReset_Click(sender, e);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi khi xóa: " + ex.Message,
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Mã sách!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                SqlConnection conn = db.conn;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // 1. Tạo mã mới
                string ms = txtMaSach.Text.Trim();
                string md = "D_" + ms;
                string ml = "L_" + ms;

                // 2. Thêm LOAISACH
                string sqlLoai = "INSERT INTO LOAISACH (MaLoaiSach, TenLoaiSach) VALUES (@maL, @tenL)";

                SqlCommand cmdL = new SqlCommand(sqlLoai, conn);

                cmdL.Parameters.AddWithValue("@maL", ml);
                cmdL.Parameters.AddWithValue("@tenL", textBox1.Text.Trim());

                cmdL.ExecuteNonQuery();

                // 3. Thêm DAUSACH
                string sqlDau = "INSERT INTO DAUSACH (MaDauSach, TenDauSach, MaLoaiSach) VALUES (@maD, @tenD, @maL)";

                SqlCommand cmdD = new SqlCommand(sqlDau, conn);

                cmdD.Parameters.AddWithValue("@maD", md);
                cmdD.Parameters.AddWithValue("@tenD", textBox2.Text.Trim());
                cmdD.Parameters.AddWithValue("@maL", ml);

                cmdD.ExecuteNonQuery();

                // 4. Thêm SACH
                string sqlSach = "INSERT INTO SACH (MaSach, MaDauSach, TinhTrang, TriGia) VALUES (@maS, @maD, @tinhTrang, @gia)";

                SqlCommand cmdS = new SqlCommand(sqlSach, conn);

                cmdS.Parameters.AddWithValue("@maS", ms);
                cmdS.Parameters.AddWithValue("@maD", md);
                cmdS.Parameters.AddWithValue("@tinhTrang", CboTinhTrangSach.Text);
                cmdS.Parameters.AddWithValue("@gia", textBox4.Text.Trim());

                int kq = cmdS.ExecuteNonQuery();

                if (kq > 0)
                {
                    MessageBox.Show(
                        "Thêm thành công!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    loadData();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Tự load lại dữ liệu khi mở UserControl
        private void ucQuanLySach_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                loadData();
            }
        }

        private void ucQuanLySach_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}