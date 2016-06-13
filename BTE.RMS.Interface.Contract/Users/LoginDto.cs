using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Model.Users
{
    public class LoginDto
    {
        public string Grant_type { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
