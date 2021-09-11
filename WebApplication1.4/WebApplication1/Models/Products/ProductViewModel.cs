using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace WebApplication1.Models.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public CategoryDto Category { get; set; }

        public int CategoryId { get; set; }
        public string Image { get; set; }

    }
}
