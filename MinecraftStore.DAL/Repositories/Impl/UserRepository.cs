using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Entities;
using DAL.Repositories.InterFaces;

namespace DAL.Repositories.Impl
{
    class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
