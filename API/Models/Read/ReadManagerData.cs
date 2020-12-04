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
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Manager";
                MySqlCommand cmd = new MySqlCommand(stm,conn);

                List<Manager> allManagers = new List<Manager>();
                using(var rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        allManagers.Add(new Manager(){managerID = rdr.GetInt32(0), managerName = rdr.GetString(1), managerPhone = rdr.GetString(2), managerEmail = rdr.GetString(3), managerAddress = rdr.GetString(4)});
                    
                    }
                    db.CloseConnection();
                    return allManagers;
                }
            }
            else
            {
                return new List<Manager>();
            }
        }
        public Manager GetManager(int managerID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Manager WHERE ManagerID = @ManagerID";
                MySqlCommand cmd = new MySqlCommand(stm,conn);
                cmd.Parameters.AddWithValue("@ManagerID", managerID);
                cmd.Prepare();
                using var rdr = cmd.ExecuteReader();
                rdr.Read();
                Manager manager= new Manager(){managerID = rdr.GetInt32(0), managerName = rdr.GetString(1), managerPhone = rdr.GetString(2), managerEmail = rdr.GetString(3), managerAddress = rdr.GetString(4)};
                db.CloseConnection();
                return manager;
            }
            else
            {
                return new Manager();
            }
        }
    }
}