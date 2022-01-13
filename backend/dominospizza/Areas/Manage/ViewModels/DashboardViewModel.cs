using dominospizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Areas.Manage.ViewModels
{
    public class DashboardViewModel
    {
        public List<FullOrder> FullOrders { get; set; }
        public List<Order> Orders { get; set; }
        public List<Message> Messages { get; set; }

    }
}
