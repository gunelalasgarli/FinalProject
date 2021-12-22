using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizesId { get; set; }
        public Product Product { get; set; }
        public Sizes Sizes { get; set; }
    }
}
