namespace API.Models.Interfaces.Update
{
    public interface IUpdateTransactionLineItems
    {
        public void EditTransactionLineItem(int id, TransactionLineItem value);
    }
}