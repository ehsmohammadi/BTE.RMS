using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Meetings;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
//    [Authorize]
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

        #region Methods
        public void Post(MeetingModel model)
        {
            meetingService.Create(model);
        }

        public List<MeetingModel> GetAll()
        {
            return meetingService.GetAll();
        }
        #endregion
    }
}
