using System.Collections.Generic;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class ModifyWorkingMeetingCmd : BaseMeetingCommand
    {
        public long Id { get; set; }

        public string Details { get; set; }

        public string Decisions { get; set; }

        public List<CreateFileCmd> Files { get; set; } 
    }
}
