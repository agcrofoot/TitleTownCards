namespace API.Models
{
    public class Transaction
    {
        public int transactionID{get; set;}
        public string transactionDate{get; set;}
        public double transactionCost{get; set;}
        public int managerID{get; set;}
        public string managerName{get; set;}
        public int employeeID{get; set;}
        public string employeeName{get; set;}
        public int? memberID{get; set;}
        public override string ToString()
        {
            return transactionID + "/" + transactionDate + "/" + transactionCost + "/" + managerID + "/" + managerName + "/" + employeeID + "/" + employeeName + "/" + memberID;
        }
    }
}