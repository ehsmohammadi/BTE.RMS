using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Meetings;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    [Authorize]
    public class MeetingsController : ApiController
    {
        #region Fields
        private readonly IMeetingFacadeService meetingService;       
        #endregion

        #region Costructors

        public MeetingsController(IMeetingFacadeService meetingService)
        {
            this.meetingService = meetingService;
        }

        #endregion

        #region Normal Methods

        [HttpGet]
        public IList<MeetingDto> GetAll()
        {
            return meetingService.GetAll();
        }

        [HttpPost]
        public void PostMeeting(MeetingDto dto)
        {
            meetingService.Create(dto, AppType.WebApp);
        }

      

        [HttpPut]
        public void PutMeeting(MeetingDto dto)
        {
            meetingService.Modify(dto, AppType.WebApp,Guid.Empty);
        }

        public void Delete(long id)
        {
            meetingService.Delete(new MeetingDto{Id = id}, AppType.WebApp,Guid.Empty);
        }

        [HttpGet]
        public MeetingDto Get(long id)
        {
            return meetingService.GetBy(id);
        }

        #endregion

        #region SyncMethods
        [HttpGet]
        public IEnumerable<MeetingSyncItem> GetAll(int deviceType)
        {
            return meetingService.GetAllUnSync(deviceType);
        }

        [HttpPost]
        public IHttpActionResult PostMeetings(MeetingSyncRequest syncReuest,string forSync)
        {
            meetingService.Sync(syncReuest);
            return Ok();
        } 
        #endregion
    }
}
