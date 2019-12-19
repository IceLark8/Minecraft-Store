using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Entities;
using DAL.Repositories.InterFaces;

namespace DAL.Repositories.Impl
{
    public class CartItemRepository : BaseRepository<CartItem, int>, ICartItemRepository
    {
        public CartItemRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}