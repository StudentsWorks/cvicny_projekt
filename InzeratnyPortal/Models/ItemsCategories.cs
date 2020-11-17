using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InzeratnyPortal.Models
{
    public class ItemsCategories
    {
        public IQueryable<Item> Items { get; set; }
        public IQueryable<Category> Categories { get; set; }
    }
}
