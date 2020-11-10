namespace API.Models
{
    public class Product
    {
        public int productID{get; set;}
        public string productName{get; set;}
        public double productPrice{get; set;}
        public string productType{get; set;}
        public string productStatus{get; set;}
        public double productDiscount{get; set;}
        public string dateOrdered{get; set;}
        public string dateAddedToInv{get; set;}
        public int managerID{get; set;}
        public string managerName{get; set;}
        public int employeeID{get; set;}
        public string employeeName{get; set;}
        public override string ToString()
        {
            return productID + "/" + productName + "/" + productPrice + "/" + productType + "/" + productStatus + "/" + productDiscount + "/" + dateOrdered + "/" + dateAddedToInv + "/" + managerID + "/" + managerName + "/" + employeeID + "/" + employeeName;
        }
    }
}