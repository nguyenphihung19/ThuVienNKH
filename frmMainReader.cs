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
    public partial class frmMainReader : Form
    {
        string tenSV = "";
        public frmMainReader()
        {
            InitializeComponent();
        }
        // 2. Hàm này để nhận tên từ Form Login truyền sang
        public frmMainReader(string ten)
        {
            InitializeComponent(); // PHẢI CÓ DÒNG NÀY ĐẦU TIÊN
            this.tenSV = ten;

            // Ví dụ ông có cái label tên lblTenSV trên giao diện sinh viên
            // lblTenSV.Text = "Chào bạn: " + tenSV; 
        }

        private void BtnTraCuu_Click(object sender, EventArgs e)
        {
            // 1. Xóa bỏ những gì đang hiển thị ở vùng trống (ví dụ đặt tên là pnlContent)
            pnlContent.Controls.Clear();

            // 2. Tạo một bản sao của miếng ghép Tra cứu
            ucTraCuuSach uc = new ucTraCuuSach();

            // 3. Ra lệnh cho miếng ghép tự giãn nở vừa khít cái vùng trống
            uc.Dock = DockStyle.Fill;

            // 4. Dán nó vào
            pnlContent.Controls.Add(uc);
        }

        private void BtnCaNhan_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear(); // Xóa chức năng cũ
            ucTheoDoiCaNhan uc = new ucTheoDoiCaNhan(); // Tạo miếng ghép Theo dõi
            uc.Dock = DockStyle.Fill; // Co giãn vừa khít
            pnlContent.Controls.Add(uc); // Dán vào vùng trống
        }
    }
}
