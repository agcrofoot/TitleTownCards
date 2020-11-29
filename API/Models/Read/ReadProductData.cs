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
                        Product temp = new Product();
                        temp.productID = rdr.GetInt32(0); 
                        temp.productName = rdr.GetString(1);
                        temp.productPrice = rdr.GetDouble(2);
                        temp.productType = rdr.GetString(3);
                        temp.productStatus = rdr.GetString(4);
                        if(rdr["ProductDiscount"] == DBNull.Value)
                        {
                            temp.productDiscount = 0;
                        }
                        else
                        {
                            temp.productDiscount = rdr.GetDouble(5);
                        }
                        temp.dateOrdered = rdr.GetString(6);
                        temp.dateAddedToInv = rdr.GetString(7);
                        temp.managerID = rdr.GetInt32(8);
                        temp.managerName = rdr.GetString(9);
                        temp.employeeID = rdr.GetInt32(10);
                        temp.employeeName = rdr.GetString(11);
                    
                        allProducts.Add(temp);
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
                Product product = new Product();
                product.productID = rdr.GetInt32(0); 
                product.productName = rdr.GetString(1);
                product.productPrice = rdr.GetDouble(2);
                product.productType = rdr.GetString(3);
                product.productStatus = rdr.GetString(4);
                if(rdr["ProductDiscount"] == DBNull.Value)
                {
                    product.productDiscount = 0;
                }
                else
                {
                    product.productDiscount = rdr.GetDouble(5);
                }
                product.dateOrdered = rdr.GetString(6);
                product.dateAddedToInv = rdr.GetString(7);
                product.managerID = rdr.GetInt32(8);
                product.managerName = rdr.GetString(9);
                product.employeeID = rdr.GetInt32(10);
                product.employeeName = rdr.GetString(11);
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