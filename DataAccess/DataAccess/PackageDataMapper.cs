using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainObjects.DomainObjects;

namespace DataAccess.DataAccess
{
    public class PackageDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        private readonly string SQL_SELECT_BY_COURIER = "SELECT* FROM Package WHERE courier_id = @id";
        private readonly string SQL_SELECT_BY_PCKGCODE = "SELECT* FROM Package WHERE package_code = @code";
        public PackageDataMapper() { }
        public Package FindByCode(int code)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_SELECT_BY_PCKGCODE;
            command.Parameters.Add(new SqlParameter("@code", $"{code}"));
            SqlDataReader dr = command.ExecuteReader();
            Package pckg = null;
            while (dr.Read())
            {
                pckg = new Package((int)dr["package_code"], (double)dr["weight"],)
                int package_code = (int)dr["package_code"];
                double weight = (double)dr["weight"];
                DateOnly date_imported = DateOnly.FromDateTime((DateTime)dr["date_imported"]);
                int address_id = (int)dr["address_id"];
                dr.Close();
                command.Dispose();
                Address addr = new AddressDataMapper().FindByID(address_id);
                pckg = new Package(package_code, weight, date_imported, addr);
                ConnectionManager.CloseConn();
                return pckg;
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return null;
        }
        public List<Package> FindByCourierID(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = SQL_SELECT_BY_COURIER;
                command.Parameters.Add(new SqlParameter("@id", $"{id}"));
                List<Package> packages = new List<Package>();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Package pckg = new Package(
                            (int)dr["package_code"],
                            (double)dr["weight"],
                            DateOnly.FromDateTime((DateTime)dr["date_imported"]),
                            new AddressDataMapper().FindByID((int)dr["address_id"])
                        );
                        packages.Add(pckg);

                    }
                    conn.Close();
                    return packages;
                }
            }
            conn.Close();
            return new List<Package>();
        }

    }
}
