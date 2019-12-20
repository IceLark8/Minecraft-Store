using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Entities;
using DAL.Repositories.InterFaces;

namespace DAL.Repositories.Impl
{
    class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
