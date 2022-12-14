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
    public class UserDataMapper : IUserDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        private readonly string SQL_SELECT_BY_LOGIN = "SELECT* FROM \"User\" WHERE login = @login";
        private readonly string SQL_SELECT_COURIER_BY_UID = "SELECT* FROM \"User\" WHERE user_id = @id";
        public User FindByLogin(string login)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_SELECT_BY_LOGIN;
            command.Parameters.AddWithValue("@login", login);
            SqlDataReader dr = command.ExecuteReader();
            User u = null;
            while (dr.Read())
            {
                switch ((string)dr["role"])
                {
                    case "M":
                        u = new Management((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                    case "W":
                        u = new Warehouseman((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                    case "C":
                        u = new Courier((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                }
            }
            dr.Close();
            if (u is Courier c)
            {
                u = new CourierDataMapper().FindByUserID(c);
            }
            command.Dispose();
            ConnectionManager.CloseConn();
            return u;
        }

        public User FindByID(int id)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_SELECT_COURIER_BY_UID;
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = command.ExecuteReader();
            User u = null;
            while (dr.Read())
            {
                switch ((string)dr["role"])
                {
                    case "M":
                        u = new Management((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                    case "W":
                        u = new Warehouseman((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                    case "C":
                        u = new Courier((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                }
            }
            dr.Close();
            if (u is Courier)
            {
                u = new CourierDataMapper().FindByUserID((Courier)u);
            }
            command.Dispose();
            ConnectionManager.CloseConn();
            return u;
        }
        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
        public bool Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}
