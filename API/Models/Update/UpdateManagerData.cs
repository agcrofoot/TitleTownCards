using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Update;

namespace API.Models.Update
{
    public class UpdateManagerData : IUpdateManagers
    {
        public void EditManager(Manager value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"UPDATE Manager SET ManagerName = @ManagerName, ManagerPhone = @ManagerPhone, ManagerEmail = @ManagerEmail, ManagerAddress = @ManagerAddress WHERE ManagerID = @ManagerID";
                cmd.Parameters.AddWithValue("@ManagerID", value.managerID);
                cmd.Parameters.AddWithValue("@ManagerName",value.managerName);
                cmd.Parameters.AddWithValue("@ManagerPhone",value.managerPhone);
                cmd.Parameters.AddWithValue("@ManagerEmail",value.managerEmail);
                cmd.Parameters.AddWithValue("@ManagerAddress",value.managerAddress);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}