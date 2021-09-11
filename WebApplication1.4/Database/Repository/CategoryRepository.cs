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
    public class CategoryRepository: BaseRepository<int,Category>
    {
        public CategoryRepository(ApplicationDbContext ctx):base(ctx)
        {

        }

        public override Category Get(int id)
           => Table.FirstOrDefault(c => c.Id == id);

        public override void Remove(int id)
        {
            var category = Get(id);
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public override void Update(Category entity)
        {
            var category = Get(entity.Id);

            category.Name = entity.Name;
            category.Products = entity.Products;
            

            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }


    }
}
