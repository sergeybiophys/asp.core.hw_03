using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Categories;
using WebApplication1.Models.Category;
using WebApplication1.Models.Products;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        readonly IWebCategoryService categoryService;
        readonly IWebProductsService productsService;

        public CategoryController(IWebCategoryService categoryService,
                                  IWebProductsService productsService)
        {
            this.categoryService = categoryService;
            this.productsService = productsService;
        }

        //static List<CategoryViewModel> categories = new List<CategoryViewModel>
        //{
        //    new CategoryViewModel{Id=1,Name="fruits"},

        //    new CategoryViewModel{Id=2,Name="vegetables"}
        //};
        public IActionResult Index()
        {
            var categories = categoryService.GetAllCategory();
            return View(new CategoryIndexViewModel
            {
                Categories = this.categoryService.GetAllCategory()
            }) ;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel category)
        {
            this.categoryService.CreateNewCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id is null || categoryService.GetCategoryById((int)id)is null)
            {
                return BadRequest("Category was not found");
            }
            categoryService.RemoveCategoryById((int)id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id is null || categoryService.GetCategoryById((int)id) is null)
            {
                return BadRequest("Category was not found");
            }
            return View(categoryService.GetCategoryById((int)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel category)
        {
            if(categoryService.GetCategoryById((int)category.Id) is null)
            {
                return BadRequest("Category was not found");
            }
            categoryService.UpdateCategory(category);
            // return View(categoryService.GetCategoryById(category.Id));
            return RedirectToAction("Index");
        }

        public IActionResult ViewProducts(int? id)
        {
            if (id is null || categoryService.GetCategoryById((int)id) is null)
            {
                return BadRequest("Category was not found");
            }
        
            return View(new ProductIndexViewModel
            {
                Products = productsService.GetAllProducts().Where(p => p.CategoryId == id).ToList()
            }) ;
        }
    }
}
