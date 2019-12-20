using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.InterFaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICartItemRepository CartItemRepository { get;  }
        ICommentRepository CommentRepository { get; }
        IItemRepository ItemRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        IUserRepository UserRepository { get; }

        Task Save();
    }
}
