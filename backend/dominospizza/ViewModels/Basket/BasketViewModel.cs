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
        public string Phone { get; set; } = "5";
        public int Count { get; set; }
        public decimal Total { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
