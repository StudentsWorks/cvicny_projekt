using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InzeratnyPortal.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        public string Nazov { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
