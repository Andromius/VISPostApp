using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainObjects.DomainObjects;
using DomainObjects.Services;

namespace DataAccess.DataAccess
{
    public class PackageDataMapper : IPackageDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        private readonly string SQL_SELECT_BY_COURIER = "SELECT* FROM Package WHERE courier_id = @id";
        private readonly string SQL_SELECT_BY_PCKGCODE = "SELECT* FROM Package WHERE package_code = @code";
        public PackageDataMapper() { }
        public Package FindByCode(int code)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_SELECT_BY_PCKGCODE;
            command.Parameters.Add(new SqlParameter("@code", $"{code}"));
            SqlDataReader dr = command.ExecuteReader();
            Package pckg = null;
            while (dr.Read())
            {
                DateOnly? dateDispacthed;
                if (dr.IsDBNull(3))
                    dateDispacthed = null;
                else
                    dateDispacthed = DateOnly.FromDateTime((DateTime)dr["date_dispatched"]);
                EDispatchStatus? dispatchStatus;
                    switch ((string)dr["dispatch_status"])
                    {
                        case "delivered":
                            dispatchStatus = EDispatchStatus.Delivered; break;
                        case "ndelivered":
                            dispatchStatus = EDispatchStatus.NDelivered; break;
                        case "dispatched":
                            dispatchStatus = EDispatchStatus.Dispatched; break;
                        case "returned":
                            dispatchStatus = EDispatchStatus.Returned; break;
                        default:
                            dispatchStatus = null; break;
                    }
                int? courierID;
                if (dr.IsDBNull(6))
                    courierID = null;
                else
                    courierID = (int)dr["courier_id"];
                pckg = new Package((int)dr["package_code"], Convert.ToDouble((decimal)dr["weight"]), DateOnly.FromDateTime((DateTime)dr["date_imported"]), dateDispacthed, dispatchStatus, (int)dr["address_id"], courierID);
            }
            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return pckg;
        }
        public List<Package> FindByCourierID(int id)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_SELECT_BY_COURIER;
            command.Parameters.Add(new SqlParameter("@id", $"{id}"));
            List<Package> packages = new List<Package>();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Package pckg = new Package(
                    (int)dr["package_code"],
                    (double)dr["weight"],
                    DateOnly.FromDateTime((DateTime)dr["date_imported"]),
                    new AddressDataMapper().FindByID((int)dr["address_id"])
                );
                packages.Add(pckg);
            }

            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return new List<Package>();
        }

    }
}
