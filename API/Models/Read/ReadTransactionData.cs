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
                        Transaction temp = new Transaction();
                        temp.transactionID = rdr.GetInt32(0);
                        temp.transactionDate = rdr.GetString(1); 
                        temp.transactionCost = rdr.GetDouble(2); 
                        temp.managerID = rdr.GetInt32(3);
                        temp.managerName = rdr.GetString(4); 
                        temp.employeeID = rdr.GetInt32(5);
                        temp.employeeName = rdr.GetString(6); 
                        if(rdr["MemberID"] == DBNull.Value)
                        {
                            temp.memberID = 0;
                        }
                        else
                        {
                            temp.memberID = rdr.GetInt32(7);
                        }
                        
                        allTransactions.Add(temp);
                    }
                    db.CloseConnection();
                    Console.WriteLine("Read in values");
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
                Transaction transaction = new Transaction();
                transaction.transactionID = rdr.GetInt32(0);
                transaction.transactionDate = rdr.GetString(1); 
                transaction.transactionCost = rdr.GetDouble(2); 
                transaction.managerID = rdr.GetInt32(3);
                transaction.managerName = rdr.GetString(4); 
                transaction.employeeID = rdr.GetInt32(5);
                transaction.employeeName = rdr.GetString(6); 
                if(rdr["MemberID"] == DBNull.Value)
                {
                    transaction.memberID = 0;
                }
                else
                {
                    transaction.memberID = rdr.GetInt32(7);
                }
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