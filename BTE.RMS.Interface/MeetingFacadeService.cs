using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Meetings;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Services.Contract.Meetings;

namespace BTE.RMS.Interface
{
    public class MeetingFacadeService:IMeetingFacadeService
    {
        private readonly IMeetingService meetingService;
        private readonly IMeetingRepository meetingRepository;

        public MeetingFacadeService(IMeetingService meetingService , IMeetingRepository meetingRepository)
        {
            this.meetingService = meetingService;
            this.meetingRepository = meetingRepository;
        }

        public void Create(MeetingModel meetingModel)
        {
            //todo:why this shit is here if logic in facade service 
            if (meetingModel.MeetingType == MeetingType.Working)
            {
                var command = RMSMapper.Map<MeetingModel, CreateWorkingMeetingCmd>(meetingModel);
                meetingService.CreateWorkingMeeting(command);
            }
            else if (meetingModel.MeetingType == MeetingType.NonWorking)
            {
                var command = RMSMapper.Map<MeetingModel, CreateNonWorkingMeetingCmd>(meetingModel);
                meetingService.CreateNonWorkingMeeting(command);
            }
            throw new Exception("Meeting Command is not set correctlly");
            
        }

        public List<MeetingModel> GetAll()
        {
            var res = meetingRepository.GetAll();
            return res.Select(RMSMapper.Map<Meeting, MeetingModel>).ToList();
        }
    }
}
