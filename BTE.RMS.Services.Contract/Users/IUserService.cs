using BTE.Core;

namespace BTE.RMS.Services.Contract.Users
{
    public interface IUserService : IService
    {
        void CreateUser(string userName);
    }
}
