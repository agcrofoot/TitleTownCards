using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data.SQLite;
using System;

namespace API.Models.Read
{
    public class ReadTransactionLineItemData : IGetAllTransactionLineItems, IGetTransactionLineItem
    {
        public List<TransactionLineItem> GetAllTransactionLineItems()
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM TransactionLineItem";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<TransactionLineItem> allTransactionLineItems = new List<TransactionLineItem>();
            while(rdr.Read())
            {
                allTransactionLineItems.Add(new TransactionLineItem(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productDiscount = rdr.GetDouble(4), transactionID = rdr.GetInt32(5)});
            }
            return allTransactionLineItems;
        }
        public TransactionLineItem GetTransactionLineItem(int productID)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM TransactionLineItem WHERE ProductID = @ProductID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@ProductID", productID);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new TransactionLineItem(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productDiscount = rdr.GetDouble(4), transactionID = rdr.GetInt32(5)};
        }
    }
}