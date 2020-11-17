using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace API.Models.Read
{
    public class ReadManagerData : IGetAllManagers, IGetManager
    {
        public List<Manager> GetAllManagers()
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Manager";
            MySqlCommand cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Manager> allManagers = new List<Manager>();
            while(rdr.Read())
            {
                allManagers.Add(new Manager(){managerID = rdr.GetInt32(0), managerName = rdr.GetString(1), managerPhone = rdr.GetString(2), managerEmail = rdr.GetString(3), managerAddress = rdr.GetString(4)});
            }
            return allManagers;
        }
        public Manager GetManager(int managerID)
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Manager WHERE ManagerID = @ManagerID";
            MySqlCommand cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@ManagerID", managerID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Manager(){managerID = rdr.GetInt32(0), managerName = rdr.GetString(1), managerPhone = rdr.GetString(2), managerEmail = rdr.GetString(3), managerAddress = rdr.GetString(4)};
        }
    }
}