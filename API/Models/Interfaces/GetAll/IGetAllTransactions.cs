using System.Collections.Generic;

namespace API.Models.Interfaces.GetAll
{
    public interface IGetAllTransactions
    {
        List<Transaction> GetAllTransactions();
    }
}