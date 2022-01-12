using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int No { get; set; }

        public string Image { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }

        public decimal Total { get; set; }
        public int FullOrderId { get; set; }
        public FullOrder FullOrder { get; set; }
        public Product Product { get; set; }

    }
}
