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
    public class CategoryService : ICategoryService
    {
        readonly IUnitOfWork uow;
        readonly IMapper mapper;
        public CategoryService(IUnitOfWork uow,
                               IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }


        public CategoryDto CreateNewCategory(CategoryDto category)
        {
            var tmp = new Category
            {
                Name = category.Name,
                Products = new List<Product>()
            };
            //this.uow.CategoriesRepository.Create(new Category
            //{
            //    Name = category.Name,
            //    Products = new List<Product>()
            //}) ;
            this.uow.CategoriesRepository.Create(tmp);
            this.uow.SaveChanges();

            return mapper.Map<CategoryDto>(tmp);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = this.uow.CategoriesRepository.GetAll();

            return categories.Select((c) => new CategoryDto
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                Name = c.Name,
                Products = mapper.Map<ICollection<ProductDto>>(c.Products)
            }).ToList() ;
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = this.uow.CategoriesRepository.Get(id);
            return new CategoryDto
            {
                Id = category.Id,
                CreatedAt = category.CreatedAt,
                Name = category.Name,
                Products = mapper.Map<ICollection<ProductDto>>(category.Products)
            };
        }

        public void RemoveCategoryById(int id)
        {
            this.uow.CategoriesRepository.Remove(id);
            this.uow.SaveChanges();
        }

        public CategoryDto UpdateCategory(CategoryDto category)
        {
            var tmp = new Category
            {
                Id = category.Id,
                CreatedAt = category.CreatedAt,
                Name = category.Name,
                //Products = (ICollection<Product>)category.Products
                Products = mapper.Map<ICollection<Product>>(category.Products)
            };
            //this.uow.CategoriesRepository.Update(new Category
            //{
            //    Id = category.Id,
            //    CreatedAt = category.CreatedAt,
            //    Name = category.Name,
            //    //Products = (ICollection<Product>)category.Products
            //    Products = mapper.Map<ICollection<Product>>(category.Products)
            //});
            this.uow.CategoriesRepository.Update(tmp);
            this.uow.SaveChanges();

            return mapper.Map<CategoryDto>(tmp);
        }
    }
}
