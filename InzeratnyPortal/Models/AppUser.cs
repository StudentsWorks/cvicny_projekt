

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace InzeratnyPortal.Models
{
    public class AppUser : IdentityUser
    {
        public string Tel { get; set; }
        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public string Adresa { get; set; }


        public ICollection<Item> Items { get; set; }
    }
}
