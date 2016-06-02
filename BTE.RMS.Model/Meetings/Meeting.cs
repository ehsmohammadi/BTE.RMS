using System;
using System.Data;
using BTE.RMS.Common;
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
        public string AttendeesName { get; set; }
        public string Agenda { get; set; }
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
            Location location, string attendeesName, string agenda,AppType appType)
        {
            setProperties(subject, startDate, duration, description,
                location, attendeesName, agenda);
            SyncByUpdate(appType);
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
            AttendeesName = attendeesName;
            Agenda = agenda;
        }

        #endregion


    }
}
