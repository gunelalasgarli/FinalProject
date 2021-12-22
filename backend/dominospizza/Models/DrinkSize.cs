using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class DrinkSize
    {
        public int Id { get; set; }
        public int DrinksId { get; set; }
        public int SizesId { get; set; }
        public Drinks Drinks { get; set; }
        public Sizes Sizes { get; set; }
    }
}
