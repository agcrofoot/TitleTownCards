using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data.SQLite;
using System;

namespace API.Models.Read
{
    public class ReadManagerData : IGetAllManagers, IGetManager
    {
        public List<Manager> GetAllManagers()
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Manager";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<Manager> allManagers = new List<Manager>();
            while(rdr.Read())
            {
                allManagers.Add(new Manager(){managerID = rdr.GetInt32(0), managerName = rdr.GetString(1), managerPhone = rdr.GetString(2), managerEmail = rdr.GetString(3), managerAddress = rdr.GetString(4)});
            }
            return allManagers;
        }
        public Manager GetManager(int managerID)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Manager WHERE ManagerID = @ManagerID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@ManagerID", managerID);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Manager(){managerID = rdr.GetInt32(0), managerName = rdr.GetString(1), managerPhone = rdr.GetString(2), managerEmail = rdr.GetString(3), managerAddress = rdr.GetString(4)};
        }
    }
}