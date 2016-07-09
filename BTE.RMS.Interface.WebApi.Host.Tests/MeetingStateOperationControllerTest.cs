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
        public void Post_HoldOperation_Should_Perform_HoldOperation_On_Meeting_With_ApproveSate()
        {
            #region Arrange
            //Create Meeting with Scheduled State
            var arrangeController = ServiceLocator.Current.GetInstance<MeetingsController>();
            MeetingControllerTest.CreateWorkingMeeting(DateTime.Now, 1);
            var context=new RMSContext();
            var currentMeeting = context.Meetings.First(); 
            var currentMeetingDto = arrangeController.GetAll().First();

            #endregion

            #region Act

            var actionController = ServiceLocator.Current.GetInstance<MeetingStateOperationsController>();
            actionController.Post(currentMeeting.Id, MeetingOperationEnum.Hold);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var actualMeeting = assertController.Get(currentMeetingDto.Id);
            MeetingControllerTest.AreEqual_State(MeetingStateEnum.Approved, currentMeetingDto);
            MeetingControllerTest.AreEqual_State(MeetingStateEnum.Held, actualMeeting);
            #endregion

        }

        [TestMethod]
        public void Post_Cancel_Operation_Should_Perform_Cancel_Operation_On_Meeting_With_ApproveSate()
        {
            #region Arrange
            //Create Meeting with Scheduled State
            var arrangeController = ServiceLocator.Current.GetInstance<MeetingsController>();
            MeetingControllerTest.CreateWorkingMeeting(DateTime.Now, 1);
            var context = new RMSContext();
            var currentMeeting = context.Meetings.First(); 
            var currentMeetingDto = arrangeController.GetAll().First();

            #endregion

            #region Act

            var actionController = ServiceLocator.Current.GetInstance<MeetingStateOperationsController>();
            actionController.Post(currentMeeting.Id, MeetingOperationEnum.Cancel);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var actualMeeting = assertController.Get(currentMeetingDto.Id);
            MeetingControllerTest.AreEqual_State(MeetingStateEnum.Approved, currentMeetingDto);
            MeetingControllerTest.AreEqual_State(MeetingStateEnum.Canceled, actualMeeting);
            #endregion

        }

        #endregion
    }
}
