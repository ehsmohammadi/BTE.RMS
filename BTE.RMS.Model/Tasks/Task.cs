using System;
using BTE.RMS.Common;
using BTE.RMS.Model.Synchronization;
using BTE.RMS.Model.TaskCategories;

namespace BTE.RMS.Model.Tasks
{
    public class Task : Synchronizable
    {

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

        protected Task()
        {

        }

        public Task(string title, DateTime startDate, DateTime startTime, DateTime endTime, string content,
            int workProgressPercent, TaskCategory category, AppType appType, Guid syncId)
            : base(syncId, appType)
        {
            setProperties(title, workProgressPercent, startDate, startTime, endTime, content, category);
        }

        #endregion

        #region Public methods

        public virtual void Update(string title, DateTime startDate, DateTime startTime, DateTime endTime,
            string content, int workProgressPercent, TaskCategory category, AppType appType)
        {
            setProperties(title, workProgressPercent, startDate, startTime, endTime, content, category);
            SyncByUpdate(appType);
        }

        #endregion

        #region Private methods

        private void setProperties(string title, int workProgressPercent, DateTime startDate, DateTime startTime, DateTime endTime, string content, TaskCategory category)
        {
            this.WorkProgressPercent = workProgressPercent;
            this.StartDate = startDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Content = content;
            this.Title = title;
            this.Category = category;
        }

        #endregion
    }
}
