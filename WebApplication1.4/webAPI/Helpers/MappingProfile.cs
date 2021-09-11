using AutoMapper;
using Domain.Entity;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models.Category;
using webAPI.Models.People;
using webAPI.Models.Product;

namespace WebApplication1.Helpers
{
    internal sealed class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();


            CreateMap<CreatePersonModel, PersonDto>();
            CreateMap<PersonDto, CreatePersonModel>();
            CreateMap<UpdatePersonModel, PersonDto>();
            CreateMap<PersonDto, UpdatePersonModel>();

            CreateMap<CreateCategoryModel, CategoryDto>();
            CreateMap<CategoryDto, CreateCategoryModel>();
            CreateMap<UpdateCategoryModel, CategoryDto>();
            CreateMap<CategoryDto, UpdateCategoryModel>();

            CreateMap<CreateProductModel, ProductDto>();
            CreateMap<ProductDto, CreateProductModel>();
            CreateMap<UpdateProductModel, ProductDto>();
            CreateMap<ProductDto, UpdateProductModel>();
        }
    }
}
