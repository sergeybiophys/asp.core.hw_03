using Services.Abstract.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int id);
        void UpdateCategory(CategoryDto category);
        void CreateNewCategory(CategoryDto category);
        void RemoveCategoryById(int id);
    }
}
