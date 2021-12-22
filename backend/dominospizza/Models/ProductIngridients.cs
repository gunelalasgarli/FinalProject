using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class ProductIngridients
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int IngridientsId { get; set; }
        public Product Product { get; set; }
        public Ingridients Ingridients { get; set; }

    }
}
