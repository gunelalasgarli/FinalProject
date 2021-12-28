﻿using dominospizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<HomePage> HomePages { get; set; }
        public virtual DbSet<Drinks> Drinks { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<DrinkSize> DrinkSizes { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

    }
}
