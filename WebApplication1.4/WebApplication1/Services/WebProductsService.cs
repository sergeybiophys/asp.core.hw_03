using Services;
using Services.Abstract;
using Services.Abstract.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Categories;
using WebApplication1.Models.Products;

namespace WebApplication1.Services
{
    public class WebProductsService : IWebProductsService
    {

        readonly IServiceManager serviceManager;

        public WebProductsService(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        public void CreateNewProduct(ProductViewModel product, CategoryViewModel category)
        {
            serviceManager.ProductService.CreateNewProduct(new ProductDto
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Category = product.Category,
                CategoryId = product.CategoryId,
                Image = product.Image

            }, new CategoryDto
            {
                Id = category.Id,
                Name =category.Name,
                Products = category.Products
            });
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = serviceManager.ProductService.GetAllProducts();
            return products.Select((p) => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity,
                Price = p.Price,
                Image = p.Image,
                CategoryId = p.CategoryId

            }).ToList();
        }

        public ProductViewModel GetProductById(int id)
        {
            var product = serviceManager.ProductService.GetProductById(id);
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Category = product.Category,
                CategoryId = product.CategoryId,
                Image = product.Image
            };
        }

        public void RemoveProductById(int id)
        {
            serviceManager.ProductService.RemoveProductById(id);
        }

        public void UpdateProduct(ProductViewModel product)
        {
            serviceManager.ProductService.UpdateProduct(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Category = product.Category,
                CategoryId = product.CategoryId,
                Image = product.Image
            });
        }
    }
}
