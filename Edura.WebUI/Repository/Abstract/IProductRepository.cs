using System.Collections.Generic;
using Edura.WebUI.Entity;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        List<Product> GetTop5Products();
    }
}