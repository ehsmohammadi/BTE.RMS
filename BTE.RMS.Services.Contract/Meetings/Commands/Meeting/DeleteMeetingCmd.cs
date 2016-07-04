using System;
using BTE.RMS.Common;

namespace BTE.RMS.Services.Contract.Meetings
{

    public class DeleteMeetingCmd : SyncCommand
    {
        public long Id { get; set; }

        public DeleteMeetingCmd(long id, string actionOwnerUserName, AppType appType, Guid syncId)
        {
            Id = id;
            ActionOwnerUserName = actionOwnerUserName;
            AppType = appType;
            SyncId = syncId;
        }

    }
}
