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
    public class EmployeesController : ControllerBase
    {
        // GET: api/Employees
        [EnableCors("Another Policy")]
        [HttpGet]
        public List<Employee> Get()
        {
            IGetAllEmployees readObject = new ReadEmployeeData();
            return readObject.GetAllEmployees();
        }

        // GET: api/Employees/5
        [EnableCors("Another Policy")]
        [HttpGet("{employeeID}", Name = "Get Employee")]
        public Employee Get(int employeeID)
        {
            IGetEmployee readObject = new ReadEmployeeData();
            return readObject.GetEmployee(employeeID);
        }

        // POST: api/Employees
        [EnableCors("Another Policy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employees/5
        [EnableCors("Another Policy")]
        [HttpPut("{employeeID}")]
        public void Put(int employeeID, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("Another Policy")]
        [HttpDelete("{employeeID}")]
        public void Delete(int employeeID)
        {
        }
    }
}
