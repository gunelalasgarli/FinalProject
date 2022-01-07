using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class Drinks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        [NotMapped]
        public string DrinkImage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
