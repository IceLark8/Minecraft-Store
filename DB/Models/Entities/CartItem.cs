using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities.Abstarction;

namespace DB.Models.Entities
{
    public class CartItem : DbItem
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }
}
