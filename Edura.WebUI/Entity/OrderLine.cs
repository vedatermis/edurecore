using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace Edura.WebUI.Entity
{
    public class OrderLine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}