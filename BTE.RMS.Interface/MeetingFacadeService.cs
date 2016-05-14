using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Meeting;
using BTE.RMS.Services.Contract;

namespace BTE.RMS.Interface
{
    public class MeetingFacadeService:IMeetingFacadeService
    {
        private readonly IMeetingService meetingService;

        public MeetingFacadeService(IMeetingService meetingService)
        {
            this.meetingService = meetingService;
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
    }
}
