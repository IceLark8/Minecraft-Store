using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities;
using DB.Repositories.InterFaces;

namespace DB.Repositories.Impl
{
    public class CartItemRepository : BaseRepository<CartItem, int>, ICartItemRepository
    {
        public CartItemRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}