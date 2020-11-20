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
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM TransactionLineItem";
            MySqlCommand cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<TransactionLineItem> allTransactionLineItems = new List<TransactionLineItem>();
            while(rdr.Read())
            {
                allTransactionLineItems.Add(new TransactionLineItem(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productDiscount = rdr.GetDouble(4), transactionID = rdr.GetInt32(5)});
            }
            return allTransactionLineItems;
        }
        public TransactionLineItem GetTransactionLineItem(int productID)
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM TransactionLineItem WHERE ProductID = @ProductID";
            MySqlCommand cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@ProductID", productID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new TransactionLineItem(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productDiscount = rdr.GetDouble(4), transactionID = rdr.GetInt32(5)};
        }
    }
}