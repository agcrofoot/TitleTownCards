using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data.SQLite;
using System;

namespace API.Models.Read
{
    public class ReadTransactionData : IGetAllTransactions, IGetTransaction
    {
        public List<Transaction> GetAllTransactions()
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Transactions";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<Transaction> allTransactions = new List<Transaction>();
            while(rdr.Read())
            {
                allTransactions.Add(new Transaction(){transactionID = rdr.GetInt32(0), transactionDate = rdr.GetString(1), managerID = rdr.GetInt32(2), managerName = rdr.GetString(3), employeeID = rdr.GetInt32(4), employeeName = rdr.GetString(5), memberID = rdr.GetInt32(6)});
            }
            return allTransactions;
        }
        public Transaction GetTransaction(int transactionID)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Transactions WHERE TransactionID = @TransactiontID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@TransactionID", transactionID);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Transaction(){transactionID = rdr.GetInt32(0), transactionDate = rdr.GetString(1), managerID = rdr.GetInt32(2), managerName = rdr.GetString(3), employeeID = rdr.GetInt32(4), employeeName = rdr.GetString(5), memberID = rdr.GetInt32(6)};
        }
    }
}