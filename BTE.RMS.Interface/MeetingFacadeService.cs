using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Meeting;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Services.Contract;

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
            //todo:How to map to sime classes for not opening dto in method argument
            meetingService.Create(meetingModel.Subject,
                                  meetingModel.StartDate,
                                  meetingModel.Duration,
                                  meetingModel.Location,
                                  meetingModel.Attendees,
                                  meetingModel.Description);

        }

        public List<MeetingModel> GetAll()
        {
            var res = meetingRepository.GetAll();
            return res.Select(RMSMapper.Map<Meeting, MeetingModel>).ToList();
        }
    }
}
