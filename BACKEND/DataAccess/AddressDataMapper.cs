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
    public class AddressDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        public AddressDataMapper() { }
        public Address FindByID(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT* FROM Address2 WHERE address_id = @id";
                command.Parameters.Add(new SqlParameter("@id", $"{id}"));
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return new Address
                        (
                            (int)dr["address_id"], 
                            (string)dr["street"], 
                            (int)dr["zip_code"], 
                            new CityDataMapper().FindByID((int)dr["city_id"])
                        );
                    }
                }
            }
            conn.Close();
            return null;
        }
    }
}
