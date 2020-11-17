using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace API.Models.Read
{
    public class ReadEmployeeData : IGetAllEmployees, IGetEmployee
    {
        public List<Employee> GetAllEmployees()
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Employee";
            MySqlCommand cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Employee> allEmployees = new List<Employee>();
            while(rdr.Read())
            {
                allEmployees.Add(new Employee(){employeeID = rdr.GetInt32(0), employeeName = rdr.GetString(1), employeePhone = rdr.GetString(2), employeeEmail = rdr.GetString(3), employeeAddress = rdr.GetString(4)});
            }
            return allEmployees;
        }
        public Employee GetEmployee(int employeeID)
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";
            MySqlCommand cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Employee(){employeeID = rdr.GetInt32(0), employeeName = rdr.GetString(1), employeePhone = rdr.GetString(2), employeeEmail = rdr.GetString(3), employeeAddress = rdr.GetString(4)};
        }
    }
}