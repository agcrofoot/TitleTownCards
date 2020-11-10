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
using API.Models.Read;
using API.Models.Save;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/Products
        [EnableCors("Another Policy")]
        [HttpGet]
        public List<Product> Get()
        {
            IGetAllProducts readObject = new ReadProductData();
            return readObject.GetAllProducts();
        }

        // GET: api/Products/5
        [EnableCors("Another Policy")]
        [HttpGet("{id}")]
        public Product Get(int productID)
        {
            IGetProduct readObject = new ReadProductData();
            return readObject.GetProduct(productID);
        }

        // POST: api/Products
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            IAddProduct insertObject = new AddProductData();
            insertObject.AddProduct(value);
        }

        // PUT: api/Products/5
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
