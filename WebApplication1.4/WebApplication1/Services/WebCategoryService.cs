using Services;
using Services.Abstract;
using Services.Abstract.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Categories;

namespace WebApplication1.Services
{
    public class WebCategoryService : IWebCategoryService
    {
        readonly IServiceManager serviceManager;

        public WebCategoryService(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        public void CreateNewCategory(CategoryViewModel category)
        {
            serviceManager.CategoryService.CreateNewCategory(new CategoryDto
            {
                Name = category.Name
            });
        }

        public List<CategoryViewModel> GetAllCategory()
        {
            var categories = serviceManager.CategoryService.GetAllCategories();
            return categories.Select((c) => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Products = c.Products

            }).ToList();
        }

        public CategoryViewModel GetCategoryById(int id)
        {
            var category = serviceManager.CategoryService.GetCategoryById(id);
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products
            };
        }

        public void RemoveCategoryById(int id)
        {
            serviceManager.CategoryService.RemoveCategoryById(id);
        }

        public void UpdateCategory(CategoryViewModel category)
        {
            serviceManager.CategoryService.UpdateCategory(new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products
            });
        }
    }
}
