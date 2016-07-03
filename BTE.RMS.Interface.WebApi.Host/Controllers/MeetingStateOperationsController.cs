﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Files;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class MeetingStateOperationsController : ApiController
    {
        private readonly IMeetingFacadeService meetingService;

        public MeetingStateOperationsController(IMeetingFacadeService meetingService)
        {
            this.meetingService = meetingService;
        }


        public void Post(long meetingId, StateOperationEnum stateOperation)
        {
            if (stateOperation == StateOperationEnum.Approve)
                meetingService.Approve(meetingId);
            throw new NotImplementedException();
        }
    }
}
