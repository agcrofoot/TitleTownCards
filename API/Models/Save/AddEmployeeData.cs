using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddEmployeeData : IAddEmployee
    {
        public void AddEmployee(Employee value)
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();
            Random random = new Random();
            int randomNumber = random.Next(10, 101);

            string stm = @"INSERT INTO Employee(EmployeeID, EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress, ManagerID)
                VALUES(@EmployeeID, @EmployeeName, @EmployeePhone, @EmployeeEmail, @EmployeeAddress, @ManagerID)";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@EmployeeID", randomNumber);
            cmd.Parameters.AddWithValue("@EmployeeName", value.employeeName);
            cmd.Parameters.AddWithValue("@EmployeePhone",value.employeePhone);
            cmd.Parameters.AddWithValue("@EmployeeEmail",value.employeeEmail);
            cmd.Parameters.AddWithValue("@EmployeeAddress", value.employeeAddress);
            cmd.Parameters.AddWithValue("@ManagerID",value.managerID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}