using System;
using System.Collections.Generic;
using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings.MeetingStates;
using BTE.RMS.Model.Meetings.MeetingStates.States;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public class Meeting
    {
        
        #region Properties
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public List<Attendee> Attendees { get; set; }
        public List<Reminder> Reminder { get; set; }
        public String Agenda { get; set; }
        public DateTime NextMeeting { get; set; }
        public int Progress { get; set; }
        public int Priority { get; set; }
        public MeetingState MeetingState { get; set; }
        public List<User> MeetingOwners { get; set; }
        public User CreatorUser { get; set; }
        public bool HaveApprovalAccess { get; set; }
        //public List<Files> AttachmentFiles {get; set;}
     
        #endregion

        #region Constructors

        protected Meeting()
        {
            
        }

        protected Meeting(string subject, 
                            DateTime startDate, 
                            int duration, 
                            string description, 
                            Location location)
        {
            setProperties(subject, startDate, duration, description,
                        location);
        }
       
        #endregion

        #region Private Methods
        private void setProperties(string subject,
                                    DateTime startDate, 
                                    int duration, 
                                    string description, 
                                    Location location)
        {
            Subject = subject;
            StartDate = startDate;
            Duration = duration;
            Description = description;
            Location = location;
            MeetingState = new MeetingNewState();
        }
        #endregion

        public void Approve()
        {
            MeetingState.Approve(this);
        }

        public void setAgenda(String agenda)
        {
            Agenda = agenda;
        }

        public void setReminders(List<Reminder> reminders)
        {
            Reminder = reminders;
        }

        public void setAttendees(List<Attendee> attendees)
        {
            Attendees = attendees;
        }

        public void setNexMeeting(DateTime nextMeeting)
        {
            NextMeeting = nextMeeting;
        }

        public void setProgress(int progress)
        {
            Progress = progress;
        }

        public void setPriority(int priority)
        {
            Priority = priority;
        }

        public void setMeetingOwners(List<User> meetingOwners)
        {
            MeetingOwners = meetingOwners;
        }

        public void setCreatorUser(User creatorUser)
        {
            CreatorUser = creatorUser;
        }

        public void setHaveApprovalAccess(bool haveApprovalAccess)
        {
            HaveApprovalAccess = haveApprovalAccess;
        }
    }
}
