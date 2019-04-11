using System.Linq;
using Edura.WebUI.Entity;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}