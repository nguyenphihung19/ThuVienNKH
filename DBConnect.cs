using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    internal class DBConnect
    {
        // Tên Server và Database chuẩn theo ảnh ông gửi
        // Tui bỏ đoạn 'TrustServerCertificate' vì dùng Integrated Security trên máy cá nhân thường không cần nó
        private string strCon = @"Data Source=.\MSSQLSERVER01;Initial Catalog=QuanLyThuVienMoi;Integrated Security=True;Encrypt=False";

        public SqlConnection conn { get; set; }

        public DBConnect()
        {
            conn = new SqlConnection(strCon);
        }

        // Hàm mở kết nối an toàn có bọc Try-Catch
        public void open()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể mở kết nối tới SQL Server: " + ex.Message);
            }
        }

        // Hàm đóng kết nối
        public void close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        // Hàm lấy dữ liệu (SELECT)
        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                ad.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
            return dt;
        }

        // Hàm thực thi lệnh (INSERT, UPDATE, DELETE)
        public int update(string sql)
        {
            int n = -1;
            try
            {
                open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                n = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
            finally
            {
                close();
            }
            return n;
        }
    }
}
