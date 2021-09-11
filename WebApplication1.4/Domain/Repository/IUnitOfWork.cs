using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Guid, Person> PeopleRepository { get; }

        IRepository<int, Product> ProductsRepository { get; }

        IRepository<int, Category> CategoriesRepository { get; }

        void SaveChanges();
    }
}
