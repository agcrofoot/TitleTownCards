using System;
using System.Data.SQLite;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddProductData : IAddProduct
    {
        public void AddProduct(Product value)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO Product(ProductName, ProductPrice, ProductType, ProductStatus, ProductDiscount, DateOrdered, DateAddedToInv, ManagerID, ManagerName, EmployeeID, EmployeeName)
                VALUES(@ProductName, @ProductPrice, @ProductType, @ProductStatus, @ProductDiscount, @DateOrdered, @DateAddedToInv, @ManagerID, @ManagerName, @EmployeeID, @EmployeeName)";
            cmd.Parameters.AddWithValue("@ProductName", value.productName);
            cmd.Parameters.AddWithValue("@ProductPrice", value.productPrice);
            cmd.Parameters.AddWithValue("@ProductType", value.productType);
            cmd.Parameters.AddWithValue("@ProductStatus","In Stock");
            cmd.Parameters.AddWithValue("@ProductDiscount","0");
            cmd.Parameters.AddWithValue("@DateOrdered", value.dateOrdered);
            cmd.Parameters.AddWithValue("@DateAddedToInv", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@ManagerID", value.managerID);
            cmd.Parameters.AddWithValue("@ManagerName","Preston Gates");
            cmd.Parameters.AddWithValue("@EmployeeID", value.employeeID);
            cmd.Parameters.AddWithValue("@EmployeeName","Molly");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}