using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Entity;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var enity = _unitOfWork.Categories.GetAll()
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Product)
                .Where(i => i.Id == id)
                .Select(s => new AdminEditCategoryModel
                {
                    CategoryId = s.Id,
                    CategoryName = s.CategoryName,
                    Products = s.ProductCategories.Select(a => new AdminEditCategoryProduct()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.ProductName,
                        Image = a.Product.Image,
                        IsApproved = a.Product.IsApproved,
                        IsFeatured = a.Product.IsFeatured,
                        IsHome = a.Product.IsHome

                    }).ToList()
                }).FirstOrDefault();

            return View(enity);
        }

        [HttpPost]
        public IActionResult EditCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.Edit(entity);
                _unitOfWork.SaveChanges();

                return RedirectToAction("CatalogList");
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCategory(int ProductId, int CategoryId)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.RemoveFromCategory(ProductId, CategoryId);
                _unitOfWork.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        public IActionResult CatalogList()
        {
            var model = new CatalogListModel
            {
                Categories = _unitOfWork.Categories.GetAll().ToList(),
                Products = _unitOfWork.Products.GetAll().ToList()

            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.Add(entity);
                _unitOfWork.SaveChanges();

                return Ok(entity);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", file.FileName);
                    var path_tn = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products\\tn", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        product.Image = file.FileName;
                    }

                    using (var stream = new FileStream(path_tn, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                product.DateAdded = DateTime.Now;
                _unitOfWork.Products.Add(product);
                _unitOfWork.SaveChanges();

                return RedirectToAction("CatalogList");
            }
            return View(product);
        }
    }
}