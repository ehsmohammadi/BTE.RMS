using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Files;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Reports;
using BTE.RMS.Interface.WebApi.Host.Controllers;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Persistence;
using BTE.RMS.Services.Contract.Meetings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTE.RMS.Interface.WebApi.Host.Tests
{
    /// <summary>
    /// Summary Integration for test 
    /// </summary>
    [TestClass]
    public class MeetingReportsControllerTest : BaseControllerTest
    {

        #region Utility Methods



        #endregion

        #region Test Methods

        [TestMethod]
        public void GetMeetingCounts()
        {

            #region Arrange

            for (var i = 1; i <= 5; i++)
            {
                MeetingControllerTest.CreateWorkingMeeting(DateTime.Now.AddDays(-i), 1);
            }

            for (var i = 0; i < 5; i++)
            {
                MeetingControllerTest.CreateWorkingMeeting(DateTime.Now.AddDays(i), 1);
            }
            for (var i = 5; i < 10; i++)
            {
                MeetingControllerTest.CreateNoneWorkingMeeting(DateTime.Now.AddHours(i), 1);
            }

            #endregion

            #region Act

            var controller = ServiceLocator.Current.GetInstance<MeetingReportsController>();

            var pastCountReportDto = new MeetingReportDto { To = DateTime.Now };
            var pastMeetingCounts = controller.GetMeetingCounts(pastCountReportDto);

            var allCountReportDto = new MeetingReportDto();
            var allMeetingCounts = controller.GetMeetingCounts(allCountReportDto);

            var futureCountReportDto = new MeetingReportDto { From = DateTime.Now };
            var futureMeetingCounts = controller.GetMeetingCounts(futureCountReportDto);

            #endregion

            #region Assert

            Assert.AreEqual(6, pastMeetingCounts);
            Assert.AreEqual(9, futureMeetingCounts);
            Assert.AreEqual(15, allMeetingCounts);


            #endregion

        }

        [TestMethod]
        public void GetMeetingByState()
        {
            #region Arrange

            for (var i = 1; i <= 5; i++)
            {
                MeetingControllerTest.CreateWorkingMeeting(DateTime.Now.AddDays(-i), 1);
            }

            #endregion

            #region Act

            var controller = ServiceLocator.Current.GetInstance<MeetingReportsController>();
            var meeting = controller.GetMeetingByState(MeetingStateEnum.Approved);

            #endregion

            #region Assert
            Assert.AreEqual(5, meeting.Count());


            #endregion
        }

        [TestMethod]
        public void GetMeetingByData()
        {
            #region Arrange

            for (var i = 1; i <= 5; i++)
            {
                MeetingControllerTest.CreateWorkingMeeting(DateTime.Now.AddDays(-i), 1);
            }

            #endregion

            #region Act

            var controller = ServiceLocator.Current.GetInstance<MeetingReportsController>();
            var reportDto = new MeetingReportDto { To = DateTime.Now };
            var meeting = controller.GetMeetingByDate(reportDto);

            #endregion

            #region Assert
            //Assert.AreEqual(5, meeting.Count());


            #endregion
        }

        #endregion
    }
}
