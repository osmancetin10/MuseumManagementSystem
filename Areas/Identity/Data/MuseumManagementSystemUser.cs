using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MuseumManagementSystem.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MuseumManagementSystemUser class
    public class MuseumManagementSystemUser : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Rol { get; set; }
    }
}
