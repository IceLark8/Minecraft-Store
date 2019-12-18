using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities;

namespace DB.Repositories.InterFaces
{
    public interface ICommentRepository : IBaseRepository<Comment, int>
    {
    }
}
