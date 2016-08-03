using System;
using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Reports;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    [RoutePrefix("api/Reports/Meetings")]
    public class MeetingReportsController : ApiController
    {
        private readonly IMeetingReportService meetingReportService;

        public MeetingReportsController(IMeetingReportService meetingReportService)
        {
            this.meetingReportService = meetingReportService;
        }

        [Route("Counts")]
        public int PutMeetingCounts(MeetingReportDto meetingReportDto)
        {
            return meetingReportService.GetMeetingCounts(meetingReportDto);
        }

        [Route("Hours")]
        public int PutMeetingHours(MeetingReportDto meetingReportDto)
        {
            return meetingReportService.GetMeetingHours(meetingReportDto);
        }


        [Route("States/{state}")]
        public List<MeetingDto> PutMeetingByState(MeetingStateEnum state)
        {
            return meetingReportService.GetMeetingByState(state);
        }

         [Route("Daily")]
        public List<MeetingWithDateDto> PutMeetingByDate(MeetingReportDto reportDto)
        {
            return meetingReportService.GetMeetingByDate(reportDto);
        }
    }
}
