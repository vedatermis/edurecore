using System;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }

        int SaveChanges();
    }
}