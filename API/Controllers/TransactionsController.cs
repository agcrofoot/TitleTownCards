using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces.Get;
using API.Models.Interfaces.GetAll;
using API.Models.Read;
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
        [HttpGet("{id}")]
        public Transaction Get(int transactionID)
        {
            IGetTransaction readObject = new ReadTransactionData();
            return readObject.GetTransaction(transactionID);
        }

        // POST: api/Transactions
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Transactions/5
        [EnableCors("Another Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Another Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
