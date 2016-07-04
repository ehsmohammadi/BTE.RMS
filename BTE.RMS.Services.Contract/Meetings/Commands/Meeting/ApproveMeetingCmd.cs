using System;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class ApproveMeetingCmd:SyncCommand
    {
        public long MeetingId { get; private set; }
        public ApproveMeetingCmd(long meetingId, string actionOwnerUserName)
        {
            MeetingId = meetingId;
            ActionOwnerUserName = actionOwnerUserName;
        }
     }
}
