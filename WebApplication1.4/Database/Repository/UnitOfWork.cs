using Database.Repository;
using Domain.Entity;
using Domain.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext db;

        IRepository<Guid, Person> _peopleRepository;
        IRepository<Guid, Person> IUnitOfWork.PeopleRepository 
            => _peopleRepository ?? (_peopleRepository = new PeopleRepository(db));

        IRepository<int, Product> _productRepository;
        IRepository<int, Product> IUnitOfWork.ProductsRepository
           => _productRepository ?? (_productRepository = new ProductRepository(db));

        IRepository<int, Category> _categoryRepository;
        IRepository<int, Category> IUnitOfWork.CategoriesRepository
           => _categoryRepository ?? (_categoryRepository = new CategoryRepository(db));

        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }

        public void SaveChanges() => db.SaveChanges();

        //public void SaveChanges()
        //{
        //  // try
        //   //{
        //       db.SaveChanges();
        //  // }
        //  // catch(SqlException ex)
        //  // {
        //   //    Console.WriteLine(ex.Message);
        //  // }
        //}
    }
}
