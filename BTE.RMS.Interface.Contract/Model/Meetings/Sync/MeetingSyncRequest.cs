using System.Collections.Generic;

namespace BTE.RMS.Interface.Contract.Meetings
{

    public class MeetingSyncRequest : SyncReuest
    {
        public List<MeetingSyncItem> Items { get; set; }
    }
}
