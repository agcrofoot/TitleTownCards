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
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            Random random = new Random();
            int randomNumber = random.Next(100, 1001);

            string stm = @"INSERT INTO Manager(ManagerID, ManagerName, ManagerPhone, ManagerEmail, ManagerAddress)
            VALUES(@ManagerID, @ManagerName, @ManagerPhone, @ManagerEmail, @ManagerAddress)";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@ManagerID", randomNumber);
            cmd.Parameters.AddWithValue("@ManagerName",value.managerName);
            cmd.Parameters.AddWithValue("@ManagerPhone",value.managerPhone);
            cmd.Parameters.AddWithValue("@ManagerEmail",value.managerEmail);
            cmd.Parameters.AddWithValue("@ManagerAddress",value.managerAddress);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}