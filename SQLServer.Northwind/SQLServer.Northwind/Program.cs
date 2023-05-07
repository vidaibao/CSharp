using Microsoft.Data.SqlClient;

namespace SQLServer.Northwind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "Data Source=NT Service\\MSSQL$NAVSQL;Initial Catalog=Northwind;User ID=sa;Password=sa123456;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Kết nối thành công!");
                    // Đoạn mã xử lý cơ sở dữ liệu ở đây
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kết nối thất bại: " + ex.Message);
            }
        }
    }
}