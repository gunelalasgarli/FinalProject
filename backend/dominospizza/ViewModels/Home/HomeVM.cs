using dominospizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.ViewModels.Home
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public Settings Settings { get; set; }
        public HomePage HomePages { get; set; }
        public List<Contact> Contacts { get; set; }
      

    }
}
