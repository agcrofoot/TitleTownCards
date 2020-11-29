using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Delete;

namespace API.Models.Delete
{
    public class DeleteTransactionLineItemData : IDeleteTransactionLineItem
    {
        public void DeleteTransactionLineItem(int productID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM TransactionLineItem WHERE ProductID = @ProductID";
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}