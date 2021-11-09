using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace OmegaPointSimpleAPI.Data.DataAccess
{
    /**
     * Class with methods that allows us to access the database with the connectionstring and sql-queries to get the right data but also insert data.
     * 
     */
    public class SqlDataAccess
    {
        /**
         * Used as load function (delete and get functions).
         * @param sql queries for update of data stored inside the db.
         */
        public static List<T> LoadData<T>(string sql, string connectionString)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }


        /**
         * Used as save function (insert to database).
         * @param sql queries for update of data stored inside the db.
         * @param data, also called the model in this case.
         */
        public static int SaveData<T>(string sql, T data, string connectionString)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                return cnn.Execute(sql, data);
            }
        }

    }
}
