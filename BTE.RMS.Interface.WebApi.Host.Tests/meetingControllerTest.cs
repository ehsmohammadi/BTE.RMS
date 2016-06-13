using BTE.Core;
using BTE.RMS.Interface.WebApi.Host.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTE.RMS.Interface.WebApi.Host.Tests
{
    /// <summary>
    /// Summary description for meetingControllerTest
    /// </summary>
    [TestClass]
    public class MeetingControllerTest:BaseControllerTest
    {


        [TestMethod]
        public void GetAllMeeting()
        {
            var controller = ServiceLocator.Current.GetInstance<MeetingsController>();
            var meetings = controller.GetAll();

        }
    }
}
