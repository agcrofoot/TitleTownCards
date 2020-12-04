using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddTransactionData : IAddTransactions
    {
        public void AddTransaction(Transaction value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;
                if(value.memberID == 0)
                {
                    value.memberID = null;
                }

                if(value.memberID == null)
                {
                    cmd.CommandText = @"INSERT INTO Transactions(TransactionID, TransactionDate, TransactionCost, ManagerID, ManagerName, EmployeeID, EmployeeName)
                    VALUES(@TransactionID, @TransactionDate, @TransactionCost, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
                    cmd.Parameters.AddWithValue("@TransactionID",value.transactionID);
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@TransactionCost", value.transactionCost);
                    cmd.Parameters.AddWithValue("@ManagerID", value.managerID);
                    cmd.Parameters.AddWithValue("@ManagerName",value.managerName);
                    cmd.Parameters.AddWithValue("@EmployeeID", value.employeeID);
                    cmd.Parameters.AddWithValue("@EmployeeName",value.employeeName);
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO Transactions(TransactionID, TransactionDate, TransactionCost, ManagerID, ManagerName, EmployeeID, EmployeeName, MemberID)
                    VALUES(@TransactionID, @TransactionDate, @TransactionCost, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName, @MemberID)";
                    cmd.Parameters.AddWithValue("@TransactionID",value.transactionID);
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@TransactionCost", value.transactionCost);
                    cmd.Parameters.AddWithValue("@ManagerID", value.managerID);
                    cmd.Parameters.AddWithValue("@ManagerName",value.managerName);
                    cmd.Parameters.AddWithValue("@EmployeeID", value.employeeID);
                    cmd.Parameters.AddWithValue("@EmployeeName",value.employeeName);
                    cmd.Parameters.AddWithValue("@MemberID",value.memberID);
                }
                
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}