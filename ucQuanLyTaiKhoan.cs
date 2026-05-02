using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    public partial class ucQuanLyTaiKhoan : UserControl
    {
        DBConnect db = new DBConnect();
        private string filename = "";
        public ucQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void ucQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            try
            {
                string sql = @"SELECT MaTaiKhoan, TenDangNhap, Email, MatKhau, QuyenTruyCap FROM TAIKHOAN";

                DataTable dt = db.getTable(sql);
                DgvTaiKhoan.DataSource = dt;

                if (DgvTaiKhoan.Columns.Contains("TrangThai"))
                {
                    DgvTaiKhoan.Columns["TrangThai"].Visible = false;
                }
                SetupColums();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void ClearInputFields()
        {
            txtTenDangNhap.Text = "";
            txtEmail.Text = "";
            txtMatKhau.Text = "";
            cboQuyenTruyCap.SelectedIndex = -1;
            txtTenDangNhap.Focus();
        }

        private void SetupColums()
        {
            if (DgvTaiKhoan.Columns.Contains("MaTaiKhoan"))
                DgvTaiKhoan.Columns["MaTaiKhoan"].DataPropertyName = "MaTaiKhoan";

            if (DgvTaiKhoan.Columns.Contains("TenDangNhap"))
                DgvTaiKhoan.Columns["TenDangNhap"].DataPropertyName = "TenDangNhap";

            if (DgvTaiKhoan.Columns.Contains("Email"))
                DgvTaiKhoan.Columns["Email"].DataPropertyName = "Email";

            if (DgvTaiKhoan.Columns.Contains("MatKhau"))
                DgvTaiKhoan.Columns["MatKhau"].DataPropertyName = "MatKhau";

            if (DgvTaiKhoan.Columns.Contains("QuyenTruyCap"))
                DgvTaiKhoan.Columns["QuyenTruyCap"].DataPropertyName = "QuyenTruyCap";
        }

        private void DgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DgvTaiKhoan.Rows[e.RowIndex];

                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();

                string quyen = row.Cells["QuyenTruyCap"].Value?.ToString();
                if (!string.IsNullOrEmpty(quyen))
                {
                    cboQuyenTruyCap.SelectedItem = quyen;
                }
            }
        }

        private void DgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvTaiKhoan.Columns[e.ColumnIndex].Name == "MatKhau" && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void DgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvTaiKhoan.SelectedRows.Count > 0)
            {
                txtTenDangNhap.Text = DgvTaiKhoan.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
                txtEmail.Text = DgvTaiKhoan.SelectedRows[0].Cells["Email"].Value.ToString();
                cboQuyenTruyCap.SelectedItem = DgvTaiKhoan.SelectedRows[0].Cells["QuyenTruyCap"].Value.ToString();

                // Lấy mật khẩu từ DataSource gốc
                DataRowView row = DgvTaiKhoan.SelectedRows[0].DataBoundItem as DataRowView;
                if (row != null)
                {
                    txtMatKhau.Text = row["MatKhau"].ToString();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDN = txtTenDangNhap.Text.Trim();
                string email = txtEmail.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();

                if (cboQuyenTruyCap.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn quyền truy cập!");
                    return;
                }

                string quyenTruyCap = cboQuyenTruyCap.SelectedItem.ToString();

                if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ!");
                    return;
                }

                if (IsTenDangNhapExists(tenDN))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại! Vui lòng chọn tên khác.");
                    return;
                }

                tenDN = tenDN.Replace("'", "''");
                email = email.Replace("'", "''");
                matKhau = matKhau.Replace("'", "''");
                quyenTruyCap = quyenTruyCap.Replace("'", "''");

                string sql = $@"INSERT INTO TAIKHOAN (TenDangNhap, Email, MatKhau, QuyenTruyCap) 
                                VALUES (N'{tenDN}', N'{email}', N'{matKhau}', N'{quyenTruyCap}')";

                //var parameters = new Dictionary<string, object>
                //{
                //    { "@tenDN", tenDN },
                //    { "@email", email },
                //    { "@matKhau", matKhau },
                //    { "@quyenTruyCap", quyenTruyCap }
                //};

                int result = db.update(sql);

                if (result > 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công!");
                    ClearInputFields();
                    LoadAllData();
                }
                else
                {
                    MessageBox.Show("Không thể thêm tài khoản! Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsTenDangNhapExists(string tenDN)
        {
            try
            {
                string sql = $"SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = N'{tenDN.Replace("'", "''")}'";
                DataTable dt = db.getTable(sql);
                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0][0]);
                    return count > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DgvTaiKhoan.SelectedRows.Count > 0)
            {
                // Kiểm tra nếu MaTaiKhoan là null hoặc không tồn tại trong DataGridView
                if (DgvTaiKhoan.SelectedRows[0].Cells["MaTaiKhoan"].Value == null)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!");
                    return;
                }

                string maTK = DgvTaiKhoan.SelectedRows[0].Cells["MaTaiKhoan"].Value.ToString();
                string tenDN = txtTenDangNhap.Text.Trim();
                string email = txtEmail.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();

                // Kiem tra co chon quyen truy cap hay khong
                if (cboQuyenTruyCap.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn quyền truy cập!");
                    return;
                }

                string quyenTruyCap = cboQuyenTruyCap.SelectedItem.ToString();


                // Kiem tra thong tin co day du hay khong
                if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ!");
                    return;
                }

                if (IsTenDangNhapExistsForUpdate(tenDN, maTK))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại! Vui lòng chọn tên khác.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tenDN = tenDN.Replace("'", "''");
                email = email.Replace("'", "''");
                matKhau = matKhau.Replace("'", "''");
                quyenTruyCap = quyenTruyCap.Replace("'", "''");
                try
                {
                    string sql = $@"UPDATE TAIKHOAN 
                                    SET TenDangNhap = N'{tenDN}', Email = N'{email}', MatKhau = N'{matKhau}', QuyenTruyCap = N'{quyenTruyCap}' 
                                    WHERE MaTaiKhoan = {maTK}";
                    int result = db.update(sql);
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công!"); 
                        ClearInputFields();
                        LoadAllData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật tài khoản! Vui lòng thử lại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa!");
            }
        }

        private bool IsTenDangNhapExistsForUpdate(string tenDN, string maTK)
        {
            try
            {
                string sql = $"SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = N'{tenDN.Replace("'", "''")}' AND MaTaiKhoan != {maTK}";
                DataTable dt = db.getTable(sql);
                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0][0]);
                    return count > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DgvTaiKhoan.SelectedRows.Count > 0)
            {
                // Kiểm tra nếu MaTaiKhoan là null hoặc không tồn tại trong DataGridView
                if (DgvTaiKhoan.SelectedRows[0].Cells["MaTaiKhoan"].Value == null)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!");
                    return;
                }

                string maTK = DgvTaiKhoan.SelectedRows[0].Cells["MaTaiKhoan"].Value.ToString();
                string tenDN = DgvTaiKhoan.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();

                // Không cho phép xóa tài khoản Admin
                if (tenDN.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Không thể xóa tài khoản Admin!");
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string sql = $"DELETE FROM TAIKHOAN WHERE MaTaiKhoan = {maTK}";
                        int result = db.update(sql);
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa tài khoản thành công!");
                            ClearInputFields();
                            LoadAllData();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa tài khoản! Vui lòng thử lại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DgvTaiKhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx|CSV Files|*.csv|All Files|*.*";
                sfd.Title = "Lưu danh sách tài khoản";
                sfd.DefaultExt = "xlsx";
                sfd.FileName = "DanhSachTaiKhoan_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    filename = sfd.FileName;

                    // Lưu theo định dạng file
                    if (filename.EndsWith(".csv"))
                    {
                        SaveToCSV(filename);
                    }
                    //else if (filename.EndsWith(".xlsx"))
                    //{
                    //    SaveToExcel(filename);
                    //}
                    else
                    {
                        SaveToText(filename);
                    }
                }
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            filename = ""; // Reset filename để hiện SaveFileDialog
            btnSave_Click(sender, e);
        }

        // Hàm lưu dữ liệu vào file
        private void SaveToCSV(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    // Ghi header (tên cột)
                    for (int i = 0; i < DgvTaiKhoan.Columns.Count; i++)
                    {
                        sw.Write(DgvTaiKhoan.Columns[i].HeaderText);
                        if (i < DgvTaiKhoan.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();

                    // Ghi dữ liệu
                    for (int i = 0; i < DgvTaiKhoan.Rows.Count; i++)
                    {
                        for (int j = 0; j < DgvTaiKhoan.Columns.Count; j++)
                        {
                            string cellValue = DgvTaiKhoan.Rows[i].Cells[j].Value?.ToString() ?? "";

                            // Xử lý dấu phẩy trong cell (đặt trong dấu ngoặc kép)
                            if (cellValue.Contains(",") || cellValue.Contains("\""))
                            {
                                cellValue = "\"" + cellValue.Replace("\"", "\"\"") + "\"";
                            }

                            sw.Write(cellValue);
                            if (j < DgvTaiKhoan.Columns.Count - 1)
                                sw.Write(",");
                        }
                        sw.WriteLine();
                    }
                }

                MessageBox.Show($"Lưu file thành công!\nĐường dẫn: {fileName}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file CSV: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void SaveToExcel(string fileName)
        //{
        //    try
        //    {
        //        // Tạo DataTable từ DataGridView
        //        DataTable dt = new DataTable();

        //        // Thêm các cột
        //        foreach (DataGridViewColumn col in DgvTaiKhoan.Columns)
        //        {
        //            dt.Columns.Add(col.HeaderText, typeof(string));
        //        }

        //        // Thêm dữ liệu
        //        foreach (DataGridViewRow row in DgvTaiKhoan.Rows)
        //        {
        //            DataRow dr = dt.NewRow();
        //            foreach (DataGridViewColumn col in DgvTaiKhoan.Columns)
        //            {
        //                dr[col.HeaderText] = row.Cells[col.Index].Value?.ToString() ?? "";
        //            }
        //            dt.Rows.Add(dr);
        //        }

        //        // Xuất ra Excel (cần cài NuGet: Install-Package EPPlus)
        //        using (var package = new OfficeOpenXml.ExcelPackage())
        //        {
        //            var worksheet = package.Workbook.Worksheets.Add("DanhSachTaiKhoan");
        //            worksheet.Cells["A1"].LoadFromDataTable(dt, true);

        //            // Format bảng
        //            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

        //            // Lưu file
        //            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
        //            package.SaveAs(fileInfo);
        //        }

        //        MessageBox.Show($"Lưu file Excel thành công!\nĐường dẫn: {fileName}", "Thông báo",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi lưu file Excel: " + ex.Message +
        //            "\n\nHãy thử lưu dưới dạng CSV.", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void SaveToText(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
                {
                    // Ghi header
                    string header = "";
                    for (int i = 0; i < DgvTaiKhoan.Columns.Count; i++)
                    {
                        header += DgvTaiKhoan.Columns[i].HeaderText;
                        if (i < DgvTaiKhoan.Columns.Count - 1)
                            header += "\t"; // Tab分隔
                    }
                    sw.WriteLine(header);

                    // Ghi dữ liệu
                    for (int i = 0; i < DgvTaiKhoan.Rows.Count; i++)
                    {
                        string line = "";
                        for (int j = 0; j < DgvTaiKhoan.Columns.Count; j++)
                        {
                            line += DgvTaiKhoan.Rows[i].Cells[j].Value?.ToString() ?? "";
                            if (j < DgvTaiKhoan.Columns.Count - 1)
                                line += "\t";
                        }
                        sw.WriteLine(line);
                    }
                }

                MessageBox.Show($"Lưu file thành công!\nĐường dẫn: {fileName}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file Text: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadAllData();
        }
    }
}
  