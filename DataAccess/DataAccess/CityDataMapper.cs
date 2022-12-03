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
            command.CommandText = "SELECT* FROM City2 WHERE city_id = @id";
            command.Parameters.Add(new SqlParameter("@id", $"{id}"));
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                City c = new City((int)dr["city_id"], (string)dr["name"], (int)dr["area_id"]);
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

        public City FindByName(string name)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT* FROM City2 WHERE name = @name";
            command.Parameters.Add(new SqlParameter("@name", $"{name}"));
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                City c = new City((int)dr["city_id"], (string)dr["name"], (int)dr["area_id"]);
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
        public List<City> FindByAreaID(int areaId)
        {
            List<City> cities = new List<City>();
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT* FROM City2 WHERE area_id = @id";
            command.Parameters.Add(new SqlParameter("@id", $"{areaId}"));
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                cities.Add(new City((int)dr["city_id"], (string)dr["name"], (int)dr["area_id"]));
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return cities is not null ? cities : null;
        }

        public bool Update(City city)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE City2 SET name = @name, area_id = @areaID WHERE city_id = @id";
            command.Parameters.Add(new SqlParameter("@id", $"{city.CityID}"));
            command.Parameters.Add(new SqlParameter("@name", $"{city.Name}"));
            command.Parameters.Add(new SqlParameter("@areaID", $"{city.AreaID}"));
            int rAff = command.ExecuteNonQuery();
            command.Dispose();
            ConnectionManager.CloseConn();
            return rAff == 1;
        }

        public bool Create(City city)
        {
            ConnectionManager.OpenConn(connectionString);
            int rAff = -1;
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO City2 (name) VALUES (@name)";
            command.Parameters.Add(new SqlParameter("@name", $"{city.Name}"));
            if (city.AreaID is not null)
            {
                command.CommandText = "INSERT INTO City2 (name, area_id) VALUES (@name, @areaID)";
                command.Parameters.Add(new SqlParameter("@areaID", $"{city.AreaID}"));
            }
            try
            {
                rAff = command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                command.Dispose();
                ConnectionManager.CloseConn();
                return rAff == 1;
            }
            command.Dispose();
            ConnectionManager.CloseConn();
            return rAff == 1;
        }

    }
}
