using System;
using System.Data.SQLite;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddTransactionData : IAddTransactions
    {
        public void AddTransaction(Transaction value)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO Transactions(TransactionID, TransactionDate, TransactionCost, ManagerID, ManagerName, EmployeeID, EmployeeName, MemberID)
                VALUES(@TransactionID, @TransactionDate, @TransactionCost, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName, @MemberID)";
            cmd.Parameters.AddWithValue("@TransactionID",value.transactionID);
            cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@TransactionCost", value.transactionCost);
            cmd.Parameters.AddWithValue("@ManagerID", value.managerID);
            cmd.Parameters.AddWithValue("@ManagerName","Preston");
            cmd.Parameters.AddWithValue("@EmployeeID",value.employeeID);
            cmd.Parameters.AddWithValue("@EmployeeName","Kevin");
            cmd.Parameters.AddWithValue("@MemberID",value.memberID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}