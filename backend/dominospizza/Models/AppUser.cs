using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool isDelete { get; set; }
        public bool isActive { get; set; }

    }
}
