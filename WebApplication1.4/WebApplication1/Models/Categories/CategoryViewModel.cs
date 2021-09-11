using Domain.Entity;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductDto> Products { get; set; }
    }
}
