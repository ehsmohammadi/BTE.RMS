using System;
using System.Collections.Generic;
using BTE.RMS.Model.Attendees;

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
        #endregion

        #region Constructors

        protected Meeting()
        {
            
        }

        protected Meeting(string subject, DateTime startDate, int duration, string description, Location location, List<Attendee> attendees)
        {
            setProperties(subject, startDate, duration, description, location, attendees);
        }
       
        #endregion

        #region Private Methods
        private void setProperties(string subject, DateTime startDate, int duration, string description, Location location,
            List<Attendee> attendees)
        {
            Subject = subject;
            StartDate = startDate;
            Duration = duration;
            Description = description;
            Location = location;
            Attendees = attendees;
        }
        #endregion
    }
}
