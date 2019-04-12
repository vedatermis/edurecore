using System.Collections.Generic;
using System.Linq;
using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfProductRepository: EfGenericRepository<Product>, IProductRepository
    {
        public EfProductRepository(EduraContext context) : base(context) { }

        public EduraContext EduraContext => Context as EduraContext;

        public List<Product> GetTop5Products()
        {
            return EduraContext.Products.OrderByDescending(i => i.Id).Take(5).ToList();
        }

        
    }
}