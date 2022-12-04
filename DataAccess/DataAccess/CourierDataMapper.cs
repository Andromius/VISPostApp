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
        public Courier FindByUserID(Courier c)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT* FROM Courier WHERE user_id = @id";
            command.Parameters.AddWithValue("@id", c.UserID);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c.CourierID = (int)dr["courier_id"];
                c.AreaID = (int)dr["area_id"];
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return c;
        }
        public Courier FindByCourierID(int id)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT* FROM Courier WHERE courier_id = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = command.ExecuteReader();
            Courier c = null;
            int userID = 0;
            while (dr.Read())
            {
                userID = (int)dr["user_id"];
            }
            dr.Close();
            if (userID > 0)
                c = (Courier)new UserDataMapper().FindByID(userID);
            command.Dispose();
            ConnectionManager.CloseConn();
            return c;
        }
    }
}
