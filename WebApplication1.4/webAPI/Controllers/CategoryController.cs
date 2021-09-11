using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models.Category;
using webAPI.Models.People;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IServiceManager serviceManager;
        IMapper mapper;

        public CategoryController(IServiceManager serviceManager,
                                IMapper mapper)
        {

            this.mapper = mapper;
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> GetAllPeople()
        {
            return serviceManager.CategoryService.GetAllCategories();
        }

        [HttpPost]
        public CategoryDto Create(CreateCategoryModel model)
        {
            var tmp = mapper.Map<CategoryDto>(model);

            return serviceManager.CategoryService.CreateNewCategory(tmp);

        }

        [HttpPut]

        public CategoryDto Update(UpdateCategoryModel model)
        {
            var tmp = mapper.Map<CategoryDto>(model);

            return serviceManager.CategoryService.UpdateCategory(tmp);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            serviceManager.CategoryService.RemoveCategoryById(id);
            return new JsonResult("Ok");
        }
    }
}
