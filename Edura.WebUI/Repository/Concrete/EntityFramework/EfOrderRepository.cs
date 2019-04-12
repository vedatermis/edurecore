using System;
using System.Linq;
using System.Linq.Expressions;
using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfOrderRepository: IOrderRepository
    {
        private readonly EduraContext _context;

        public EfOrderRepository(EduraContext context)
        {
            _context = context;
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Order> GetAll()
        {
            return _context.Orders;
        }

        public IQueryable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return _context.Orders.Where(predicate);
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
        }

        public void Edit(Order entity)
        {
            _context.Entry<Order>(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}