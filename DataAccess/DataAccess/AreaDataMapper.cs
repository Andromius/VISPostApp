using DomainObjects.DomainObjects;
using DomainObjects.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class AreaDataMapper : IAreaDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        private readonly string SQL_SELECT_BY_ID = "SELECT* FROM Area WHERE area_id = @id";
        public Area FindByID(int id)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_SELECT_BY_ID;
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = command.ExecuteReader();
            Area a = null;
            while (dr.Read())
            {
                a = new Area((int)dr["area_id"], (string)dr["area_name"]);
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return a;
        }
    }
}
