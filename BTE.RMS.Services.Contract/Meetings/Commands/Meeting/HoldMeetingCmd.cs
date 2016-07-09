using System;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class HoldMeetingCmd:SyncCommand
    {
        public long MeetingId { get; private set; }
        public HoldMeetingCmd(long meetingId, Guid syncId, string actionOwnerUserName)
        {
            SyncId = syncId;
            MeetingId = meetingId;
            ActionOwnerUserName = actionOwnerUserName;
        }
     }
}
