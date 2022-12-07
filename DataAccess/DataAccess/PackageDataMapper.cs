using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainObjects.DomainObjects;
using DomainObjects.Services;
using DataAccess.IdentityMaps;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess.DataAccess
{
    public class PackageDataMapper : IPackageDataMapper
    {
        private readonly string connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=SCH0388;User ID=SCH0388;Password=wNsuzm209RYFy135";
        private readonly string SQL_SELECT_BY_COURIER = "SELECT* FROM Package WHERE courier_id = @id";
        private readonly string SQL_SELECT_BY_PCKGCODE = "SELECT* FROM Package WHERE package_code = @code";
        private readonly string SQL_SELECT_NO_COURIER = "SELECT* FROM Package WHERE courier_id IS NULL";
        private readonly string SQL_UPDATE_PACKAGE = "UPDATE Package SET courier_id = @id WHERE package_code = @code";
        public PackageDataMapper() { }
        public Package FindByCode(int code)
        {
            try
            {
                return PackageIdentityMap.Get(code);
            }
            catch (KeyNotFoundException)
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
                    PackageIdentityMap.Insert(pckg);
                }
                dr.Close();
                command.Dispose();
                ConnectionManager.CloseConn();
                return pckg;
            }
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
                packages.Add(pckg);
            }

            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return packages;
        }

        public List<Package> FindNoCourier()
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_SELECT_NO_COURIER;
            List<Package> packages = new List<Package>();
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
                packages.Add(pckg);
            }

            dr.Close();
            command.Dispose();
            ConnectionManager.CloseConn();
            return packages;
        }

        public void Update(Package p)
        {
            ConnectionManager.OpenConn(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = ConnectionManager.SqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL_UPDATE_PACKAGE;
            command.Parameters.Add(new SqlParameter("@code", $"{p.PackageCode}"));
            command.Parameters.Add(new SqlParameter("@id", $"{p.CourierID.Value}"));
            int rAff = command.ExecuteNonQuery();
            if(rAff == 1)
            {
                PackageIdentityMap.Clear();
            }
            command.Dispose();
            ConnectionManager.CloseConn();
        }
    }
}
