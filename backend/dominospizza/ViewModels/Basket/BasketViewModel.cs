using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.ViewModels.Basket
{
    public class BasketViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
