using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Product: BaseEntity<int>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
       
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = new Category();
        public string Image { get; set; }
    }
}
