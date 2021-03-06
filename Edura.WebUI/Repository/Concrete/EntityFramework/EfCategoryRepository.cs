﻿using System.Collections.Generic;
using System.Linq;
using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(EduraContext context) : base(context) { }

        public EduraContext EduraContext => Context as EduraContext;

        public Category GetByName(string name)
        {
            return EduraContext.Categories.FirstOrDefault(i => i.CategoryName == name);
        }

        public IEnumerable<CategoryModel> GetAllWithProductCount()
        {
            return GetAll().Select(s => new CategoryModel
            {
                Id = s.Id,
                CategoryName = s.CategoryName,
                Count = s.ProductCategories.Count
            });
        }

        public void RemoveFromCategory(int ProductId, int CategoryId)
        {
            var cmd = $"delete from ProductCategory where ProductId = {ProductId} and CategoryId = {CategoryId}";
            Context.Database.ExecuteSqlCommand(cmd);
        }
    }
}
