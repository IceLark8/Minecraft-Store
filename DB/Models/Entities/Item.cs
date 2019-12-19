using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Entities.Abstarction;

namespace DAL.Models.Entities
{
    public enum Category
    {
        Static = 0,
        Dynamic,
        Flat
    }

    public class Item : DbItem<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
    }
}
