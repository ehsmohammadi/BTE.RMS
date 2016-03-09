using System;
using BTE.RMS.Common;

namespace BTE.RMS.Model.Tasks
{
    public class Task
    {
        #region Sync properties

        public Guid SyncId { get; set; }

        public EntityActionType ActionType { get; set; }

        public bool SyncedWithAndriodApp { get; set; }

        public bool SyncedWithDesktopApp { get; set; }

        
        #endregion

        #region Properties

        public long Id { get; set; }

        public string Title { get; set; }


        public int WorkProgressPercent { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime StartTime { get; set; }


        public DateTime EndTime { get; set; }

        public string Content { get; set; }

        public TaskCategory Category { get; set; }

        #endregion

        #region Constructors

        public Task()
        {

        }

        public Task(string title, DateTime startDate, DateTime startTime, DateTime endTime, string content,
            int workProgressPercent, TaskCategory category, AppType appType, Guid syncId)
        {

            setProperties(title, workProgressPercent, startDate, startTime, endTime, content, category,
                EntityActionType.Create);
            setSyncStatus(appType);
            setSyncId(syncId);

        }

        #endregion

        #region Public methods

        public virtual void Update(string title, DateTime startDate, DateTime startTime, DateTime endTime,
            string content, int workProgressPercent, TaskCategory category, AppType appType)
        {
            setProperties(title, workProgressPercent, startDate, startTime, endTime, content, category,
                EntityActionType.Modify);
            setSyncStatus(appType);
        }

        public virtual void Delete(AppType appType)
        {
            setSyncStatus(appType);
            ActionType=EntityActionType.Delete;
        }

        public virtual void SyncWithAndriodApp()
        {
            SyncedWithAndriodApp = true;
        }

        public virtual void SyncWithDesktopApp()
        {
            SyncedWithDesktopApp = true;
        }

        #endregion

        #region Private methods

        private void setProperties(string title, int workProgressPercent, DateTime startDate, DateTime startTime, DateTime endTime, string content, TaskCategory category, EntityActionType entityActionType)
        {
            this.WorkProgressPercent = workProgressPercent;
            this.StartDate = startDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Content = content;
            this.Title = title;
            this.Category = category;
            SyncedWithAndriodApp = false;
            SyncedWithDesktopApp = false;
            this.ActionType = entityActionType;
        }

        private void setSyncStatus(AppType appType)
        {
            if (appType == AppType.AndriodApp)
                SyncedWithAndriodApp = true;

            if (appType == AppType.DesktopApp)
                SyncedWithDesktopApp = true;
        }

        private void setSyncId(Guid syncId)
        {
            if (syncId == null || syncId == default(Guid))
                syncId = Guid.NewGuid();
            SyncId = syncId;
        }

        #endregion
    }
}
