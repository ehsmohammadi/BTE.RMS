using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Model.Meetings;

namespace BTE.RMS.Persistence
{
    public class MeetingRepository : IMeetingRepository
    {
        #region Fields
        private readonly RMSContext ctx;
        private readonly IQueryable<Meeting> meetingsAsNoTracking;
        private readonly IQueryable<Meeting> meetingsAttached;
        #endregion

        #region Constructors
        public MeetingRepository(RMSContext rmsContext)
        {
            this.ctx = rmsContext;
            meetingsAsNoTracking =
                ctx.Meetings.Include(m => m.Reminder)
                    .Include(m => m.Files)
                    .Include(m => m.CreatorUser)
                    .AsNoTracking();
            meetingsAttached =
                ctx.Meetings.Include(m => m.Reminder)
                    .Include(m => m.Files)
                    .Include(m => m.CreatorUser);
        }
        #endregion

        #region Public Methods

        public IList<Meeting> GetAll()
        {
            return meetingsAsNoTracking.Where(m => m.ActionType != EntityActionType.Delete).ToList();
        }

        public IEnumerable<Meeting> GetAllByUserName(string userName)
        {
            return meetingsAsNoTracking.Where(m => m.ActionType != EntityActionType.Delete && m.CreatorUser.UserName == userName).ToList();
        }

        public IEnumerable<Meeting> GetAllByUserNameAndStartDate(string userName, DateTime startDate)
        {
            var queryStartDate = startDate.Date;
            var queryEndDate = queryStartDate.AddDays(1);
            return
                meetingsAsNoTracking.Where(
                    m =>
                        m.ActionType != EntityActionType.Delete &&
                        m.CreatorUser.UserName == userName &&
                        queryStartDate <= m.StartDate &&
                        m.StartDate <= queryEndDate
                        ).ToList();
        }

        public Meeting GetBy(long id)
        {
            return meetingsAttached.Single(t => t.Id == id);
        }

        public Meeting GetByUserName(string userName, long id)
        {
            return meetingsAttached.Single(t => t.Id == id && t.CreatorUser.UserName == userName);
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

        #endregion

        #region SyncMethods

        public IEnumerable<Meeting> GetAllUnsyncForAndroidApp()
        {
            var res = meetingsAsNoTracking.Where(t => !t.SyncedWithAndriodApp);
            return res.ToList();
        }

        public IEnumerable<Meeting> GetAllUnsyncForAndroidAppByCreator(string userName)
        {
            var res = meetingsAsNoTracking.Where(t => !t.SyncedWithAndriodApp && t.CreatorUser.UserName == userName);
            return res.ToList();
        }

        public IEnumerable<Meeting> GetAllUnsyncForDesktopApp()
        {
            var res = meetingsAsNoTracking.Where(t => !t.SyncedWithDesktopApp);
            return res.ToList();
        }

        public IEnumerable<Meeting> GetAllUnsyncForDesktopAppByCreator(string userName)
        {
            var res = meetingsAsNoTracking.Where(t => !t.SyncedWithDesktopApp && t.CreatorUser.UserName == userName);
            return res.ToList();
        }

        public Meeting GetBy(Guid syncId)
        {
            return meetingsAttached.SingleOrDefault(t => t.SyncId == syncId);
        }
        #endregion

        #region Query Base Methods

        #endregion

    }
}
