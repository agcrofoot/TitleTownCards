using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddProductData : IAddProduct
    {
        public void AddProduct(Product value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
                cmd.Parameters.AddWithValue("@ProductName", value.productName);
                cmd.Parameters.AddWithValue("@ProductPrice", value.productPrice);
                cmd.Parameters.AddWithValue("@ProductType", value.productType);
                cmd.Parameters.AddWithValue("@ProductStatus","In Stock");
                cmd.Parameters.AddWithValue("@ProductDiscount"," ");
                cmd.Parameters.AddWithValue("@DateOrdered", value.dateOrdered);
                cmd.Parameters.AddWithValue("@DateAddedToInv", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@ManagerID", value.managerID);
                cmd.Parameters.AddWithValue("@ManagerName",value.managerName);
                cmd.Parameters.AddWithValue("@EmployeeID", value.employeeID); 
                cmd.Parameters.AddWithValue("@EmployeeName",value.employeeName);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}