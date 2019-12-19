using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Entities;
using DAL.Repositories.InterFaces;

namespace DAL.Repositories.Impl
{
    class ItemRepository : BaseRepository<Item, int>, IItemRepository
    {
        public ItemRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
