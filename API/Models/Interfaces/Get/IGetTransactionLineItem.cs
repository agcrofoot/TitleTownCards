namespace API.Models.Interfaces.Get
{
    public interface IGetTransactionLineItem
    {
        TransactionLineItem GetTransactionLineItem(int productID, int transactionID);
    }
}