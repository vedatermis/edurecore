using System.Collections.Generic;
using Edura.WebUI.Entity;

namespace Edura.WebUI.Models
{
    public class CatalogListModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

    }
}
