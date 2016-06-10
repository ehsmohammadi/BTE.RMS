using System;
using BTE.RMS.Common;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public class WorkingMeeting : Meeting
    {

        #region Properties
        public string Details { get; set; }
        public string Decisions { get; set; }

        #endregion


        #region Constructors
        protected WorkingMeeting()
        {

        }
        public WorkingMeeting(string subject,
                                    DateTime startDate,
                                    int duration,
                                    string description,
                                    Location location, string attendeesName, string agenda, Guid syncId, AppType appType, User creator)
            : base(subject, startDate, duration, description, location, attendeesName, agenda, syncId, appType, creator)
        {

        }
        #endregion

        #region public methods

        public void Update(string subject, DateTime startDate, int duration, string description,
            string attendeesName, Location location, string agenda, AppType appType, User actionOwner)
        {
            base.Update(subject, startDate, duration, description, location, attendeesName, agenda, appType, actionOwner);
        }


        public void UpdateDuringMeeting(string decisions, string details, User actionOwner)
        {
            this.CreatorUser.AllowToDoAction(actionOwner);
            Decisions = decisions;
            Details = details;
        }
        #endregion

    }
}
