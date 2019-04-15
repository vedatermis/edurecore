using System.Linq;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Edura.WebUI.Components
{
    public class FeaturedProducts: ViewComponent
    {
        private readonly IProductRepository _productRepository;

        public FeaturedProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_productRepository.
                GetAll().
                Where(i => i.IsApproved && i.IsFeatured).ToList());
        }
       
    }
}
