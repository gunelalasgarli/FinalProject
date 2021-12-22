using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class Ingridients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool isChecked { get; set; }
        public List<ProductIngridients> ProductIngridients { get; set; }

    }
}
