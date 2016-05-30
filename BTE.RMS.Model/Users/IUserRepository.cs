using System.Collections.Generic;
using BTE.Core;

namespace BTE.RMS.Model.Users
{
    public interface IUserRepository : IRepository<User>, IRepository
    {
        User GetBy(string creatorUserName);
    }
}
