using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class Sizes
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public IFormFile SizeImage { get; set; }
        public List<DrinkSize> DrinkSizes { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}
