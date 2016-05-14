using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Model.Meetings
{
    public class Meeting
    {
        
        #region Properties and BackFields
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Attendees { get; set; }
        #endregion

        #region Constructors
        public Meeting(string subject, DateTime startDate, int duration, string description, string location, string attendees)
        {
            setProperties(subject, startDate, duration, description, location, attendees);
        
        }
        
        #endregion

        #region Private Methods
        private void setProperties(string subject, DateTime startDate, int duration, string description, string location,
            string attendees)
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
