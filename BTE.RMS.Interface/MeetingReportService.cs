using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Reports;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.Reports;
using BTE.RMS.Services.Contract.Meetings;

namespace BTE.RMS.Interface
{
    public class MeetingReportService : IMeetingReportService
    {
        private readonly IMeetingReportRepository reportRepository;
        private readonly ISecurityService securityService;

        #region Fields


        #endregion

        #region Constructors
        public MeetingReportService(IMeetingReportRepository reportRepository, ISecurityService securityService)
        {
            this.reportRepository = reportRepository;
            this.securityService = securityService;
        }

        #endregion

        #region Methods
        public int GetMeetingCounts(MeetingReportDto meetingReportDto)
        {
            var userName = securityService.GetCurrentUserName();
            return reportRepository.GetAllMeetingCountByDateTypeState(meetingReportDto.From, meetingReportDto.To,
                meetingReportDto.MeetingType, meetingReportDto.State, meetingReportDto.WithMinuts, meetingReportDto.WithAttachment, userName);
        }

        public List<MeetingDto> GetMeetingByState(MeetingStateEnum state)
        {
            var userName = securityService.GetCurrentUserName();
            var res = reportRepository.GetMeetingByState(state, userName);
            return res.Select(RMSMapper.Map<Meeting, MeetingDto>).ToList();
        }

        public int GetMeetingHours(MeetingReportDto meetingReportDto)
        {
            var userName = securityService.GetCurrentUserName();
            return reportRepository.GetAllMeetingHoursByDateTypeState(meetingReportDto.From, meetingReportDto.To,
                 meetingReportDto.MeetingType, meetingReportDto.State, meetingReportDto.WithMinuts, meetingReportDto.WithAttachment, userName);
        }

        #endregion


    }

}
