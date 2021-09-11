
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        ProductDto UpdateProduct(ProductDto product);
        ProductDto CreateNewProduct(ProductDto product, CategoryDto category);
        void RemoveProductById(int id);

    }
}
