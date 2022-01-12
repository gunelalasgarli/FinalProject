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
        public decimal Total { get; set; }
        public double TotalAmount { get; set; } = 1;
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OrderDescription { get; set; }
        public string Size { get; set; }
    }
}
