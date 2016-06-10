using BTE.Core;
using BTE.RMS.Interface.Contract.Model.Users;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface IUserFacadeService :IFacadeService
    {
        void Create(RegistrationDto userModel);
    }
}
