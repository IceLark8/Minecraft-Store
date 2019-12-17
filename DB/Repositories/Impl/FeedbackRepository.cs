using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities;
using DB.Repositories.InterFaces;

namespace DB.Repositories.Impl
{
    class FeedbackRepository : BaseRepository<Feedback, int>, IFeedbackRepository
    {
        public FeedbackRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
