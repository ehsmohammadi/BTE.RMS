using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Meetings;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class MeetingHistoriesController : ApiController
    {
        private readonly IMeetingFacadeService meetingService;

        public MeetingHistoriesController(IMeetingFacadeService meetingService)
        {
            this.meetingService = meetingService;
        }

        [HttpPost]
        public List<MeetingHistoryDto> Get(long meetingId)
        {
            return meetingService.GetMeetingHistories(meetingId);
        }
    }
}
