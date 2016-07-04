using System;
using System.Collections.Generic;
using System.Linq;
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
        public MeetingService(IMeetingRepository meetingRepository, IAttendeeRepository attendeeRepository, IUserRepository userRepository)
        {
            this.meetingRepository = meetingRepository;
            this.attendeeRepository = attendeeRepository;
            this.userRepository = userRepository;
        }

        #endregion

        #region Public methods

        public void CreateWorkingMeeting(CreateWorkingMeetingCmd command)
        {
            var creator = userRepository.GetBy(command.ActionOwnerUserName);
            var location = new Location(command.LocationAddress, command.LocationLatitude, command.LocationLongitude);
            var meeting = new WorkingMeeting(command.Subject, command.StartDate, command.Duration, command.Description,
                location,
                command.Attendees,
                command.Agenda,
                command.SyncId, command.AppType, creator);
            if (command.Reminder != null)
                meeting.AddReminder(command.Reminder.ReminderType, command.Reminder.ReminderTimeType,
                    command.Reminder.RepeatingType, command.Reminder.CustomReminderTime);
            meetingRepository.Create(meeting);
        }

        public void CreateNonWorkingMeeting(CreateNonWorkingMeetingCmd command)
        {
            var creator = userRepository.GetBy(command.ActionOwnerUserName);
            var location = new Location(command.LocationAddress, command.LocationLatitude, command.LocationLongitude);

            var meeting = new NoneWorkingMeeting(command.Subject, command.StartDate, command.Duration,
                command.Description, location, command.Attendees, command.Agenda, command.SyncId, command.AppType,
                creator);
            if (command.Reminder != null)
                meeting.AddReminder(command.Reminder.ReminderType, command.Reminder.ReminderTimeType,
                    command.Reminder.RepeatingType, command.Reminder.CustomReminderTime);

            meetingRepository.Create(meeting);
        }

        public void ModifyWorkingMeeting(ModifyWorkingMeetingCmd command)
        {
            var actionOwner = userRepository.GetBy(command.ActionOwnerUserName);
            var meeting = getBy(command.Id, command.SyncId) as WorkingMeeting;
            if (meeting == null)
            {
                CreateWorkingMeeting(new CreateWorkingMeetingCmd
                {
                    SyncId = command.SyncId,
                    StartDate = command.StartDate,
                    Duration = command.Duration,
                    Agenda = command.Agenda,
                    Subject = command.Subject,
                    Reminder = command.Reminder,
                    Attendees = command.Attendees,
                    Description = command.Description,
                    LocationAddress = command.LocationAddress,
                    ActionOwnerUserName = command.ActionOwnerUserName,
                    LocationLatitude = command.LocationLatitude,
                    AppType = command.AppType,
                    LocationLongitude = command.LocationLongitude
                });
                meeting = (WorkingMeeting)getBy(command.Id, command.SyncId);
            }
            var location = new Location(command.LocationAddress, command.LocationLatitude, command.LocationLongitude);
            //todo: shit bazam inja 
            meeting.Update(command.Subject, command.StartDate, command.Duration, command.Description, location,
                command.Attendees, command.Agenda, command.AppType, actionOwner);
            if (command.Reminder != null)
                meeting.AddReminder(command.Reminder.ReminderType, command.Reminder.ReminderTimeType,
                    command.Reminder.RepeatingType, command.Reminder.CustomReminderTime);
            if (!string.IsNullOrWhiteSpace(command.Decisions) || !string.IsNullOrWhiteSpace(command.Details))
                meeting.UpdateDuringMeeting(command.Decisions, command.Details, actionOwner);
            if (command.Files != null && command.Files.Any())
                meeting.UpdateFiles(command.Files.Select(cf => new Tuple<string, string>(cf.ContentType, cf.Content)));
            else
                meeting.UpdateFiles(null);
            

            meetingRepository.Update(meeting);
        }

        public void ModifyNonWorkingMeeting(ModifyNonWorkingMeetingCmd command)
        {
            var actionOwner = userRepository.GetBy(command.ActionOwnerUserName);
            var meeting = getBy(command.Id, command.SyncId) as NoneWorkingMeeting;
            if (meeting == null)
            {
                CreateNonWorkingMeeting(new CreateNonWorkingMeetingCmd
                {
                    SyncId = command.SyncId,
                    StartDate = command.StartDate,
                    Duration = command.Duration,
                    Agenda = command.Agenda,
                    Subject = command.Subject,
                    Reminder = command.Reminder,
                    Attendees = command.Attendees,
                    Description = command.Description,
                    LocationAddress = command.LocationAddress,
                    ActionOwnerUserName = command.ActionOwnerUserName,
                    LocationLatitude = command.LocationLatitude,
                    AppType = command.AppType,
                    LocationLongitude = command.LocationLongitude
                });
                meeting = (NoneWorkingMeeting)getBy(command.Id, command.SyncId);
            }

            var location = new Location(command.LocationAddress, command.LocationLatitude, command.LocationLongitude);
            meeting.Update(command.Subject, command.StartDate, command.Duration, command.Description, location,
                command.Attendees, command.Agenda, command.AppType, actionOwner);
            if (command.Reminder != null)
                meeting.AddReminder(command.Reminder.ReminderType, command.Reminder.ReminderTimeType,
                    command.Reminder.RepeatingType, command.Reminder.CustomReminderTime);
            meetingRepository.Update(meeting);
        }

        public void Delete(DeleteMeetingCmd command)
        {
            var actionOwner = userRepository.GetBy(command.ActionOwnerUserName);
            var meeting = getBy(command.Id, command.SyncId);
            if (meeting == null)
                return;
            meeting.Delete(command.AppType, actionOwner);
            meetingRepository.Update(meeting);
        }

        public void Approve(ApproveMeetingCmd command)
        {
            var actionOwner = userRepository.GetBy(command.ActionOwnerUserName);
            var meeting = getBy(command.MeetingId, command.SyncId);
            if (meeting == null)
                return;
            meeting.Approve(actionOwner);
            meetingRepository.Update(meeting);

        }

        private Meeting getBy(long id, Guid syncId)
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

        //public void AddFile(AddFileToMeetingCmd command)
        //{
        //    var meeting = GetBy(command.MeetingId, command.SyncId);
        //    meeting.AddFile(command.ContentType, command.FileContent);
        //    meetingRepository.Update(meeting);
        //}

        //public void AddFiles(List<AddFileToMeetingCmd> commands)
        //{
        //    foreach (var command in commands)
        //    {
        //        AddFile(command);
        //    }
        //}

        #endregion

    }

}
