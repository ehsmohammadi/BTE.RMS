using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Meetings;

namespace BTE.RMS.Interface.Contract.Reports
{
    public interface IMeetingReportService : IFacadeService
    {
        int GetMeetingCounts(MeetingReportDto meetingReportDto);
        List<MeetingDto> GetMeetingByState(MeetingStateEnum state);
        int GetMeetingHours(MeetingReportDto meetingReportDto);
    }
}
