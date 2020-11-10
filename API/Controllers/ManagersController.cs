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
    public class ManagersController : ControllerBase
    {
        // GET: api/Managers
        [EnableCors("Another Policy")]
        [HttpGet]
        public List<Manager> Get()
        {
            IGetAllManagers readObject = new ReadManagerData();
            return readObject.GetAllManagers();
        }

        // GET: api/Managers/5
        [EnableCors("Another Policy")]
        [HttpGet("{id}")]
        public Manager Get(int managerID)
        {
            IGetManager readObject = new ReadManagerData();
            return readObject.GetManager(managerID);
        }

        // POST: api/Managers
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Managers/5
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
