using System;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class AddFileToMeetingCmd
    {
        public long MeetingId { get; set; }

        public Guid SyncId { get; set; }

        public string ContentType { get; set; }

        public byte[] FileContent { get; set; }


    }
}
