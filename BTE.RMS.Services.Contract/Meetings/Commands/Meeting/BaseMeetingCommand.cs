﻿using System;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class BaseMeetingCommand : SyncCommand
    {
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string LocationAddress { get; set; }
        public string LocationLatitude { get; set; }
        public string LocationLongitude { get; set; }
        public string Attendees { get; set; }
        public String Agenda { get; set; }
        public CreateReminderCommand Reminder { get; set; }

     }
}
