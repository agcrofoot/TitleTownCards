using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace API.Models.Read
{
    public class ReadTransactionLineItemData : IGetAllTransactionLineItems, IGetTransactionLineItem
    {
        public List<TransactionLineItem> GetAllTransactionLineItems()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM TransactionLineItem";
                MySqlCommand cmd = new MySqlCommand(stm,conn);

                List<TransactionLineItem> allTransactionLineItems = new List<TransactionLineItem>();
                using(var rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        allTransactionLineItems.Add(new TransactionLineItem(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productDiscount = rdr.GetDouble(4), transactionID = rdr.GetInt32(5)});
                    
                    }
                    db.CloseConnection();
                    return allTransactionLineItems;
                }
            }
            else
            {
                return new List<TransactionLineItem>();
            }
        }
        public TransactionLineItem GetTransactionLineItem(int productID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM TransactionLineItem WHERE ProductID = @ProductID";
                MySqlCommand cmd = new MySqlCommand(stm,conn);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                TransactionLineItem transactionlineitem = new TransactionLineItem(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productDiscount = rdr.GetDouble(4), transactionID = rdr.GetInt32(5)};
                db.CloseConnection();
                return transactionlineitem;
            }
            else
            {
                return new TransactionLineItem();
            }
        }
    }
}