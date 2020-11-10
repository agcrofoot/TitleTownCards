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
    public class MembersController : ControllerBase
    {
        // GET: api/Members
        [EnableCors("Another Policy")]
        [HttpGet]
        public List<Member> Get()
        {
            IGetAllMembers readObject = new ReadMemberData();
            return readObject.GetAllMembers();
        }

        // GET: api/Members/5
        [EnableCors("Another Policy")]
        [HttpGet("{id}")]
        public Member Get(int memberID)
        {
            IGetMember readObject = new ReadMemberData();
            return readObject.GetMember(memberID);
        }

        // POST: api/Members
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Members/5
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
