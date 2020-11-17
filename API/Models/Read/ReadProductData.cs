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
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Product";
            MySqlCommand cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Product> allProducts = new List<Product>();
            while(rdr.Read())
            {
                allProducts.Add(new Product(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productStatus = rdr.GetString(4), productDiscount = rdr.GetDouble(5), dateOrdered = rdr.GetString(6), dateAddedToInv = rdr.GetString(7), managerID = rdr.GetInt32(8), managerName = rdr.GetString(9), employeeID = rdr.GetInt32(10), employeeName = rdr.GetString(11)});
            }
            return allProducts;
        }
        public Product GetProduct(int productID)
        {
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Product WHERE ProductID = @ProductID";
            MySqlCommand cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@ProductID", productID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Product(){productID = rdr.GetInt32(0), productName = rdr.GetString(1), productPrice = rdr.GetDouble(2), productType = rdr.GetString(3), productStatus = rdr.GetString(4), productDiscount = rdr.GetDouble(5), dateOrdered = rdr.GetString(6), dateAddedToInv = rdr.GetString(7), managerID = rdr.GetInt32(8), managerName = rdr.GetString(9), employeeID = rdr.GetInt32(10), employeeName = rdr.GetString(11)};
        }
    }
}