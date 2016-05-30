using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class ModifyWorkingMeetingCmd : BaseMeetingCommand
    {
        public long Id { get; set; }
    }
}
