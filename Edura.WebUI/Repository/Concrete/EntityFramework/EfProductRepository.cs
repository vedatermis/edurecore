using System;
using System.Linq;
using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfProductRepository: IProductRepository
    {
        private readonly EduraContext _context;

        public EfProductRepository(EduraContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}