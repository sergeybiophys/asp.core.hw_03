using AutoMapper;
using Domain.Repository;
using DotLiquid.Tags;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPeopleService> _peopleService;

        private readonly Lazy<ICategoryService> _categoryService;

        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _peopleService = new Lazy<IPeopleService>(() => new PeopleService(unitOfWork, mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(unitOfWork, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
        }

        

        public IPeopleService PeopleService => _peopleService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IProductService ProductService => _productService.Value;

    }
}
