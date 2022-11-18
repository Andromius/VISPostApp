using BACKEND.DataAccess;
using BACKEND.DomainObjects;
using System.Data;
using System.Data.SqlClient;

namespace BACKEND
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> results = new List<string>();
            //SqlConnection conn = new SqlConnection(@"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135");
            //conn.Open();
            //using (SqlCommand command = new SqlCommand())
            //{
            //    command.Connection = conn;
            //    command.CommandType = CommandType.Text;
            //    command.CommandText = "Select * from test";
            //    using (SqlDataReader dr = command.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            results.Add(dr["colOfInts"].ToString());
            //            results.Add(dr["colOfStrings"].ToString());
            //        }
            //    }
            //}
            //Console.WriteLine();
            Package test = new PackageDataMapper().FindByCode(12345678);
            if(test is not null)
            {
                Console.WriteLine(test.ToString());
            }
            Console.WriteLine("je null vole");
        }
    }
}