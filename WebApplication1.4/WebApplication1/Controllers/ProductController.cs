using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Products;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        readonly IWebProductsService productsService;
        readonly IWebCategoryService categoryService;

        public ProductController(IWebProductsService productsService,
                                 IWebCategoryService categoryService)
        {
            this.productsService = productsService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = productsService.GetAllProducts();
            return View(new ProductIndexViewModel
            {
                Products = this.productsService.GetAllProducts()
            });
        }

        public IActionResult Create()
        {
            ViewBag.categories = categoryService.GetAllCategory().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {
            var tmpCategory = this.categoryService.GetCategoryById(product.CategoryId);
            ViewBag.categories = categoryService.GetAllCategory().ToList();
            this.productsService.CreateNewProduct(product, tmpCategory);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || productsService.GetProductById((int)id) is null)
            {
                return BadRequest("Product was not found");
            }
            productsService.RemoveProductById((int)id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.categories = categoryService.GetAllCategory().ToList();

            if (id is null || productsService.GetProductById((int)id) is null)
            {
                return BadRequest("Product was not found");
            }
            return View(productsService.GetProductById((int)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel product)
        {
            if (productsService.GetProductById((int)product.Id) is null)
            {
                return BadRequest("Product was not found");
            }
            productsService.UpdateProduct(product);
            //return View(productsService.GetProductById(product.Id));
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int? id)
        {
            if (id is null || productsService.GetProductById((int)id) is null)
            {
                return BadRequest("Product was not found");
            }
            return View(productsService.GetProductById((int)id));
        }
    }
}
