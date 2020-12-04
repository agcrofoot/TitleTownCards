using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Update;

namespace API.Models.Update
{
    public class UpdateEmployeeData : IUpdateEmployees
    {
        public void EditEmployee(Employee value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"UPDATE Employee SET EmployeeName = @EmployeeName, EmployeePhone = @EmployeePhone, EmployeeEmail = @EmployeeEmail, EmployeeAddress = @EmployeeAddress WHERE EmployeeID = @EmployeeID";
                cmd.Parameters.AddWithValue("@EmployeeID", value.employeeID);
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