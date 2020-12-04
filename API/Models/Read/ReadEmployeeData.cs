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
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Employee";
                MySqlCommand cmd = new MySqlCommand(stm,conn);

                List<Employee> allEmployees = new List<Employee>();
                using(var rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        allEmployees.Add(new Employee(){employeeID = rdr.GetInt32(0), employeeName = rdr.GetString(1), employeePhone = rdr.GetString(2), employeeEmail = rdr.GetString(3), employeeAddress = rdr.GetString(4)});
                    }
                    db.CloseConnection();
                    return allEmployees;
                }
            }
            else
            {
                return new List<Employee>();
            }
        }
        public Employee GetEmployee(int employeeID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";
                MySqlCommand cmd = new MySqlCommand(stm,conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Prepare();
                using var rdr = cmd.ExecuteReader();
                rdr.Read();
                Employee employee= new Employee(){employeeID = rdr.GetInt32(0), employeeName = rdr.GetString(1), employeePhone = rdr.GetString(2), employeeEmail = rdr.GetString(3), employeeAddress = rdr.GetString(4)}; 
                db.CloseConnection();
                return employee;
            }
            else
            {
                return new Employee();
            }
        }
    }
}