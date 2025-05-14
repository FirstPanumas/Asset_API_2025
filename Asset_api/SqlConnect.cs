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

                string strConn = String.Format("Host={1};Username={2};Password{3};Database={4};Post={5}", host, user, password, db, port);
                using NpgsqlConnection conn = new NpgsqlConnection(strConn);
                conn.Open();

                return conn;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
