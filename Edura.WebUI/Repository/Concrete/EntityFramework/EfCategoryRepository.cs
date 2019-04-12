using System.Linq;
using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository: EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(EduraContext context) : base(context) { }

        public EduraContext EduraContext => Context as EduraContext;

        public Category GetByName(string name)
        {
            return EduraContext.Categories.FirstOrDefault(i => i.CategoryName == name);
        }
    }
}
