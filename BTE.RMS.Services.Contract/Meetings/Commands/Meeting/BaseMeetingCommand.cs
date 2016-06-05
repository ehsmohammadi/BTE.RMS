using System;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class BaseMeetingCommand : SyncCommand
    {
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AttendeesName { get; set; }
        public String Agenda { get; set; }
        public CreateReminderCommand Reminder { get; set; }

     }
}
