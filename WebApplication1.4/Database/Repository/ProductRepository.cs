using Domain.Entity;
using Infrastructure.Database;
using Infrastructure.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class ProductRepository : BaseRepository<int, Product>
    {
        public ProductRepository(ApplicationDbContext ctx)
          : base(ctx)
        {

        }
        public override Product Get(int id)
             => Table.FirstOrDefault(p => p.Id == id);

        public override void Remove(int id)
        {
            var product = Get(id);
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public override void Update(Product entity)
        {
            var product = Get(entity.Id);
            product.Name = entity.Name;
            product.Quantity = entity.Quantity;
            product.Price = entity.Price;
            product.Category = entity.Category;
            product.CategoryId = entity.CategoryId;
            product.Image = entity.Image;

            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

    }
}
