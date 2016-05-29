using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Meetings;

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
        public void Post(MeetingDto model)
        {
            meetingService.Create(model,AppType.WebApp);
        }

        public IList<MeetingDto> GetAll()
        {
            return meetingService.GetAll();
        }
        #endregion

        #region SyncMethods
        [HttpGet]
        public IEnumerable<MeetingDto> GetAll(int deviceType)
        {
            var tasks = meetingService.GetAllUnSync(deviceType);
            return tasks;
        }

        [HttpPost]
        public IHttpActionResult PostTasks(MeetingSyncRequest syncReuest)
        {
            meetingService.Sync(syncReuest);
            return Ok();
        } 
        #endregion
    }
}
