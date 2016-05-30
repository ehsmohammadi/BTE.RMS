using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Persistence
{
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly RMSContext ctx;
        #endregion

        #region Constructors
        public UserRepository(RMSContext rmsContext)
        {
            this.ctx = rmsContext;
        }
        #endregion

        #region Public Methods

        public IList<User> GetAll()
        {
            return
                ctx.Users.AsNoTracking()
                    .ToList();
        }

        public User GetBy(long id)
        {
            return ctx.Users.Single(t => t.Id == id);
        }

        public void Create(User user)
        {
            ctx.Users.Add(user);
            ctx.SaveChanges();
        }

        public void Update(User user)
        {
            ctx.SaveChanges();
        }

        public void Delete(User user)
        {
            ctx.Users.Remove(user);
            ctx.SaveChanges();
        }

        public User GetBy(string creatorUserName)
        {
            return ctx.Users.Single(t => t.UserName == creatorUserName);
        }

        #endregion

        #region Query Base Methods

        public List<User> FindUsersById(List<long> idList)
        {
            return idList==null ? new List<User>() : ctx.Users.Where(a => idList.Contains(a.Id)).ToList();
        }

        #endregion

    }
}
