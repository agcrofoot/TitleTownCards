namespace API.Models.Interfaces.Get
{
    public interface IGetTransaction
    {
        Transaction GetTransaction(int transactionID);
    }
}