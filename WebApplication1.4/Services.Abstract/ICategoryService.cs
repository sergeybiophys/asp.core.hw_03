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
        CategoryDto UpdateCategory(CategoryDto category);
        CategoryDto CreateNewCategory(CategoryDto category);
        void RemoveCategoryById(int id);
    }
}
