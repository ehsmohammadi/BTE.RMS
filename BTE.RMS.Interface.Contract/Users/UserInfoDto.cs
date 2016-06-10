using System;

namespace BTE.RMS.Interface.Contract.Model.Users
{
    public class UserInfoDto
    {
        public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        //todo: add role & other Att
    }
}
