using System;

namespace BTE.RMS.Model.Tasks
{
    public class Task
    {
        #region Temp code
        //private long id;
        //public long Id { get { return id; } }

        //private string title;
        //public string Title { get; set; }

        //private int workProgressPercent;
        //public int WorkProgressPercent { get { return workProgressPercent; } }

        //private DateTime startDate;
        //public DateTime StartDate { get { return startDate; } }

        //private DateTime startTime;
        //public DateTime StartTime { get { return startTime; }}

        //private DateTime endTime;
        //public DateTime EndTime { get { return endTime; }}

        //private bool synced; 

        //public Task(long id,PlatformTypeEnum platformType, string title, int workProgressPercent, DateTime startDate, DateTime startTime, DateTime endTime)
        //{

        //}
        #endregion

        #region Properties
        
        public long Id { get; set; }


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

        public Task(string title, int workProgressPercent, DateTime startDate, DateTime startTime, DateTime endTime)
        {
            this.WorkProgressPercent = workProgressPercent;
            this.StartDate = startDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Title = title;
        }

        #endregion

    }
}
