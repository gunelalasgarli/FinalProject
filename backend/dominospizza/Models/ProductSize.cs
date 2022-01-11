using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class ProductSize
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string buttonid { get; set; }
        public List<Product> Products { get; set; }
        //public int ProductId { get; set; }

        //public int SizesId { get; set; }
        //public Product Product { get; set; }
        //public Sizes Sizes { get; set; }
        public IEnumerable<BasketItem> BasketItems { get; set; }
    }
}
