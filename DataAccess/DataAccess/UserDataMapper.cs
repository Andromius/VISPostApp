using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class UserDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        private readonly string SQL_SELECT_BY_LOGIN = "SELECT* FROM \"User\" WHERE login = @login";
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
                switch ((char)dr["role"])
                {
                    case 'M':
                        u = new Management((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                    case 'W':
                        u = new Warehouseman((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                    case 'C':
                        u = new CourierDataMapper().FindByUserID((int)dr["user_id"], (string)dr["first_name"], (string)dr["last_name"],
                            DateOnly.FromDateTime((DateTime)dr["date_hired"]), (string)dr["login"], (string)dr["password"], (bool)dr["at_work"]);
                        break;
                }
                dr.Close();
                command.Dispose();
                ConnectionManager.CloseConn();
                return u;
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return null;
        }
        public bool Update(User user)
        {

        }
        public bool Create(User user)
        {

        }
    }
}
