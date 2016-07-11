using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.Reports;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Persistence
{
    public class MeetingReportRepository : IMeetingReportRepository
    {
        #region Fields
        private readonly RMSContext ctx;
        private readonly IQueryable<Meeting> meetingsAsNoTracking;
        #endregion

        #region Constructors
        public MeetingReportRepository(RMSContext rmsContext)
        {
            this.ctx = rmsContext;
            meetingsAsNoTracking =
                ctx.Meetings.Include(m => m.Reminder)
                    .Include(m => m.Files)
                    .Include(m => m.CreatorUser)
                    .AsNoTracking();
        }
        #endregion

        #region Public Methods



        #endregion


    }
}
