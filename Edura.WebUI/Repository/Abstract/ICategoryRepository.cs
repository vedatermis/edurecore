using System;
using System.Linq;
using System.Linq.Expressions;
using Edura.WebUI.Entity;

namespace Edura.WebUI.Repository.Abstract
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Category GetByName(string name);
    }
}