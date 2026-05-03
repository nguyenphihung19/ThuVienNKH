using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_TH_Quản_Lý_Thư_Viện
{
    internal class DBConnect
    {
        private string strCon = @"Data Source=DESKTOP-QREEVLD;Initial Catalog=QuanLyThuVienMoi;Integrated Security=True;Encrypt=False";

        //public SqlConnection conn { get; set; }

        //public DBConnect()
        //{
        //    conn = new SqlConnection(strCon);
        //}

        private SqlConnection _conn;
        public SqlConnection conn
        {
            get
            {
                if (_conn == null)
                    _conn = new SqlConnection(strCon);
                else if (string.IsNullOrEmpty(_conn.ConnectionString))
                    _conn.ConnectionString = strCon;

                return _conn;
            }
            set
            {
                _conn = value;
            }
        }

        public DBConnect()
        {
            _conn = new SqlConnection(strCon);
        }

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

        public void close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        // Hàm lấy giá trị đơn (SELECT COUNT(*), MAX(...), MIN(...), ...)
        public object getScalar(string sql, params SqlParameter[] parameters)
        {
            object result = null;
            try
            {
                open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    result = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực thi getScalar: " + ex.Message);
            }
            finally
            {
                close();
            }
            return result;
        }

        // Hàm lấy dữ liệu (SELECT)
        public DataTable getTable(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
            finally
            {
                close();
            }
            return dt;
        }

        // Hàm thực thi lệnh (INSERT, UPDATE, DELETE)
        public int update(string sql, params SqlParameter[] parameters)
        {
            int n = -1;
            try
            {
                open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    n = cmd.ExecuteNonQuery();
                }
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

        public SqlConnection getConnection()
        {
            return conn;
        }
    }
}