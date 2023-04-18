using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;    // Add Nuget Packages
using System.Linq;
using System.Text;

namespace LinQ
{
    class DBUtils
    {
        public static SqlConnection SqlServerConnection()
        {
            string connectionString = @"Data Source=AVDESKPC\NAVSQL;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=sa123456";
            return new SqlConnection(connectionString);
            
        }
    }
}
