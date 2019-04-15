using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Edura.WebUI.Entity;
using Edura.WebUI.Models;

namespace Edura.WebUI.Repository.Abstract
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Category GetByName(string name);
        IEnumerable<CategoryModel> GetAllWithProductCount();
    }
}