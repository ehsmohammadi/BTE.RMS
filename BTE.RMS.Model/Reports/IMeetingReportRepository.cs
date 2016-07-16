using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Model.Meetings;

namespace BTE.RMS.Model.Reports
{
    public interface IMeetingReportRepository : IRepository
    {
        int GetAllMeetingCountByDateTypeState(DateTime? @from, DateTime? to, MeetingType? meetingType, MeetingStateEnum? state, bool withMinuts, bool withAttachment);
        List<Meeting> GetMeetingByState(MeetingStateEnum state);
        int GetAllMeetingHoursByDateTypeState(DateTime? @from, DateTime? to, MeetingType? meetingType, MeetingStateEnum? state, bool withMinuts, bool withAttachment);
    }
}
