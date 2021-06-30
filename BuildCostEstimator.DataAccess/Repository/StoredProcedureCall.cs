using System;
using System.Collections.Generic;
using System.Linq;
using BuildCostEstimator.DataAccess.Data;
using BuildCostEstimator.DataAccess.Repository.IRepository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BuildCostEstimator.DataAccess.Repository
{
    public class StoredProcedureCall : IStoredProcedureCall
    {
        private readonly ApplicationDbContext _db;

        private static string ConnectionString = "";

        public StoredProcedureCall(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        // Use if a stored procedure should retrieve one row
        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (var sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                var value = sqlCon.ExecuteScalar<T>(procedureName, param,
                    commandType: System.Data.CommandType.StoredProcedure);

                return (T) Convert.ChangeType(value, typeof(T));
            }
        }

        //Use if a stored procedure should update
        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (var sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        // Use if a stored procedure should retrieve one complete record
        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (var sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                var value = sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

                return (T) Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        // Use if a stored procedure should retrieve all of the categories
        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (var sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        // Use if a stored procedure should retrieve two tables
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName,
            DynamicParameters param = null)
        {
            using (var sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                var result =
                    SqlMapper.QueryMultiple(sqlCon, procedureName, param,
                        commandType: System.Data.CommandType.StoredProcedure);

                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();

                if (item1 != null && item2 != null) return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
            }

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }
    }
}