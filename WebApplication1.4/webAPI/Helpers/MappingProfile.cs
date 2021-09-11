using AutoMapper;
using Domain.Entity;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models.People;

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
        }
    }
}
