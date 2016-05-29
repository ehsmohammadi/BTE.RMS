﻿using System;
using System.Collections.Generic;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Model.Users;

namespace BTE.RMS.Interface.Contract.Model.Meetings
{
    public class MeetingDto
    {
        public MeetingType MeetingType { get; set; }
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        #region Location
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        #endregion        
        public List<long> Attendees { get; set; }
        public string AttendeesList { get; set; }
        public string Description { get; set; }
        public List<ReminderDto> Reminder { get; set; }
        public String Agenda { get; set; }
        public DateTime NextMeeting { get; set; }
        public int Progress { get; set; }
        public int Priority { get; set; }
        public int StateId { get; set; }
        public List<UserInfoDto> MeetingOwner { get; set; }
        public bool HaveApprovalAccess { get; set; }
        
        //todo add Meeting Stat , owner , attach file and other attribute
//        public bool Stat;
//        public bool ApprovalState;
//        public MeetingStat MessStat;
//        public MeetingOwnerModel MeetingOwner { get; set; }
//        public List<Files> AttachmentFiles { get; set; } 
    }
}