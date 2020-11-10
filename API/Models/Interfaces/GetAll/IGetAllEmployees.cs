using System.Collections.Generic;

namespace API.Models.Interfaces.GetAll
{
    public interface IGetAllEmployees
    {
        List<Employee> GetAllEmployees();
    }
}