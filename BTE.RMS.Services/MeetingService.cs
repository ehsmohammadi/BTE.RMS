using System.Collections.Generic;
using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings;
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
            //var attendees = attendeeRepository.FindAttendeesById(command.Attendees);
            //todo: location must be created inside bse meeting  class
            var location = new Location(command.Address, command.Latitude, command.Longitude);
            var creator=new User(command.CreatorUserName);
            var meeting = new WorkingMeeting(command.Subject, 
                                            command.StartDate, 
                                            command.Duration, 
                                            command.Description,
                                            location,
                                            command.SyncId, command.AppType, creator);
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
            var creator = new User(command.CreatorUserName);
            var meeting = new NoneWorkingMeeting(command.Subject, 
                                                 command.StartDate, 
                                                 command.Duration, 
                                                 command.Description,
                                                 location,
                                                 command.SyncId, command.AppType, creator);
            meetingRepository.Create(meeting);
        }

        #endregion

        #region Sync Methods
        public void SyncWithAndriodApp(List<Meeting> meetings)
        {
            foreach (var meeting in meetings)
            {
                var unsyncMeeting = meetingRepository.GetBy(meeting.Id);
                unsyncMeeting.SyncWithAndriodApp();
                meetingRepository.Update(unsyncMeeting);
            }
        }

        public void SyncWithDesktopApp(List<Meeting> meetings)
        {
            foreach (var meeting in meetings)
            {
                var unsyncMeeting = meetingRepository.GetBy(meeting.Id);
                unsyncMeeting.SyncWithDesktopApp();
                meetingRepository.Update(unsyncMeeting);
            }
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
