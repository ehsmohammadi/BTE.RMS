using System;
using BTE.RMS.Common;

namespace BTE.RMS.Presentation.Logic.Tasks.Model
{
    public class Task
    {
        #region Properties

        public long Id { get; set; }

        public Guid SyncId { get; set; }

        public EntityActionType ActionType { get; set; }

        public bool SyncedWithServer { get; set; }

        public string Title { get; set; }

        public int WorkProgressPercent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TaskCategory Category { get; set; }

        #endregion

        #region Constructors

        public Task()
        {

        }

        public Task(string title, int workProgressPercent, DateTime startDate, DateTime startTime, DateTime endTime, TaskCategory category, EntityActionType entityActionType, Guid syncId, bool syncedWithServer)
        {

            setProperties(title, workProgressPercent, startDate, startTime, endTime, category, entityActionType, syncedWithServer);
            this.SyncId = syncId;
            this.SyncedWithServer = syncedWithServer;

        }

        #endregion

        #region Public methods

        public virtual void Update(string title, DateTime startDate, DateTime startTime, DateTime endTime, int workProgressPercent, TaskCategory category, EntityActionType entityActionType, bool syncWithServer)
        {
            setProperties(title, workProgressPercent, startDate, startTime, endTime, category, entityActionType, syncWithServer);
        }

        public virtual void SyncWithServer()
        {
            SyncedWithServer = true;
        }

        #endregion

        #region Private methods

        private void setProperties(string title, int workProgressPercent, DateTime startDate, DateTime startTime, DateTime endTime, TaskCategory category, EntityActionType entityActionType, bool syncedWithServer)
        {
            this.WorkProgressPercent = workProgressPercent;
            this.StartDate = startDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Title = title;
            this.Category = category;
            this.SyncedWithServer = false;
            this.ActionType = entityActionType;
            this.SyncedWithServer = syncedWithServer;
        }

        #endregion

    }
}
