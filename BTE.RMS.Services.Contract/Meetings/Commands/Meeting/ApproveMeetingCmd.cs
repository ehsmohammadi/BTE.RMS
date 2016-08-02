﻿using System;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class ApproveMeetingCmd:SyncCommand
    {
        public long MeetingId { get; private set; }
        public ApproveMeetingCmd(long meetingId,Guid syncId, string actionOwnerUserName)
        {
            SyncId = syncId;
            MeetingId = meetingId;
            ActionOwnerUserName = actionOwnerUserName;
        }
     }
}