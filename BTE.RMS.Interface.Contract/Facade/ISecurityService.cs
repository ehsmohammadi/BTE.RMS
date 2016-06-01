using BTE.Core;
using BTE.RMS.Interface.Contract.Model.Users;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface ISecurityService : IFacadeService
    {
        string GetCurrentUserName();
    }
}
