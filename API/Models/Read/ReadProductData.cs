using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace API.Models.Read
{
    public class ReadProductData : IGetAllProducts, IGetProduct
    {
        public List<Product> GetAllProducts()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Product";
                MySqlCommand cmd = new MySqlCommand(stm,conn);

                List<Product> allProducts = new List<Product>();
                using(var rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        allProducts.Add(new Product(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productStatus = rdr.GetString(4), productDiscount = rdr.GetDouble(5), dateOrdered = rdr.GetString(6), dateAddedToInv = rdr.GetString(7), managerID = rdr.GetInt32(8), managerName = rdr.GetString(9), employeeID = rdr.GetInt32(10), employeeName = rdr.GetString(11)});
                    
                    }
                    db.CloseConnection();
                    return allProducts;
                }
            }
            else
            {
                return new List<Product>();
            }
        }
        public Product GetProduct(int productID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Product WHERE ProductID = @ProductID";
                MySqlCommand cmd = new MySqlCommand(stm,conn);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Prepare();
                using MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Product product = new Product(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productStatus = rdr.GetString(4), productDiscount = rdr.GetDouble(5), dateOrdered = rdr.GetString(6), dateAddedToInv = rdr.GetString(7), managerID = rdr.GetInt32(8), managerName = rdr.GetString(9), employeeID = rdr.GetInt32(10), employeeName = rdr.GetString(11)};
                db.CloseConnection();
                return product;
            }
            else
            {
                return new Product();
            }
            
        }
    }
}