using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Users;
using BTE.RMS.Services.Contract;

namespace BTE.RMS.Interface
{
    public class UserFacadeService : IUserFacadeService
    {
        private readonly IUserService userService;

        #region Fields

        #endregion

        #region Constructors
        public UserFacadeService(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region Methods
        public void Create(RegistrationDto userModel)
        {
            userService.CreateUser(userModel.UserName);
        }

        #endregion


    }
}
