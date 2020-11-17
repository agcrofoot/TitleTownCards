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
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO Transactions(TransactionID, TransactionDate, TransactionCost, ManagerID, ManagerName, EmployeeID, EmployeeName, MemberID)
            VALUES(@TransactionID, @TransactionDate, @TransactionCost, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName, @MemberID)";
            MySqlCommand cmd = new MySqlCommand(stm, con);
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