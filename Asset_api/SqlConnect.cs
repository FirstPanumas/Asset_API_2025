using Npgsql;

namespace Asset_api
{
    public class SqlConnect
    {
        public NpgsqlConnection GetConnection()
        {
            string host = "localhost";
            string user = "postgres";
            string password = "admin";
            string db = "db_asset";
            string port = "5432";


            try
            {

                string strConn = String.Format("Host={0};Username={1};Password={2};Database={3}", host, user, password, db);
                using NpgsqlConnection conn = new NpgsqlConnection(strConn);
                conn.Open();

                return conn;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + String.Format("Host={0};Username={1};Password={2};Database={3}", host, user, password, db));
            }

        }
    }
}
