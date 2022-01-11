﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int Count { get; set; }
        public AppUser AppUser { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Nullable<int> ProductSizeId { get; set; }
        public ProductSize ProductSize { get; set; }
    }
}
