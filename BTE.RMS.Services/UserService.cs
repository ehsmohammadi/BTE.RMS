using BTE.RMS.Model.Users;
using BTE.RMS.Services.Contract;
using BTE.RMS.Services.Contract.Users;

namespace BTE.RMS.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(string userName)
        {
            var user=new User(userName);
            userRepository.Create(user);
        }
    }
}
