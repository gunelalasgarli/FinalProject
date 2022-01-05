using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FatherName { get; set; }
        public byte Age { get; set; }
        public bool IsDeleted { get; set; }

    }
}
