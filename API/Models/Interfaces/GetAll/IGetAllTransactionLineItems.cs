using System.Collections.Generic;

namespace API.Models.Interfaces.GetAll
{
    public interface IGetAllTransactionLineItems
    {
        List<TransactionLineItem> GetAllTransactionLineItems();
    }
}