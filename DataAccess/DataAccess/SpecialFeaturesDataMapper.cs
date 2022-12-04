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
    public class SpecialFeaturesDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        private readonly string SQL_SELECT_BY_PCKGCODE = "SELECT special_feature_id FROM PackageXSpecialFeatures WHERE package_code = @code";
        public List<SpecialFeature> FindByPackageCode(int code)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_SELECT_BY_PCKGCODE;
            command.Parameters.Add(new SqlParameter("@code", $"{code}"));
            List<SpecialFeature> specialFeatures = new List<SpecialFeature>();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                specialFeatures.Add((SpecialFeature)dr["special_feature_id"]);
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return specialFeatures;
        }
    }
}
