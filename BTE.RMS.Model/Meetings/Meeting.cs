using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            set
            {
                MeetingStateEnum stateCode;
                if (!(Enum.TryParse(value.Value, false, out stateCode)))
                    throw new InvalidArgumentException("Meeting", "State");
                StateCode = stateCode;
            }
        }


        public IList<RMSFile> Files { get; set; }

        public IList<MeetingHistory> MeetingHistories { get; set; } 
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
            State = MeetingState.Scheduled;
            SetMeetingDateTime(startDate, duration);
            setProperties(subject, description,
                location, attendeesName, agenda);
            AddMeetingHistory(StateCode,MeetingOperationEnum.Create);
            SetInitializedState(appType);
            
        }





        #endregion

        #region Public methods

        public virtual void Update(string subject, DateTime startDate, int duration, string description,
            Location location, string attendeesName, string agenda, AppType appType, User actionOwner)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            var currentState = this.StateCode;
            Transfer(actionOwner,startDate, duration);
            setProperties(subject,description,
                location, attendeesName, agenda);
            SyncByUpdate(appType);
            AddMeetingHistory(currentState,MeetingOperationEnum.Modify);
        }

        public virtual void Delete(AppType appType, User actionOwner)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            var currentState = this.StateCode;
            base.Delete(appType);
            AddMeetingHistory(currentState,MeetingOperationEnum.Delete);
        }

        public virtual void AddReminder(ReminderType reminderType, ReminderTimeType reminderTimeType,
            RepeatingType repeatingType, int customReminderTime)
        {
            Reminder = new Reminder(reminderType, reminderTimeType, repeatingType, customReminderTime);
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

        public void AddMeetingHistory(MeetingStateEnum currentState,MeetingOperationEnum operation)
        {
           
            if(MeetingHistories==null) 
                MeetingHistories=new List<MeetingHistory>();
            MeetingHistories.Add(new MeetingHistory(currentState,operation));
        }

        public void Approve(User actionOwner,AppType appType)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            var currentState = this.StateCode;
            State.Approve(this);
            AddMeetingHistory(currentState,MeetingOperationEnum.Approve);
            SyncByUpdate(appType);

        }

        public void Hold(User actionOwner, AppType appType)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            var currentState = this.StateCode;
            State.Hold(this);
            AddMeetingHistory(currentState,MeetingOperationEnum.Hold);
            SyncByUpdate(appType);
        }

        public void Cancel(User actionOwner, AppType appType)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            var currentState = this.StateCode;
            State.Cancel(this);
            AddMeetingHistory(currentState,MeetingOperationEnum.Cancel);
            SyncByUpdate(appType);
        }

        public void Revert(User actionOwner, AppType appType)
        {
            CreatorUser.AllowToDoAction(actionOwner);
            var currentState = this.StateCode;
            State.Revert(this);
            AddMeetingHistory(currentState,MeetingOperationEnum.Revert);
            SyncByUpdate(appType);
        }

        public void Transfer(User actionOwner, DateTime startDate, int duration)
        {
            if (!IsMeetingDateTimeChanged(startDate, duration)) return;
            CreatorUser.AllowToDoAction(actionOwner);
            var currentState = this.StateCode;
            State.Transfer(this,startDate,duration);
            AddMeetingHistory(currentState,MeetingOperationEnum.Transfer);
        }

        #endregion

        #region Private Methods
        //Should not be called out side model
        public void SetInitializedState(AppType appType)
        {
            Approve(CreatorUser,appType);
        }


        public bool IsMeetingDateTimeChanged(DateTime startDate, int duration)
        {
            return (StartDate.ToShortDateString() != startDate.ToShortDateString() || Duration != duration);
        }

        //Should not be called out side model
        public void SetMeetingDateTime(DateTime startDate, int duration)
        {
            meetingValidator.Value.ValidateStartDateAndDuration(this, startDate, duration);
            StartDate = startDate;
            Duration = duration;
        }

        private void setProperties(string subject, string description, Location location, string attendeesName,
            string agenda)
        {
            if (string.IsNullOrWhiteSpace(subject))
                throw new InvalidArgumentException("Meeting","Subject");
            Subject = subject;
            Description = description;
            Location = location;
            if (string.IsNullOrWhiteSpace(attendeesName))
                throw new InvalidArgumentException("Meeting", "attendeesName");
            Attendees = attendeesName;
            Agenda = agenda;

        }

        #endregion


    }
}
