using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddTransactionLineItemData : IAddTransactionLineItem
    {
        public void AddTLI(TransactionLineItem value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"INSERT INTO TransactionLineItem(ProductID, ProductName, ProductPrice, ProductType, ProductDiscount, TransactionID)
                VALUES(@ProductID, @ProductName, @ProductPrice, @ProductType, @ProductDiscount, @TransactionID)";
                cmd.Parameters.AddWithValue("@ProductID",value.productID);
                cmd.Parameters.AddWithValue("@ProductName", value.productName);
                cmd.Parameters.AddWithValue("@ProductPrice", value.productPrice);
                cmd.Parameters.AddWithValue("@ProductType",value.productType);
                cmd.Parameters.AddWithValue("@ProductDiscount",value.productDiscount);
                cmd.Parameters.AddWithValue("@TransactionID", value.transactionID);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}