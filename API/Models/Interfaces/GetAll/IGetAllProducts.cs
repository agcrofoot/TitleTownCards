using System.Collections.Generic;

namespace API.Models.Interfaces.GetAll
{
    public interface IGetAllProducts
    {
        List<Product> GetAllProducts();
    }
}