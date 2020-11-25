using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace API.Models.Read
{
    public class ReadTransactionData : IGetAllTransactions, IGetTransaction
    {
        public List<Transaction> GetAllTransactions()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Transactions";
                MySqlCommand cmd = new MySqlCommand(stm,conn);

                List<Transaction> allTransactions = new List<Transaction>();
                using(var rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        allTransactions.Add(new Transaction(){transactionID = rdr.GetInt32(0), transactionDate = rdr.GetString(1), transactionCost = rdr.GetDouble(2), managerID = rdr.GetInt32(3), managerName = rdr.GetString(4), employeeID = rdr.GetInt32(5), employeeName = rdr.GetString(6), memberID = rdr.GetInt32(7)});
                    
                    }
                    db.CloseConnection();
                    return allTransactions;
                }
            }
            else
            {
                return new List<Transaction>();
            }
        }
        public Transaction GetTransaction(int transactionID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Transactions WHERE TransactionID = @TransactionID";
                MySqlCommand cmd = new MySqlCommand(stm,conn);
                cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Transaction transaction = new Transaction(){transactionID = rdr.GetInt32(0), transactionDate = rdr.GetString(1), transactionCost = rdr.GetDouble(2), managerID = rdr.GetInt32(3), managerName = rdr.GetString(4), employeeID = rdr.GetInt32(5), employeeName = rdr.GetString(6), memberID = rdr.GetInt32(7)};
                db.CloseConnection();
                return transaction;
            }
            else
            {
                return new Transaction();
            }
        }
    } 
}