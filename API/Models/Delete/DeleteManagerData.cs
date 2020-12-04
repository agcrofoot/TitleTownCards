using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Delete;

namespace API.Models.Delete
{
    public class DeleteManagerData : IDeleteManager
    {
        public void DeleteManager(int managerID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM Manager WHERE ManagerID = @ManagerID";
                cmd.Parameters.AddWithValue("@ManagerID", managerID);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}