using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InzeratnyPortal.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Required]

        [Display(Name = "Názov")]
        public string Nazov { get; set; }
        public string Popis { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Cena { get; set; }

        [Display(Name = "Obrázok")]
        public string Obrazok { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Kategória")]
        public int CategoryID { get; set; } 
        public Category Category { get; set; }

        [ForeignKey("AppUser")]
        [Display(Name = "ID Užívateľa")]
        public string UserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
