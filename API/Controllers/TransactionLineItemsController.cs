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
using API.Models.Save;
using API.Models.Read;
using API.Models.Update;
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
        [HttpGet("{productID}", Name = "Get TLI")]
        public TransactionLineItem Get(int productID)
        {
            IGetTransactionLineItem readObject = new ReadTransactionLineItemData();
            return readObject.GetTransactionLineItem(productID);
        }

        // POST: api/TransactionLineItems
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] TransactionLineItem value)
        {
            IAddTransactionLineItem insertObject = new AddTransactionLineItemData();
            insertObject.AddTLI(value);
        }

        // PUT: api/TransactionLineItems/5
        [EnableCors("Another Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TransactionLineItem value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Another Policy")]
        [HttpDelete("{productID}")]
        public void Delete(int productID)
        {
        }
    }
}
