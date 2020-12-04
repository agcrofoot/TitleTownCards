using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Delete;

namespace API.Models.Delete
{
    public class DeleteTransactionData : IDeleteTransaction
    {
        public void DeleteTransaction(int transactionID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM Transactions WHERE TransactionID = @TransactionID";
                cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}