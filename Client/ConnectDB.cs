using MySql.Data.MySqlClient;

namespace TitleTownCards_1.Client
{
    public class ConnectDB
    {
        //testing - putting this in CreateDatabase.cs
        
        // public void ConnectToDB()
        // {
        //     MySql.Data.MySqlClient.MySqlConnection conn;
        //     string myConnectionString;

        //     myConnectionString = "server=127.0.0.1;uid=root;" +
        //     "pwd=;database=ttowncards";

        //     try
        //     {
        //     conn = new MySql.Data.MySqlClient.MySqlConnection();
        //     conn.ConnectionString = myConnectionString;
        //     conn.Open();
        //     }
        //     catch (MySql.Data.MySqlClient.MySqlException ex)
        //     {
        //     MessageBox.Show(ex.Message);
        //     }
        //}

        public void Connect(){
            
            string cs = @"server=localhost;userid=root;password=;database=ttowncards";

            using var con = new MySqlConnection(cs);
            con.Open();

            //command:
            // string sql = "SELECT * FROM manager";
            // using var cmd = new MySqlCommand(sql, con);

            // using MySqlDataReader rdr = cmd.ExecuteReader();

            // //testing
            // // while (rdr.Read())
            // // {
            // //     Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1), 
            // //             rdr.GetString(2));
            // // }
        }
    }
}