using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dominospizza.ViewModels.AccountViewModel
{
    public class ResetPasswordVM
    {
        public string Id { get; set; }
        public string Token { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPasswod { get; set; }
    }
}
