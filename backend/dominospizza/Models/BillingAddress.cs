using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class BillingAddress
    {
        public int Id { get; set; }
        public string OrderDescription { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

        public bool IsDeleted { get; set; }
        public string AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<FullOrder> FullOrders { get; set; }
    }
}
