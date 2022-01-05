using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Helpers
{
    public class Helper
    {
        public static bool DeleteImage(string root, string folder, string fileName)
        {
            string path = Path.Combine(root, folder, fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }

        public enum Roles
        {
            Admin,
            Member
        }
       
    }
}
