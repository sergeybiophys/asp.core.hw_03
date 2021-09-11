using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Categories;

namespace WebApplication1.Services
{
    public interface IWebCategoryService
    {
        List<CategoryViewModel> GetAllCategory();
        CategoryViewModel GetCategoryById(int id);
        void UpdateCategory(CategoryViewModel category);
        void CreateNewCategory(CategoryViewModel category);
        void RemoveCategoryById(int id);
    }
}
