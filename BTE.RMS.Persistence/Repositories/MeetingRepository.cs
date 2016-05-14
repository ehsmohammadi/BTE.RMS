using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Model.Meetings;

namespace BTE.RMS.Persistence
{
    public class MeetingRepository : IMeetingRepository
    {
        #region Fields
        private readonly RMSContext ctx;
        #endregion

        #region Constructors
        public MeetingRepository(RMSContext rmsContext)
        {
            this.ctx = rmsContext;
        }
        #endregion

        #region Public Methods

        public IList<Meeting> GetAll()
        {
            return
                ctx.Meetings.AsNoTracking()
                    .Include("Category")
                    .ToList();

        }

        public Meeting GetBy(long id)
        {
            return ctx.Meetings.Single(t => t.Id == id);
        }

        public void Create(Meeting meeting)
        {
            ctx.Meetings.Add(meeting);
            ctx.SaveChanges();
        }

        public void Update(Meeting meeting)
        {
            ctx.SaveChanges();
        }

        public void Delete(Meeting meeting)
        {
            ctx.Meetings.Remove(meeting);
            ctx.SaveChanges();
        }

        //public Meeting GetBy(Guid syncId)
        //{
        //    return ctx.Meetings.Single(t => t.SyncId == syncId);
        //}

        #endregion

        #region Query Base Methods

        //public List<Meeting> GetMeetingByStartDate(DateTime startDate)
        //{
        //    var res = ctx.Meetings.AsNoTracking().Where(t => t.StartDate.Date == startDate.Date);
        //    return res.ToList();

        //}

        //public IEnumerable<Meeting> GetAllUnsyncForAndroidApp()
        //{
        //    var res = ctx.Meetings.AsNoTracking().Include("Category").Where(t => !t.SyncedWithAndriodApp);
        //    return res.ToList();
        //}

        //public IEnumerable<Meeting> GetAllUnsyncForDesktopApp()
        //{
        //    var res = ctx.Meetings.AsNoTracking().Include("Category").Where(t => !t.SyncedWithDesktopApp);
        //    return res.ToList();
        //}

        #endregion

    }
}
