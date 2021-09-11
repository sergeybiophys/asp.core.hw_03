using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Categories;
using WebApplication1.Models.Products;

namespace WebApplication1.Services
{
    public  interface IWebProductsService
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
        void UpdateProduct(ProductViewModel product);
        void CreateNewProduct(ProductViewModel product, CategoryViewModel category);
        void RemoveProductById(int id);
    }
}
