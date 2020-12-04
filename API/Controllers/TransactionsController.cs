using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces.Get;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Add;
using API.Models.Interfaces.Update;
using API.Models.Interfaces.Delete;
using API.Models.Save;
using API.Models.Read;
using API.Models.Update;
using API.Models.Delete;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        // GET: api/Transactions
        [EnableCors("Another Policy")]
        [HttpGet]
        public List<Transaction> Get()
        {
            IGetAllTransactions readObject = new ReadTransactionData();
            return readObject.GetAllTransactions();
        }

        // GET: api/Transactions/5
        [EnableCors("Another Policy")]
        [HttpGet("{transactionID}", Name = "Get Transaction")]
        public Transaction Get(int transactionID)
        {
            IGetTransaction readObject = new ReadTransactionData();
            return readObject.GetTransaction(transactionID);
        }

        // POST: api/Transactions
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] Transaction value)
        {
            IAddTransactions insertObject = new AddTransactionData();
            insertObject.AddTransaction(value);
        }

        // PUT: api/Transactions/5
        [EnableCors("Another Policy")]
        [HttpPut("{transactionID}")]
        public void Put(int transactionID, [FromBody] Transaction value)
        {
            Console.WriteLine(value.ToString());
            IUpdateTransactions editObject = new UpdateTransactionData();
            editObject.EditTransaction(value);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Another Policy")]
        [HttpDelete("{transactionID}")]
        public void Delete(int transactionID)
        {
            IDeleteTransaction deleteObject = new DeleteTransactionData();
            deleteObject.DeleteTransaction(transactionID);
        }
    }
}
