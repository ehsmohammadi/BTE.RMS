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

        public int GetAllMeetingCountByDateTypeState(DateTime? @from, DateTime? to, MeetingType? meetingType, MeetingStateEnum? state, bool withMinuts, bool withAttachment, string userName)
        {
            var q = ctx.Meetings.AsNoTracking().Where(m => m.CreatorUser.UserName == userName);
            if (meetingType.HasValue)
            {
                if (meetingType.Value == MeetingType.Working)
                {
                    q = withMinuts ? q.Cast<WorkingMeeting>().Where(m => m.Decisions != "") : q.Cast<WorkingMeeting>();
                }

                if (meetingType.Value == MeetingType.NonWorking)
                    q = q.Cast<NoneWorkingMeeting>();
            }
            if (state.HasValue)
                q = q.Where(m => m.StateCode == state.Value);
            if (from.HasValue)
                q = q.Where(m => m.StartDate >= from.Value);
            if (to.HasValue)
                q = q.Where(m => m.StartDate <= to.Value);
            if (withAttachment)
                q = q.Where(m => m.Files.Any());
            return q.Count();
        }

        public List<Meeting> GetMeetingByState(MeetingStateEnum state, string userName)
        {
            return meetingsAsNoTracking.Where(m => m.CreatorUser.UserName == userName && m.StateCode == state).ToList();
        }

        public int GetAllMeetingHoursByDateTypeState(DateTime? @from, DateTime? to, MeetingType? meetingType, MeetingStateEnum? state, bool withMinuts, bool withAttachment, string userName)
        {
            var q = ctx.Meetings.AsNoTracking().Where(m => m.CreatorUser.UserName == userName);
            if (meetingType.HasValue)
            {
                if (meetingType.Value == MeetingType.Working)
                {
                    q = withMinuts ? q.Cast<WorkingMeeting>().Where(m => m.Decisions != "") : q.Cast<WorkingMeeting>();
                }

                if (meetingType.Value == MeetingType.NonWorking)
                    q = q.Cast<NoneWorkingMeeting>();
            }
            if (state.HasValue)
                q = q.Where(m => m.StateCode == state.Value);
            if (from.HasValue)
                q = q.Where(m => m.StartDate >= from.Value);
            if (to.HasValue)
                q = q.Where(m => m.StartDate <= to.Value);
            if (withAttachment)
                q = q.Where(m => m.Files.Any());
            return q.Sum(m => m.Duration);
        }

        public List<MeetingsWithDate> GetMeetingByDate(DateTime? from, DateTime? to, string userName)
        {
            var q = meetingsAsNoTracking.Where(m => m.CreatorUser.UserName == userName);
            if (from.HasValue)
                q = q.Where(m => m.StartDate >= from.Value);
            if (to.HasValue)
                q = q.Where(m => m.StartDate <= to.Value);
            return q.GroupBy(m => DbFunctions.CreateDateTime(m.StartDate.Year, m.StartDate.Month, m.StartDate.Day, 0, 0, 0))
                .Select(g => new MeetingsWithDate {Date = g.Key.Value, Meetings = g.ToList()}).ToList();
        }

        #endregion


    }
}
