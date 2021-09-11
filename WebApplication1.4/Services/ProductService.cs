using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        readonly IUnitOfWork uow;
        readonly IMapper mapper;

        public ProductService(IUnitOfWork uow,
                              IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public void CreateNewProduct(ProductDto product, CategoryDto category)
        {
            //TODO refactoring 

            var tmpCategory = new Category
            {
                Id = category.Id,
                Name = category.Name,
                Products = mapper.Map<ICollection<Product>>(category.Products)
            };


            var tmpProduct = new Product
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Category = tmpCategory,
                CategoryId = product.CategoryId,
                Image = product.Image
            };

            this.uow.ProductsRepository.Create(tmpProduct);

            this.uow.CategoriesRepository.Update(tmpCategory);

            this.uow.SaveChanges();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = this.uow.ProductsRepository.GetAll();
            return products.Select((p) => new ProductDto
            {
                Id = p.Id,
                CreatedAt = p.CreatedAt,
                Name = p.Name,
                Quantity = p.Quantity,
                Price = p.Price,
                Category = mapper.Map<CategoryDto>(p.Category),
                CategoryId = p.CategoryId,
                Image = p.Image
            }).ToList();
        }

        public ProductDto GetProductById(int id)
        {
            var product = this.uow.ProductsRepository.Get(id);
            return new ProductDto
            {
                Id = product.Id,
                CreatedAt = product.CreatedAt,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Category = mapper.Map<CategoryDto>(product.Category),
                CategoryId = product.CategoryId,
                Image = product.Image
            };
        }

        public void RemoveProductById(int id)
        {
            this.uow.ProductsRepository.Remove(id);
            this.uow.SaveChanges();
        }

        public void UpdateProduct(ProductDto product)
        {
            this.uow.ProductsRepository.Update(new Product
            {
                Id = product.Id,
                CreatedAt = product.CreatedAt,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Category = mapper.Map<Category>(product.Category),
                CategoryId = product.CategoryId,
                Image = product.Image
            });
            uow.SaveChanges();
        }
    }
}
