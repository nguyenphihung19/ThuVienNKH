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
            // Thay 'SACH' bằng tên bảng trong SQL của ông
            string sql = "SELECT * FROM SACH";
            dgvSach.DataSource = db.getTable(sql);
        }
    }
}
