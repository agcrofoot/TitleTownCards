using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Update;

namespace API.Models.Update
{
    public class UpdateProductData : IUpdateProducts
    {
        public void EditProduct(Product value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                if(value.productName != null)
                {
                    cmd.CommandText = @"UPDATE Product SET ProductName = @ProductName
                    WHERE ProductID = @ProductID";
                    cmd.Parameters.AddWithValue("@ProductID", value.productID);
                    cmd.Parameters.AddWithValue("@ProductName", value.productName);
                }

                if(value.productPrice != null)
                {
                    cmd.CommandText = @"UPDATE Product SET ProductPrice = @ProductPrice
                    WHERE ProductID = @ProductID";
                    cmd.Parameters.AddWithValue("@ProductID", value.productID);
                    cmd.Parameters.AddWithValue("@ProductPrice", value.productPrice);
                }

                if(value.productType != null)
                {
                    cmd.CommandText = @"UPDATE Product SET ProductType = @ProductType
                    WHERE ProductID = @ProductID";
                    cmd.Parameters.AddWithValue("@ProductID", value.productID);
                    cmd.Parameters.AddWithValue("@ProductType", value.productType);
                }
    
                if(value.productStatus != null)
                {
                    cmd.CommandText = @"UPDATE Product SET ProductStatus = @ProductStatus
                    WHERE ProductID = @ProductID";
                    cmd.Parameters.AddWithValue("@ProductID", value.productID);
                    cmd.Parameters.AddWithValue("@ProductStatus", value.productStatus);
                }

                if(value.productDiscount != null)
                {
                    cmd.CommandText = @"UPDATE Product SET ProductDiscount = @ProductDiscount
                    WHERE ProductID = @ProductID";
                    cmd.Parameters.AddWithValue("@ProductID", value.productID);
                    cmd.Parameters.AddWithValue("@ProductDiscount", value.productDiscount);
                }
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}