using System;
using System.Data;
using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class ucTraCuuSach : UserControl
    {
        DBConnect db = new DBConnect();

        public ucTraCuuSach()
        {
            InitializeComponent();
        }

        private void ucTraCuuSach_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            try
            {
                string sql = @"
                SELECT 
                ds.MaDauSach, ds.TenDauSach, ds.TacGia, ds.NhaXB, ds.MaLoaiSach, ds.NamXB, 
                s.TinhTrang, ls.TenLoaiSach
                FROM DAUSACH ds
                LEFT JOIN SACH s ON ds.MaDauSach = s.MaDauSach
                LEFT JOIN LOAISACH ls ON ds.MaLoaiSach = ls.MaLoaiSach
                GROUP BY ds.MaDauSach, ds.TenDauSach, ds.TacGia, ds.NhaXB, ds.MaLoaiSach, ds.NamXB, s.TinhTrang, ls.TenLoaiSach 
                ORDER BY ds.MaDauSach";

                DataTable dt = db.getTable(sql);
                gridviewTraCuu.DataSource = dt;
                HideColums();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sách: " + ex.Message);
            }
        }

        private void HideColums()
        {
            if (gridviewTraCuu.Columns.Contains("MaLoaiSach"))
                gridviewTraCuu.Columns["MaLoaiSach"].Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string textname = txtSearch.Text.Trim();
                string category = cboTheLoaiSach.SelectedItem?.ToString();
                string maSach = cboMaDauSach.SelectedItem?.ToString();
                string namXB = cboNamXB.SelectedItem?.ToString();
                string tinhTrang = cboTinhTrang.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(maSach) && string.IsNullOrEmpty(category))
                {
                    MessageBox.Show("Vui lòng chọn thể loại sách trước khi chọn mã sách!",
                                    "Thiếu thông tin",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    cboTheLoaiSach.Focus();
                    return;
                }

                string sql = @"
                SELECT 
                ds.MaDauSach, ds.TenDauSach, ds.TacGia, ds.NhaXB, 
                ds.NamXB, ls.TenLoaiSach, s.TinhTrang
                FROM DAUSACH ds
                LEFT JOIN LOAISACH ls ON ds.MaLoaiSach = ls.MaLoaiSach
                LEFT JOIN SACH s ON ds.MaDauSach = s.MaDauSach
                WHERE 1=1";

                if (!string.IsNullOrEmpty(textname))
                    sql += $" AND (ds.TenDauSach LIKE N'%{textname}%' OR ds.TacGia LIKE N'%{textname}%' OR ds.NhaXB LIKE N'%{textname}%')";

                if (!string.IsNullOrEmpty(category))
                    sql += $" AND ls.TenLoaiSach = N'{category}'";

                if (!string.IsNullOrEmpty(maSach))
                    sql += $" AND ds.MaDauSach = N'{maSach}'";

                if (!string.IsNullOrEmpty(namXB))
                    sql += $" AND ds.NamXB = {namXB}";

                if (!string.IsNullOrEmpty(tinhTrang))
                    sql += $" AND s.TinhTrang = N'{tinhTrang}'";

                sql += " GROUP BY ds.MaDauSach, ds.TenDauSach, ds.TacGia, ds.NhaXB, ds.NamXB, ls.TenLoaiSach, s.TinhTrang";
                sql += " ORDER BY ds.MaDauSach";

                DataTable dt = db.getTable(sql);
                gridviewTraCuu.DataSource = dt;
                HideColums();

                // Nếu không tìm thấy kết quả
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sách nào phù hợp với điều kiện tìm kiếm!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc sách: " + ex.Message);
            }
        }

        private void cboTheLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cboTheLoaiSach.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                string sql = $@"
                SELECT DISTINCT ds.MaDauSach 
                FROM DAUSACH ds
                LEFT JOIN LOAISACH ls ON ds.MaLoaiSach = ls.MaLoaiSach
                WHERE ls.TenLoaiSach = N'{selectedCategory}'
                ORDER BY ds.MaDauSach";

                DataTable dt = db.getTable(sql);
                cboMaDauSach.DataSource = dt;
                cboMaDauSach.DisplayMember = "MaDauSach";
                cboMaDauSach.ValueMember = "MaDauSach";
                cboMaDauSach.SelectedIndex = -1;
            }
            else
            {
                cboMaDauSach.DataSource = null;
                cboMaDauSach.Items.Clear();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboTheLoaiSach.SelectedIndex = -1;
            cboMaDauSach.DataSource = null;
            cboMaDauSach.Items.Clear();
            cboNamXB.SelectedIndex = -1;
            cboTinhTrang.SelectedIndex = -1;
            LoadAllData();
        }
    }
}