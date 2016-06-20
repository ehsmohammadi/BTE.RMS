using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.Meetings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTE.RMS.Api.Test
{
    [TestClass]
    public class WebApiTest:BaseApiTest
    {
        

        [TestMethod,TestCategory("apitest")]
        public void GetMeetingFromWebApi()
        {
            var meetingListDto = TestHttpClientHelper.Get<List<MeetingDto>>(webApiUrl,"Meetings",AuthToken);
        }

        
    }
}
