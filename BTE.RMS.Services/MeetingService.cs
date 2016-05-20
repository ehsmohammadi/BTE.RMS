using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.Meetings.MeetingStates;
using BTE.RMS.Model.Users;
using BTE.RMS.Services.Contract.Meetings;

namespace BTE.RMS.Services
{
    public class MeetingService : IMeetingService
    {
        #region Fields
        private readonly IMeetingRepository meetingRepository;
        private readonly IAttendeeRepository attendeeRepository;

        #endregion

        #region Constructors
        public MeetingService(IMeetingRepository meetingRepository,IAttendeeRepository attendeeRepository)
        {
            this.meetingRepository = meetingRepository;
            this.attendeeRepository = attendeeRepository;
        }

        #endregion

        #region Public methods
        public void CreateWorkingMeeting(CreateWorkingMeetingCmd command)
        {
            var attendees = attendeeRepository.FindAttendeesById(command.Attendees);
            //todo: location must be created inside bse meeting  class
            var location = new Location(command.Address, command.Latitude, command.Longitude);
            //var reminders = createReminderList(command.Reminder);
            //var meetingOwners = createMeetingOwnerList(command.MeetingOwner);
            var creatorUser = new User();
            var meeting = new WorkingMeeting(command.Subject, 
                                            command.StartDate, 
                                            command.Duration, 
                                            command.Description,
                                            location);
            //todo: set other param
            meetingRepository.Create(meeting);
        }

        public void CreateNonWorkingMeeting(CreateNonWorkingMeetingCmd command)
        {
            var attendees = attendeeRepository.FindAttendeesById(command.Attendees);
            //todo: location must be created inside bse meeting class
            var location = new Location(command.Address, command.Latitude, command.Longitude);
            //var reminders = createReminderList(command.Reminder);
            //var meetingState = new MeetingState(command.StateId);
            //var meetingOwners = createMeetingOwnerList(command.MeetingOwner);
            //var creatorUser = new User()
            var meeting = new NoneWorkingMeeting(command.Subject, 
                                                 command.StartDate, 
                                                 command.Duration, 
                                                 command.Description,
                                                 location);
            meeting.setAgenda(command.Agenda);
            meeting.setAttendees(attendees);
            meeting.setNexMeeting(command.NextMeeting);
            meeting.setReminders(command.Reminder.Select(r=>new Reminder(r.RepeatingType,r.RemindTypes,r.RemindeTime,r.SeveralTimes)).ToList());
//            meeting.CreatorUser(command.user)
//            meeting.MeetingOwners()
            meeting.setProgress(command.Progress);
            meeting.setPriority(command.Priority);
            meeting.setHaveApprovalAccess(command.HaveApprovalAccess);
            meetingRepository.Create(meeting);
        } 
        #endregion

        //private List<User> createMeetingOwnerList(List<UserInfoModel> meetingOwner)
        //{
        //    throw new NotImplementedException();
        //}

        //private List<Reminders> createReminderList(List<ReminderModel> reminder)
        //{
        //    throw new NotImplementedException();
        //}

       
    }



}
