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
using API.Models.Interfaces.Add;
using API.Models.Save;
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
        [HttpGet("{memberID}", Name = "Get Member")]
        public Member Get(int memberID)
        {
            IGetMember readObject = new ReadMemberData();
            return readObject.GetMember(memberID);
        }

        // POST: api/Members
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] Member value)
        {
            IAddMember insertObject = new AddMemberData();
            insertObject.AddMember(value);
        }

        // PUT: api/Members/5
        [EnableCors("Another Policy")]
        [HttpPut("{memberID}")]
        public void Put(int memberID, [FromBody] Member value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Another Policy")]
        [HttpDelete("{memberID}")]
        public void Delete(int memberID)
        {
        }
    }
}
