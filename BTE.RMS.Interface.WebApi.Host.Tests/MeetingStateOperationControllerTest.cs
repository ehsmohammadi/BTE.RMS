using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Files;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Model.Meetings;
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
    public class MeetingStateOperationControllerTest : BaseControllerTest
    {
        
        #region Utility Methods

        #endregion

        #region Test Methods

        
        [TestMethod]
        public void Post_AprrovedOperation_Should_Perform_ApprovedOperation_On_Meeting()
        {
            #region Arrange
            //Create Meeting with Scheduled State
            var arrangeController = ServiceLocator.Current.GetInstance<MeetingsController>();
            MeetingControllerTest.CreateWorkingMeeting(DateTime.Now, 1);
            var currentMeeting = arrangeController.GetAll().First();

            #endregion

            #region Act

            var actionController = ServiceLocator.Current.GetInstance<MeetingStateOperationsController>();
            actionController.Post(currentMeeting.Id, StateOperationEnum.Approve);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var actualMeeting = assertController.Get(currentMeeting.Id);
            MeetingControllerTest.AreEqual_State(MeetingStateEnum.Scheduled, actualMeeting);
            MeetingControllerTest.AreEqual_State(MeetingStateEnum.Approved, actualMeeting);
            #endregion

        }
        
        #endregion
    }
}
