using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Model.Team
{
    public class UserInfoModel
    {
        public long Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        //todo: add role & other Att
    }
}
