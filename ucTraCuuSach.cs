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
            // Kiểm tra xem cột có tồn tại trước khi ẩn để tránh lỗi
            if (gridviewTraCuu.Columns.Contains("MaLoaiSach"))
                gridviewTraCuu.Columns["MaLoaiSach"].Visible = false;

            // Ẩn cột Tác giả
            if (gridviewTraCuu.Columns.Contains("TacGia"))
                gridviewTraCuu.Columns["TacGia"].Visible = false;

            // Ẩn cột Nhà xuất bản
            if (gridviewTraCuu.Columns.Contains("NhaXB"))
                gridviewTraCuu.Columns["NhaXB"].Visible = false;

            // Ẩn cột Năm xuất bản
            if (gridviewTraCuu.Columns.Contains("NamXB"))
                gridviewTraCuu.Columns["NamXB"].Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                string category = cboTheLoaiSach.SelectedItem?.ToString();
                
                //string tinhTrang = cboTinhTrang.SelectedItem?.ToString();

                // Validate: Nếu chọn mã sách thì bắt buộc phải chọn thể loại
                //if (!string.IsNullOrEmpty(maSach) && string.IsNullOrEmpty(category))
                //{
                //    MessageBox.Show("Vui lòng chọn thể loại sách trước khi chọn mã sách!",
                //                    "Thiếu thông tin",
                //                    MessageBoxButtons.OK,
                //                    MessageBoxIcon.Warning);
                //    cboTheLoaiSach.Focus();
                //    return;
                //}

                // Câu SQL cơ bản
                string sql = @"
                            SELECT 
                                ds.MaDauSach,
                                ds.TenDauSach,
                                ds.TacGia,
                                ds.NhaXB,
                                ds.NamXB,
                                ls.TenLoaiSach,
                                s.TinhTrang
                            FROM DAUSACH ds
                            LEFT JOIN LOAISACH ls ON ds.MaLoaiSach = ls.MaLoaiSach
                            LEFT JOIN SACH s ON ds.MaDauSach = s.MaDauSach
                            WHERE 1 = 1";

                // 1. Lọc theo Tên sách / Tác giả / Nhà XB (tìm kiếm chung)
                if (!string.IsNullOrEmpty(searchText))
                {
                    sql += $@" AND (
                        ds.TenDauSach LIKE N'%{searchText}%' 
                        OR ds.TacGia LIKE N'%{searchText}%' 
                        OR ds.NhaXB LIKE N'%{searchText}%'
                    )";
                }

                // 2. Lọc theo Thể loại sách
                if (!string.IsNullOrEmpty(category))
                {
                    sql += $" AND ls.TenLoaiSach = N'{category}'";
                }

                // 3. Lọc theo Mã sách (chỉ áp dụng nếu đã chọn thể loại)
                //if (!string.IsNullOrEmpty(maSach))
                //{
                //    sql += $" AND ds.MaDauSach = N'{maSach}'";
                //}

                // 4. Lọc theo Năm xuất bản
                

                // 5. Lọc theo Tình trạng sách
                /*if (!string.IsNullOrEmpty(tinhTrang))
                {
                    sql += $" AND s.TinhTrang = N'{tinhTrang}'";
                }*/

                sql += @"
                        GROUP BY 
                            ds.MaDauSach, 
                            ds.TenDauSach, 
                            ds.TacGia, 
                            ds.NhaXB, 
                            ds.NamXB, 
                            ls.TenLoaiSach, 
                            s.TinhTrang
                        ORDER BY ds.MaDauSach";

                DataTable dt = db.getTable(sql);
                gridviewTraCuu.DataSource = dt;
                HideColums();

                // Hiển thị kết quả
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
                MessageBox.Show("Lỗi khi tìm kiếm sách: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void cboTheLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedCategory = cboTheLoaiSach.SelectedItem?.ToString();

            //if (!string.IsNullOrEmpty(selectedCategory))
            //{
            //    string sql = $@"
            //    SELECT DISTINCT ds.MaDauSach 
            //    FROM DAUSACH ds
            //    LEFT JOIN LOAISACH ls ON ds.MaLoaiSach = ls.MaLoaiSach
            //    WHERE ls.TenLoaiSach = N'{selectedCategory}'
            //    ORDER BY ds.MaDauSach";

            //    DataTable dt = db.getTable(sql);
            //    cboMaDauSach.DataSource = dt;
            //    cboMaDauSach.DisplayMember = "MaDauSach";
            //    cboMaDauSach.ValueMember = "MaDauSach";
            //    cboMaDauSach.SelectedIndex = -1;
            //}
            //else
            //{
            //    cboMaDauSach.DataSource = null;
            //    cboMaDauSach.Items.Clear();
            //}
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboTheLoaiSach.SelectedIndex = -1;
            
            //cboTinhTrang.SelectedIndex = -1;
            LoadAllData();
        }
    }
}