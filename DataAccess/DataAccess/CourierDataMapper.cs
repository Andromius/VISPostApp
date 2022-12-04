using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainObjects.Services;

namespace DataAccess.DataAccess
{
    public class CourierDataMapper : ICourierDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        public Courier FindByUserID(int id, string firstName, string lastName, DateOnly dateHired, string login, string password, bool atWork)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT* FROM Courier WHERE user_id = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = command.ExecuteReader();
            Courier c = null;
            while (dr.Read())
            {
                c = new Courier(id, firstName, lastName, dateHired, login, password, atWork, (int)dr["courier_id"], (int)dr["area_id"]);
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return c;
        }
    }
}
