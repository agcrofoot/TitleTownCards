using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data.SQLite;
using System;

namespace API.Models.Read
{
    public class ReadEmployeeData : IGetAllEmployees, IGetEmployee
    {
        public List<Employee> GetAllEmployees()
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Employee";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<Employee> allEmployees = new List<Employee>();
            while(rdr.Read())
            {
                allEmployees.Add(new Employee(){employeeID = rdr.GetInt32(0), employeeName = rdr.GetString(1), employeePhone = rdr.GetString(2), employeeEmail = rdr.GetString(3), employeeAddress = rdr.GetString(4)});
            }
            return allEmployees;
        }
        public Employee GetEmployee(int employeeID)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Employee(){employeeID = rdr.GetInt32(0), employeeName = rdr.GetString(1), employeePhone = rdr.GetString(2), employeeEmail = rdr.GetString(3), employeeAddress = rdr.GetString(4)};
        }
    }
}