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

        #region Fields


        #endregion

        #region Constructors
        public MeetingReportService(IMeetingReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        #endregion

        #region Methods
        public int GetMeetingCounts(MeetingReportDto meetingReportDto)
        {
            return reportRepository.GetAllMeetingCountByDateTypeState(meetingReportDto.From, meetingReportDto.To,
                meetingReportDto.MeetingType, meetingReportDto.State,meetingReportDto.WithMinuts,meetingReportDto.WithAttachment);
        }

        public List<MeetingDto> GetMeetingByState(MeetingStateEnum state)
        {
            var res = reportRepository.GetMeetingByState(state);
            return res.Select(RMSMapper.Map<Meeting, MeetingDto>).ToList();
        }

        public int GetMeetingHours(MeetingReportDto meetingReportDto)
        {
            return reportRepository.GetAllMeetingHoursByDateTypeState(meetingReportDto.From, meetingReportDto.To,
                 meetingReportDto.MeetingType, meetingReportDto.State, meetingReportDto.WithMinuts, meetingReportDto.WithAttachment);
        }

        #endregion


    }

}
