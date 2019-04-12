using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Edura.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Products.GetAll());
        }

        public IActionResult Create()
        {
            var prd = new Product();
            prd.ProductName = "Yeni Ürün";
            prd.Price = 123;

            _unitOfWork.Products.Add(prd);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}