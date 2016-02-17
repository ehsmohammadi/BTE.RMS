using System;

namespace BTE.RMS.Model.Task
{
    public abstract class Task
    {

        #region Properties & Backfields

        private long id;
        public long Id { get { return id; } }

        private string title;
        public string Title { get; set; }

        private int workProgressPercent;
        public int WorkProgressPercent { get { return workProgressPercent; } }

        private DateTime startDate;
        public DateTime StartDate { get { return startDate; } }

        private DateTime startTime;
        public DateTime StartTime { get { return startTime; }}

        private DateTime endTime;
        public DateTime EndTime { get { return endTime; }}

        private bool synced;

        #endregion

        public Task(long id,PlatformTypeEnum platformType, string title, int workProgressPercent, DateTime startDate, DateTime startTime, DateTime endTime)
        {
            
        }

    }
}
