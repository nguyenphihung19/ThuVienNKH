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
    public partial class ucCaiDatQuyDinh : UserControl
    {
        DBConnect db = new DBConnect();

        public ucCaiDatQuyDinh()
        {
            InitializeComponent();
            // Tui thêm hàm này để tự động nới giới hạn NumericUpDown lên cao, tránh lỗi 100
            SetMaxLimits();
            LoadData();
        }

        // Hàm này giúp ông không bao giờ bị lỗi "Value of 1000 is not valid" nữa
        private void SetMaxLimits()
        {
            foreach (Control ctrl in this.Controls)
            {
                // Tìm tất cả NumericUpDown trong các GroupBox hoặc Panel
                SearchAndSetMax(ctrl);
            }
        }

        private void SearchAndSetMax(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is NumericUpDown nm)
                {
                    nm.Maximum = 1000000; // Cho phép nhập đến 1 triệu
                }
                if (c.HasChildren) SearchAndSetMax(c);
            }
        }

        public void LoadData()
        {
            try
            {
                string query = "SELECT MaQD, TenQD, GiaTri FROM QUYDINH";
                DataTable dt = db.getTable(query);

                if (dt.Rows.Count == 0) return;

                // Xóa nội dung cũ trong RichTextBox
                RtbQuyDinh.Clear();
                RtbQuyDinh.AppendText("DANH SÁCH QUY ĐỊNH HIỆN TẠI:\n");
                RtbQuyDinh.AppendText("---------------------------\n");

                foreach (DataRow row in dt.Rows)
                {
                    string maQD = row["MaQD"].ToString();
                    string tenQD = row["TenQD"].ToString();
                    int giaTri = Convert.ToInt32(row["GiaTri"]);

                    // 1. Hiển thị lên RichTextBox cho đẹp
                    RtbQuyDinh.AppendText($"- {tenQD}: {giaTri}\n");

                    // 2. Gán giá trị vào các ô số trên giao diện
                    switch (maQD)
                    {
                        case "QD01": numSoNamCuaSach.Value = giaTri; break;
                        case "QD02": numTuoiToiThieu.Value = giaTri; break;
                        case "QD03": numTuoiToiDa.Value = giaTri; break;
                        case "QD04": numThoiHanThe.Value = giaTri; break;
                        case "QD05": numSoSachToiDa.Value = giaTri; break;
                        case "QD06": numNgayMuonToiDa.Value = giaTri; break;
                        case "QD07": numTienPhatQuaHan.Value = giaTri; break;
                        case "QD08": numTienPhatMatSach.Value = giaTri; break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Cập nhật ĐẦY ĐỦ tất cả các ô quy định xuống SQL
                UpdateQD("QD01", (int)numSoNamCuaSach.Value);
                UpdateQD("QD02", (int)numTuoiToiThieu.Value);
                UpdateQD("QD03", (int)numTuoiToiDa.Value);
                UpdateQD("QD04", (int)numThoiHanThe.Value);
                UpdateQD("QD05", (int)numSoSachToiDa.Value);
                UpdateQD("QD06", (int)numNgayMuonToiDa.Value);
                UpdateQD("QD07", (int)numTienPhatQuaHan.Value);
                UpdateQD("QD08", (int)numTienPhatMatSach.Value);

                MessageBox.Show("Cập nhật tất cả quy định thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lại để cái RichTextBox cập nhật số mới luôn
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void UpdateQD(string ma, int giaTri)
        {
            string sql = $"UPDATE QUYDINH SET GiaTri = {giaTri} WHERE MaQD = '{ma}'";
            db.update(sql);
        }

        // Nếu ông muốn làm nút Khôi phục mặc định thì xài đoạn này
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đưa các quy định về mặc định không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                numSoNamCuaSach.Value = 8;
                numTuoiToiThieu.Value = 18;
                numTuoiToiDa.Value = 40;
                numThoiHanThe.Value = 6;
                numSoSachToiDa.Value = 5;
                numNgayMuonToiDa.Value = 4;
                numTienPhatQuaHan.Value = 1000;
                numTienPhatMatSach.Value = 100;

                // Sau khi gán số mặc định thì tự bấm Lưu luôn cho tiện
                btnLuuThayDoi_Click(sender, e);
            }
        }

        private void BtbReset_Click(object sender, EventArgs e)
        {
            // 1. Hỏi xác nhận cho chắc ăn trước khi khôi phục
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn khôi phục tất cả quy định về giá trị mặc định ban đầu không?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 2. Gán các con số mặc định (ông có thể sửa lại số theo ý mình)
                    numSoNamCuaSach.Value = 8;
                    numTuoiToiThieu.Value = 18;
                    numTuoiToiDa.Value = 40;
                    numThoiHanThe.Value = 6;
                    numSoSachToiDa.Value = 5;
                    numNgayMuonToiDa.Value = 4;
                    numTienPhatQuaHan.Value = 1000;
                    numTienPhatMatSach.Value = 100;

                    // 3. Gọi hàm cập nhật xuống SQL cho từng cái
                    UpdateQD("QD01", (int)numSoNamCuaSach.Value);
                    UpdateQD("QD02", (int)numTuoiToiThieu.Value);
                    UpdateQD("QD03", (int)numTuoiToiDa.Value);
                    UpdateQD("QD04", (int)numThoiHanThe.Value);
                    UpdateQD("QD05", (int)numSoSachToiDa.Value);
                    UpdateQD("QD06", (int)numNgayMuonToiDa.Value);
                    UpdateQD("QD07", (int)numTienPhatQuaHan.Value);
                    UpdateQD("QD08", (int)numTienPhatMatSach.Value);

                    // 4. Load lại dữ liệu để cập nhật cái bảng chữ (RichTextBox) phía dưới
                    LoadData();

                    MessageBox.Show("Đã khôi phục quy định mặc định thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi khôi phục: " + ex.Message);
                }
            }
        }
    }
}