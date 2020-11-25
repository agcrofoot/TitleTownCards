using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddManagerData : IAddManager
    {
        public void AddManager(Manager value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                Random random = new Random();
                int randomNumber = random.Next(100, 1001);

                cmd.CommandText = @"INSERT INTO Manager(ManagerID, ManagerName, ManagerPhone, ManagerEmail, ManagerAddress)
                VALUES(@ManagerID, @ManagerName, @ManagerPhone, @ManagerEmail, @ManagerAddress)";
                cmd.Parameters.AddWithValue("@ManagerID", randomNumber);
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