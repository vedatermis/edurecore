using System.Collections.Generic;

namespace Edura.WebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

    }
}