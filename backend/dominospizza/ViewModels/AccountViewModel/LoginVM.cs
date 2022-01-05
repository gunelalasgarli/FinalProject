using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dominospizza.ViewModels.AccountViewModel
{
    public class LoginVM
    {
        [Required,EmailAddress,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemindMe { get; set; }
    }
}
