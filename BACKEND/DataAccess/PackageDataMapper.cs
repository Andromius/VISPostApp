using BACKEND.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.DataAccess
{
    public class PackageDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        
        public PackageDataMapper() { }
        public Package FindByCode(int code) 
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT* FROM Package WHERE package_code = @code";
                command.Parameters.Add(new SqlParameter("@code", $"{code}"));
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return new Package((int)dr["package_code"], (double)dr["weight"], DateOnly.FromDateTime((DateTime)dr["date_imported"]), new Address((int)dr["address_id"]));
                    }
                }
            }
            return null;
        }

    }
}
