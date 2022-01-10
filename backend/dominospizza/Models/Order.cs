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
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        [StringLength(maximumLength: 250)]
        public string Address { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Phone { get; set; }
        public string OrderDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
