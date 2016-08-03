using System;
using BTE.RMS.Common;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class RevertMeetingCmd:SyncCommand
    {
        public long MeetingId { get; private set; }
        public RevertMeetingCmd(long meetingId, Guid syncId, string actionOwnerUserName, AppType appType)
        {
            SyncId = syncId;
            MeetingId = meetingId;
            ActionOwnerUserName = actionOwnerUserName;
            AppType = appType;
        }
     }
}
