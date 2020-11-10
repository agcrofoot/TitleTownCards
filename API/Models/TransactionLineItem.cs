namespace API.Models
{
    public class TransactionLineItem
    {
        public int productID{get; set;}
        public string productName{get; set;}
        public double productPrice{get; set;}
        public string productType{get; set;}
        public double productDiscount{get; set;}
        public int transactionID{get; set;}
        public override string ToString()
        {
            return productID + "/" + productName + "/" + productPrice + "/" + productType + "/" + productDiscount + "/" + transactionID;
        }
    }
}