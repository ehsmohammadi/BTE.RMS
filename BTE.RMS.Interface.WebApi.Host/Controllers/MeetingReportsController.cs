using System.Web.Http;
using BTE.RMS.Interface.Contract.Reports;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class MeetingReportsController : ApiController
    {
        private readonly IMeetingReportService meetingReportService;

        public MeetingReportsController(IMeetingReportService meetingReportService)
        {
            this.meetingReportService = meetingReportService;
        }
    }
}
