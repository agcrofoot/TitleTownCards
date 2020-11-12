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
    public class TransactionLineItemsController : ControllerBase
    {
        // GET: api/TransactionLineItems
        [EnableCors("Another Policy")]
        [HttpGet]
        public List<TransactionLineItem> Get()
        {
            IGetAllTransactionLineItems readObject = new ReadTransactionLineItemData();
            return readObject.GetAllTransactionLineItems();
        }

        // GET: api/TransactionLineItems/5
        [EnableCors("Another Policy")]
        [HttpGet("{id}", Name = "Get TLI")]
        public TransactionLineItem Get(int productID, int transactionID)
        {
            IGetTransactionLineItem readObject = new ReadTransactionLineItemData();
            return readObject.GetTransactionLineItem(productID, transactionID);
        }

        // POST: api/TransactionLineItems
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TransactionLineItems/5
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
