using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using BTE.RMS.Common;
using BTE.RMS.Model.RMSFiles;
using BTE.RMS.Model.Synchronization;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public class Meeting : Synchronizable
    {

        #region Properties

        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public string Attendees { get; set; }
        public string Agenda { get; set; }


        public ICollection<RMSFile> Files { get; set; }
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


        public void AddFile(string contentType, byte[] fileContent)
        {
            if (Files == null)
                Files = new List<RMSFile>();
            var file = new RMSFile("Meeting:" + this.Id + ":File", contentType, fileContent);
            Files.Add(file);
        }

        #endregion

        #region Private Methods

        private void setProperties(string subject, DateTime startDate, int duration, string description,
            Location location, string attendeesName, string agenda)
        {
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
