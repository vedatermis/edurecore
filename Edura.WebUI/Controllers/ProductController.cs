using System.Linq;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 2;
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(_productRepository
                .GetAll()
                .Where(i => i.Id == id)
                .Include(i => i.Images)
                .Include(i => i.Attributes)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .Select(i => new ProductDetailsModel
                {
                    Product = i,
                    Categories = i.ProductCategories.Select(a => a.Category).ToList(),
                    ProductImages = i.Images,
                    ProductAttributes = i.Attributes
                }).FirstOrDefault()
            );
        }

        public IActionResult List(string category, int page = 1)
        {
            var products = _productRepository.GetAll();

            if (!string.IsNullOrEmpty(category))
            {
                products = products
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category.CategoryName == category));
            }

            var count = products.Count();
            products = products.Skip((page - 1) * PageSize).Take(PageSize);

            return View(new ProductListModel() { Products = products, PageInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = count
                }});
        }
    }
}