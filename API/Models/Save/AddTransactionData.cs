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

                cmd.CommandText = @"INSERT INTO Transactions(TransactionID, TransactionDate, TransactionCost, ManagerID, ManagerName, EmployeeID, EmployeeName, MemberID)
                VALUES(@TransactionID, @TransactionDate, @TransactionCost, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName, @MemberID)";
                cmd.Parameters.AddWithValue("@TransactionID",value.transactionID);
                cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@TransactionCost", value.transactionCost);
                cmd.Parameters.AddWithValue("@ManagerID", "100");
                cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
                cmd.Parameters.AddWithValue("@EmployeeID","20");
                cmd.Parameters.AddWithValue("@EmployeeName","Kevin");
                cmd.Parameters.AddWithValue("@MemberID",value.memberID);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}