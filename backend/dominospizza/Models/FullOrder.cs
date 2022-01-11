using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class FullOrder
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        
        [StringLength(maximumLength: 250)]
        public string Address { get; set; }
       
        [Required]
        [StringLength(maximumLength: 25)]
        public string Phone { get; set; }
        public string OrderDescription { get; set; }
        public DateTime CreatedAt { get; set; }

        public double TotalAmount { get; set; }
        public AppUser AppUser { get; set; }
        public List<Order> Orders { get; set; }
    }
}
