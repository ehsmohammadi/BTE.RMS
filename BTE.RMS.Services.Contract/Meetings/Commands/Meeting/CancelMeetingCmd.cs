using System;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class CancelMeetingCmd:SyncCommand
    {
        public long MeetingId { get; private set; }
        public CancelMeetingCmd(long meetingId, Guid syncId, string actionOwnerUserName)
        {
            SyncId = syncId;
            MeetingId = meetingId;
            ActionOwnerUserName = actionOwnerUserName;
        }
     }
}
