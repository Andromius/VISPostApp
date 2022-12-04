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
    public class SpecialFeaturesDataMapper : ISpecialFeaturesDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        private readonly string SQL_SELECT_BY_PCKGCODE = "SELECT pfs.special_feature_id, name FROM PackageXSpecialFeatures pfs JOIN Special_features sf ON pfs.special_feature_id = sf.special_feature_id WHERE package_code = @code";
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
                specialFeatures.Add(new SpecialFeature((int)dr["special_feature_id"], (string)dr["name"]));
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return specialFeatures;
        }
    }
}
