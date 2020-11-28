using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Update;

namespace API.Models.Update
{
    public class UpdateTransactionData : IUpdateTransactions
    {
        public void EditTransaction(Transaction value)
        {
            Console.WriteLine("In the edit" + value.ToString());
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = @"UPDATE Transactions SET TransactionCost = @TransactionCost WHERE TransactionID = @TransactionID";
                cmd.Parameters.AddWithValue("@TransactionID",value.transactionID);
                cmd.Parameters.AddWithValue("@TransactionCost", value.transactionCost);
                
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}