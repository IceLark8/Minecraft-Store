using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Entities.Abstarction;

namespace DAL.Models.Entities
{
    public class CartItem : DbItem<int>
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }
}
