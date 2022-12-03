using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class AddressDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        public AddressDataMapper() { }
        public Address FindByID(int id)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT* FROM Address2 WHERE address_id = @id";
            command.Parameters.Add(new SqlParameter("@id", $"{id}"));
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                int address_id = (int)dr["address_id"];
                string street = (string)dr["street"];
                int zip_code = (int)dr["zip_code"];
                int city_id = (int)dr["city_id"];
                dr.Close();
                command.Dispose();
                City c = new CityDataMapper().FindByID(city_id);
                Address addr = new Address(address_id, street, zip_code, c);
                ConnectionManager.CloseConn();
                return addr;
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return null;
        }
    }
}
