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
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT city_id, name FROM City2 WHERE city_id = @id";
            command.Parameters.Add(new SqlParameter("@id", $"{id}"));
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                City c = new City((int)dr["city_id"], (string)dr["name"]);
                dr.Close();
                command.Dispose();
                ConnectionManager.CloseConn();
                return c;
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return null;
        }
        public List<City> FindByArea(int areaId) 
        {
            List<City> cities = new List<City>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT city_id, name FROM City2 WHERE area_id = @id";
                command.Parameters.Add(new SqlParameter("@id", $"{areaId}"));
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cities.Add(new City((int)dr["city_id"], (string)dr["name"]));
                    }

                }
            }
            conn.Close();
            return cities is not null ? cities : null;
        }
    }
}
