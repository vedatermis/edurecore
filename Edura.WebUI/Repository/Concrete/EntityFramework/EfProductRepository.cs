using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfProductRepository: IProductRepository
    {
        private readonly EduraContext _context;

        public EfProductRepository(EduraContext context)
        {
            _context = context;
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(s => s.Id == id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public IQueryable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.Where(predicate);
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public void Edit(Product entity)
        {
            _context.Entry<Product>(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Product> GetTop5Products()
        {
            return _context.Products.OrderByDescending(i => i.Id).Take(5).ToList();
        }
    }
}