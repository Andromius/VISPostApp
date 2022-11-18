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
    public class CityDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        public CityDataMapper() { }
        public City FindByID(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT city_id, name FROM City2 WHERE city_id = @id";
                command.Parameters.Add(new SqlParameter("@id", $"{id}"));
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return new City((int)dr["city_id"], (string)dr["name"]);
                    }
                }
            }
            conn.Close();
            return null;
        }
    }
}
