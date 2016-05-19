using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Meeting;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    [Authorize]
    public class MeetingsController : ApiController
    {

        #region Fields

        private readonly IMeetingFacadeService meetingService;

        #endregion

        #region Constructors

        public MeetingsController(IMeetingFacadeService meetingService)
        {
            this.meetingService = meetingService;
        }

        #endregion

        #region Methods

        public List<MeetingModel> Get()
        {
            return meetingService.GetAll();
        }

        public void Post(MeetingModel model)
        {
            meetingService.Create(model);
        }
 
        #endregion

    }
}
