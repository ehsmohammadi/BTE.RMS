using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Model.Meetings.MeetingStates;
using BTE.RMS.Model.RMSFiles;
using BTE.RMS.Model.Synchronization;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public class Meeting : Synchronizable
    {
        #region MyRegion
        //todo: must be removed 
        private readonly Lazy<IMeetingValidationService> meetingValidator =
            new Lazy<IMeetingValidationService>(() => ServiceLocator.Current.GetInstance<IMeetingValidationService>());
        #endregion

        #region Properties

        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public string Attendees { get; set; }
        public string Agenda { get; set; }

        public MeetingStateEnum StateCode { get; set; }

        [NotMapped]
        public MeetingState State 
        {
            get { return (int)StateCode; }
            //set { StateCode = MeetingStateEnum.TryParse(State.Value,false,StateCode); }
        }


        public IList<RMSFile> Files { get; set; }
        public Reminder Reminder { get; set; }
        public User CreatorUser { get; set; }

        #endregion

        #region Constructors

        protected Meeting()
        {

        }

        protected Meeting(string subject,
            DateTime startDate,
            int duration,
            string description,
            Location location, string attendeesName, string agenda, Guid syncId, AppType appType, User creator)
            : base(syncId, appType)
        {
            //State=MeetingState.Scheduled;
            CreatorUser = creator;
            setProperties(subject, startDate, duration, description,
                location, attendeesName, agenda);
        }

        #endregion

        #region Public methods

        public virtual void Update(string subject, DateTime startDate, int duration, string description,
            Location location, string attendeesName, string agenda, AppType appType, User actionOwner)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            //todo:Check if current user own this meeting for modify
            setProperties(subject, startDate, duration, description,
                location, attendeesName, agenda);
            SyncByUpdate(appType);
        }

        public virtual void AddReminder(ReminderType reminderType, ReminderTimeType reminderTimeType,
            RepeatingType repeatingType, int customReminderTime)
        {
            Reminder = new Reminder(reminderType, reminderTimeType, repeatingType, customReminderTime);
        }

        public virtual void Delete(AppType appType, User actionOwner)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            base.Delete(appType);
        }


        public void AddFile(string contentType, string fileContent)
        {
            var file = new RMSFile("Meeting:" + this.Id + ":File", contentType, fileContent);
            Files.Add(file);
        }

        public void UpdateFiles(IEnumerable<Tuple<string, string>> files)
        {

            Files = new List<RMSFile>();
            if (files == null) return;
            foreach (var file in files)
            {
                AddFile(file.Item1, file.Item2);

            }
        }

        public void Approve(User actionOwner)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            State.Approve(this);
        }

        #endregion

        #region Private Methods

        private void setProperties(string subject, DateTime startDate, int duration, string description,
            Location location, string attendeesName, string agenda)
        {
            meetingValidator.Value.ValidateStartDateAndDuration(this, startDate, duration);
            Subject = subject;
            StartDate = startDate;
            Duration = duration;
            Description = description;
            Location = location;
            Attendees = attendeesName;
            Agenda = agenda;
        }

        #endregion

        
    }
}
