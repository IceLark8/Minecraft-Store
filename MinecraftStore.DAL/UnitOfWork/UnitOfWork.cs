using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DAL.Repositories.InterFaces;

namespace DAL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;

        private readonly IServiceProvider _serviceProvider;

        private ICartItemRepository _cartItemRepository;

        private ICommentRepository _commentRepository;

        private IItemRepository _itemRepository;

        private IFeedbackRepository _feedbackRepository;

        private IUserRepository _userRepository;


        public UnitOfWork(StoreDbContext context,
            IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public ICartItemRepository CartItemRepository =>
            _cartItemRepository ?? (_cartItemRepository = _serviceProvider.GetService<ICartItemRepository>());
        public ICommentRepository CommentRepository =>
            _commentRepository ?? (_commentRepository = _serviceProvider.GetService<ICommentRepository>());
        public IItemRepository ItemRepository =>
            _itemRepository ?? (_itemRepository = _serviceProvider.GetService<IItemRepository>());
        public IFeedbackRepository FeedbackRepository =>
            _feedbackRepository ?? (_feedbackRepository = _serviceProvider.GetService<IFeedbackRepository>());
        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository = _serviceProvider.GetService<IUserRepository>());

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
