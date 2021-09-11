using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models.Product;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IServiceManager serviceManager;
        IMapper mapper;

        public ProductController(IServiceManager serviceManager,
                                IMapper mapper)
        {

            this.mapper = mapper;
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetAllPeople()
        {
            return serviceManager.ProductService.GetAllProducts();
        }

        [HttpPost]
        public ProductDto Create(CreateProductModel model )
        {
            var tmpProduct = mapper.Map<ProductDto>(model);
            var tmpCategory = serviceManager.CategoryService.GetCategoryById(model.CategoryId);
            return serviceManager.ProductService.CreateNewProduct(tmpProduct, tmpCategory);

        }

        [HttpPut]

        public ProductDto Update(UpdateProductModel model)
        {
            var tmp = mapper.Map<ProductDto>(model);

            return serviceManager.ProductService.UpdateProduct(tmp);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            serviceManager.ProductService.RemoveProductById(id);
            return new JsonResult("Ok");
        }
    }
}
