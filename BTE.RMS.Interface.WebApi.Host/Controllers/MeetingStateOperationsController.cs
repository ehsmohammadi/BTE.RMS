using System;
using System.Web.Http;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Meetings;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class MeetingStateOperationsController : ApiController
    {
        private readonly IMeetingFacadeService meetingService;

        public MeetingStateOperationsController(IMeetingFacadeService meetingService)
        {
            this.meetingService = meetingService;
        }


        public void Post(long meetingId, MeetingOperationEnum meetingOperation)
        {
            if (meetingOperation == MeetingOperationEnum.Approve)
                meetingService.Approve(meetingId,Guid.Empty,AppType.WebApp);
            else if(meetingOperation == MeetingOperationEnum.Hold)
                meetingService.Hold(meetingId,Guid.Empty, AppType.WebApp);
            else if (meetingOperation == MeetingOperationEnum.Cancel)
                meetingService.Cancel(meetingId, Guid.Empty, AppType.WebApp);
            else if (meetingOperation == MeetingOperationEnum.Revert)
                meetingService.Revert(meetingId, Guid.Empty, AppType.WebApp);
            else
                throw new InvalidOperationException(meetingOperation+"is invalid");
        }

        public void PostByApp(AppType appType, Guid syncId, MeetingOperationEnum meetingOperation)
        {
            if (meetingOperation == MeetingOperationEnum.Approve)
                meetingService.Approve(0, syncId,appType);
            else if (meetingOperation == MeetingOperationEnum.Hold)
                meetingService.Hold(0, syncId, appType);
            else if (meetingOperation == MeetingOperationEnum.Cancel)
                meetingService.Cancel(0, syncId, appType);
            else if (meetingOperation == MeetingOperationEnum.Revert)
                meetingService.Revert(0, syncId, appType);
            else
                throw new InvalidOperationException(meetingOperation + "is invalid");
        }
    }
}
