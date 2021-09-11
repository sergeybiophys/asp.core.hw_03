
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Abstract.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
       
        public int CategoryId { get; set; }
        public virtual CategoryDto Category { get; set; }
        public string Image { get; set; }
    }
}
