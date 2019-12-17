using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities;
using DB.Repositories.InterFaces;

namespace DB.Repositories.Impl
{
    class ItemRepository : BaseRepository<Item, int>, IItemRepository
    {
        public ItemRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
