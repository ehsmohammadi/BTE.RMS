using BTE.Core;

namespace BTE.RMS.Services.Contract
{
    public interface IUserService : IService
    {
        void CreateUser(string userName);
    }
}
