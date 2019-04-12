using System;
using System.Linq;
using System.Linq.Expressions;
using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository: ICategoryRepository
    {
        private readonly EduraContext _context;

        public EfCategoryRepository(EduraContext context)
        {
            _context = context;
        }

        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public IQueryable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return _context.Categories.Where(predicate);
        }

        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public void Delete(Category entity)
        {
            _context.Categories.Remove(entity);
        }

        public void Edit(Category entity)
        {
            _context.Entry<Category>(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Category GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryName == name);
        }
    }
}