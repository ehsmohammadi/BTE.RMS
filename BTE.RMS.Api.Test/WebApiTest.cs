using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Meetings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTE.RMS.Api.Test
{
    [TestClass]
    public class WebApiTest : BaseApiTest
    {
        private static MeetingDto createBaseMeetingDto(DateTime startDate, int duration)
        {
            var dto = new MeetingDto
            {
                Subject = "TestMeeting",
                StartDate = startDate,
                Duration = duration,
                Description = "This is test Meeting that we want to have in this section",
                LocationAddress = "its test location for us to know ",
                LocationLatitude = 3.334433443,
                LocationLongitude = 4.33333333,
                Agenda = "this is test meeting agenda",
                Attendees = "ehsan mohammadi,reza akbari, davood shokri,mohammad reza bayat",
            };
            return dto;

        }


        [TestMethod, TestCategory("apitest")]
        public void GetMeetingFromWebApi()
        {
            var meetingListDto = TestHttpClientHelper.Get<List<MeetingDto>>(webApiUrl, "Meetings", AuthToken);
        }


        [TestMethod, TestCategory("apitest")]
        public void PostMeetingStateFromWebApi()
        {
            //var meetingDto = createBaseMeetingDto(DateTime.Now, 1);
            //meetingDto.MeetingType = (int)MeetingType.Working;
            //TestHttpClientHelper.Post(webApiUrl, "Meetings", meetingDto, AuthToken);
            var meetingDto = TestHttpClientHelper.Get<List<MeetingDto>>(webApiUrl, "Meetings", AuthToken).First();
            meetingDto.Duration=7;
            TestHttpClientHelper.Put(webApiUrl, "Meetings", meetingDto, AuthToken);
            //TestHttpClientHelper.Post(webApiUrl, "Meetings/394" + "/StateOperations/" + MeetingOperationEnum.Hold, "", AuthToken);
            var res = TestHttpClientHelper.Get<List<MeetingDto>>(webApiUrl, "Meetings", AuthToken).First();

        }


    }
}
