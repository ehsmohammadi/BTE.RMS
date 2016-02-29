using System;
using BTE.RMS.Common;

namespace BTE.RMS.Model.Tasks
{
    public class Task
    {
        #region Properties

        public long Id { get; set; }

        public Guid SyncId { get; set; }

        public EntityActionType ActionType { get; set; }

        public string Title { get; set; }


        public int WorkProgressPercent { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime StartTime { get; set; }


        public DateTime EndTime { get; set; }

        public string Content { get; set; }

        public TaskCategory Category { get; set; }

        public bool IsSyncWithAndriodApp { get; set; }

        public bool IsSyncWithDesktopApp { get; set; }

        #endregion

        #region Constructors
        public Task()
        {

        }

        public Task(string title, int workProgressPercent, DateTime startDate, DateTime startTime, DateTime endTime, string content, TaskCategory category, DeviceType deviceType, EntityActionType entityActionType, Guid syncId = default(Guid))
        {

            setProperties(title, workProgressPercent, startDate, startTime, endTime, content, category, entityActionType);
            setSyncStatus(deviceType);
            if (syncId == default(Guid))
                syncId = Guid.NewGuid();
            this.SyncId = syncId;

        }

        #endregion

        #region Public methods

        public virtual void Update(string title, DateTime startDate, DateTime startTime, DateTime endTime, string content, int workProgressPercent, TaskCategory category, DeviceType deviceType, EntityActionType entityActionType)
        {
            setProperties(title, workProgressPercent, startDate, startTime, endTime, content, category, entityActionType);
            setSyncStatus(deviceType);
        }

        public virtual void SyncWithAndriodApp()
        {
            IsSyncWithAndriodApp = true;
        }

        public virtual void SyncWithDesktopApp()
        {
            IsSyncWithDesktopApp = true;
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
            IsSyncWithAndriodApp = false;
            IsSyncWithDesktopApp = false;
            this.ActionType = entityActionType;
        }

        private void setSyncStatus(DeviceType deviceType)
        {
            if (deviceType == DeviceType.AndriodApp)
                IsSyncWithAndriodApp = true;

            if (deviceType == DeviceType.DesktopApp)
                IsSyncWithDesktopApp = true;
        }

        #endregion

    }
}
