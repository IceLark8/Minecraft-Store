using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities;
using DB.Repositories.InterFaces;

namespace DB.Repositories.Impl
{
    class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
