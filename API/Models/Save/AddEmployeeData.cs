using System;
using System.Data.SQLite;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddEmployeeData : IAddEmployee
    {
        public void AddEmployee(Employee value)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();
            Random random = new Random();
            int randomNumber = random.Next(10, 101);

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO Employee(EmployeeID, EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress, ManagerID)
                VALUES(@EmployeeID, @EmployeeName, @EmployeePhone, @EmployeeEmail, @EmployeeAddress, @ManagerID)";
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