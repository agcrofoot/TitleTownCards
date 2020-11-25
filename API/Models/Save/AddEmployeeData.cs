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
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                Random random = new Random();
                int randomNumber = random.Next(10, 101);

                cmd.CommandText = @"INSERT INTO Employee(EmployeeID, EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress)
                VALUES(@EmployeeID, @EmployeeName, @EmployeePhone, @EmployeeEmail, @EmployeeAddress)";
                cmd.Parameters.AddWithValue("@EmployeeID", randomNumber);
                cmd.Parameters.AddWithValue("@EmployeeName", value.employeeName);
                cmd.Parameters.AddWithValue("@EmployeePhone",value.employeePhone);
                cmd.Parameters.AddWithValue("@EmployeeEmail",value.employeeEmail);
                cmd.Parameters.AddWithValue("@EmployeeAddress", value.employeeAddress);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}