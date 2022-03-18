using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private static string connectionString = @"Data Source=MIKOŁAJ\SQLEXPRESS;Initial Catalog=GymAppDataBase;User ID=AppUser;Password=user";

        public async Task<List<T>> GetDataAsync<T, U>(string cmd, U parameter)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                var output = await cnn.QueryAsync<T>(cmd, parameter);

                return output.ToList();
            }
        }

        public async Task<List<T>> GetDataAsync<T>(string cmd)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                var output = await cnn.QueryAsync<T>(cmd);

                return output.ToList();
            }
        }

        public async Task GiveDataAsync<T>(string cmd, T parameter)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                await cnn.ExecuteAsync(cmd, parameter);
                
            }
        }
    }
}
