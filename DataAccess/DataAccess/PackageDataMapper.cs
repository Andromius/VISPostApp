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
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT* FROM Package WHERE package_code = @code";
            command.Parameters.Add(new SqlParameter("@code", $"{code}"));
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                int package_code = (int)dr["package_code"];
                double weight = (double)dr["weight"];
                DateOnly date_imported = DateOnly.FromDateTime((DateTime)dr["date_imported"]);
                int address_id = (int)dr["address_id"];
                dr.Close();
                command.Dispose();
                Address addr = new AddressDataMapper().FindByID(address_id);
                Package pckg = new Package(package_code, weight, date_imported, addr);
                ConnectionManager.CloseConn();
                return pckg;
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return null;
        }
        //public List<Package> FindByArea(int areaID)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    conn.Open();
        //    using (SqlCommand command = new SqlCommand())
        //    {
        //        command.Connection = conn;
        //        command.CommandType = CommandType.Text;
        //        command.CommandText = "SELECT* FROM Package " +
        //                              "JOIN Address2 ON Package.address_id = Address2.address_id " +
        //                              "JOIN City2 ON Address2.city_id = City2.city_id" +
        //                              "WHERE City2.area_id = @areaID";
        //        command.Parameters.Add(new SqlParameter("@areaID", $"{areaID}"));
        //        using (SqlDataReader dr = command.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                Package pckg = new Package(
        //                    (int)dr["package_code"],
        //                    (double)dr["weight"],
        //                    DateOnly.FromDateTime((DateTime)dr["date_imported"]),
        //                    new AddressDataMapper().FindByID((int)dr["address_id"]));
                        
        //            }
        //            conn.Close();
        //            return pckg;
        //        }
        //    }
        //    conn.Close();
        //    return new List<Package>();
        //}

    }
}
