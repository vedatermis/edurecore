using System;
using Edura.WebUI.Repository.Abstract;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfUnitOfWork: IUnitOfWork
    {
        private readonly EduraContext _dbContext;

        public EfUnitOfWork(EduraContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext cannot be null");
        }

        private IProductRepository _products;
        private ICategoryRepository _categories;
        private IOrderRepository _orders;

        public IProductRepository Products => _products ?? (_products = new EfProductRepository(_dbContext));

        public ICategoryRepository Categories => _categories ?? (_categories = new EfCategoryRepository(_dbContext));
        public IOrderRepository Orders => _orders ?? (_orders = new EfOrderRepository(_dbContext));

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}