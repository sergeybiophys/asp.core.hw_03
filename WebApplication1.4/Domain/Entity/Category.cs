using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Category:BaseEntity<int>
    {
        public string Name { get; set; }

        //[ForeignKey("Id")]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
