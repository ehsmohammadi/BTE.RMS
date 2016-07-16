using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Model.Meetings;

namespace BTE.RMS.Model.Reports
{
    public interface IMeetingReportRepository : IRepository
    {
        int GetAllMeetingCountByDateTypeState(DateTime? from, DateTime? to, MeetingType? meetingType, MeetingStateEnum? state, bool withMinuts, bool withAttachment, string userName);
        List<Meeting> GetMeetingByState(MeetingStateEnum state, string userName);
        int GetAllMeetingHoursByDateTypeState(DateTime? from, DateTime? to, MeetingType? meetingType, MeetingStateEnum? state, bool withMinuts, bool withAttachment, string userName);
        List<MeetingsWithDate> GetMeetingByDate(DateTime? from, DateTime? to, string userName);
    }
}
