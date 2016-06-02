using System;
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
        private readonly IUserRepository userRepository;

        #endregion

        #region Constructors
        public MeetingService(IMeetingRepository meetingRepository,IAttendeeRepository attendeeRepository,IUserRepository userRepository)
        {
            this.meetingRepository = meetingRepository;
            this.attendeeRepository = attendeeRepository;
            this.userRepository = userRepository;
        }

        #endregion

        #region Public methods
        public void CreateWorkingMeeting(CreateWorkingMeetingCmd command)
        {
            var creator = userRepository.GetBy(command.CreatorUserName);
            var location = new Location(command.Address, command.Latitude, command.Longitude);
            var meeting = new WorkingMeeting(command.Subject,command.StartDate,command.Duration,command.Description,
                location,
                command.AttendeesName,
                command.Agenda,
                command.SyncId, command.AppType, creator);

            meetingRepository.Create(meeting);
        }

        public void CreateNonWorkingMeeting(CreateNonWorkingMeetingCmd command)
        {
            var creator = userRepository.GetBy(command.CreatorUserName);
            var location = new Location(command.Address, command.Latitude, command.Longitude);

            var meeting = new NoneWorkingMeeting(command.Subject, command.StartDate, command.Duration,
                command.Description, location, command.AttendeesName, command.Agenda, command.SyncId, command.AppType,
                creator);

            meetingRepository.Create(meeting);
        }


        public void ModifyWorkingMeeting(ModifyWorkingMeetingCmd command)
        {
            var meeting = (WorkingMeeting)GetBy(command.Id,command.SyncId);
            var location = new Location(command.Address, command.Latitude, command.Longitude);
            meeting.Update(command.Subject, command.StartDate, command.Duration, command.Description, location,
                command.AttendeesName, command.Agenda, command.AppType);

            meetingRepository.Update(meeting);
        }

        public void ModifyNonWorkingMeeting(ModifyNonWorkingMeetingCmd command)
        {
            var meeting = (NoneWorkingMeeting)GetBy(command.Id,command.SyncId);
            var location = new Location(command.Address, command.Latitude, command.Longitude);
            meeting.Update(command.Subject, command.StartDate, command.Duration, command.Description, location,
                command.AttendeesName, command.Agenda, command.AppType);

            meetingRepository.Update(meeting);
        }

        public void Delete(DeleteMeetingCmd command)
        {
            var meeting = GetBy(command.Id, command.SyncId);
            meeting.Delete(command.AppType);
            meetingRepository.Update(meeting);
        }

        public Meeting GetBy(long id, Guid syncId)
        {
            if (syncId == null || syncId == Guid.Empty || syncId == default(Guid))
            {
                return meetingRepository.GetBy(id);
            }
            return meetingRepository.GetBy(syncId);
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

       
    }



}
