using System;
using System.Data.SQLite;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddManagerData : IAddManager
    {
        public void AddManager(Manager value)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            Random random = new Random();
            int randomNumber = random.Next(100, 1001);

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO Manager(ManagerID, ManagerName, ManagerPhone, ManagerEmail, ManagerAddress)
                VALUES(@ManagerID, @ManagerName, @ManagerPhone, @ManagerEmail, @ManagerAddress)";
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