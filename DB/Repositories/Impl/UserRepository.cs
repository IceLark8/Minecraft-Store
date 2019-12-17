using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities;
using DB.Repositories.InterFaces;

namespace DB.Repositories.Impl
{
    class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
