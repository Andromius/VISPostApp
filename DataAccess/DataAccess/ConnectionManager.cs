using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class ConnectionManager
    {
        public static bool IsConnected { get; private set; }
        public static SqlConnection SqlConnection { get; private set; }

        public static void OpenConn(string connectionString)
        {
            if (IsConnected) { Console.WriteLine($"OC IF: {IsConnected}"); return; }
            SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();
            IsConnected = true;
            Console.WriteLine($"OC: {IsConnected}");
        }

        public static void CloseConn() 
        {
            if (!IsConnected) { Console.WriteLine($"CC IF: {IsConnected}"); return; }
            SqlConnection.Close();
            SqlConnection.Dispose();
            IsConnected = false;
            Console.WriteLine($"CC: {IsConnected}");
        }
    }
}
