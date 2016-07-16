using System;
using System.Linq;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Interface.WebApi.Host.Controllers;
using BTE.RMS.Persistence;
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
            var history = context.Meetings.Include("MeetingHistories").First();
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

        [TestMethod]
        public void Post_RevertOperation_Should_Perform_RevertOperation_On_Meeting_With_HoldState()
        {
            #region Arrange
            //Create Meeting with Scheduled State
            var arrangeController = ServiceLocator.Current.GetInstance<MeetingsController>();
            MeetingControllerTest.CreateWorkingMeeting(DateTime.Now, 1);
            var context = new RMSContext();
            var currentMeeting = context.Meetings.First();
            var arrangeStateOperationsController = ServiceLocator.Current.GetInstance<MeetingStateOperationsController>();
            arrangeStateOperationsController.Post(currentMeeting.Id, MeetingOperationEnum.Hold);
            var currentMeetingDto = arrangeController.GetAll().First();

            #endregion

            #region Act

            var actionController = ServiceLocator.Current.GetInstance<MeetingStateOperationsController>();
            actionController.Post(currentMeeting.Id, MeetingOperationEnum.Revert);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var actualMeeting = assertController.Get(currentMeetingDto.Id);
            var history = context.Meetings.Include("MeetingHistories").First();
            MeetingControllerTest.AreEqual_State(MeetingStateEnum.Held, currentMeetingDto);
            MeetingControllerTest.AreEqual_State(MeetingStateEnum.Approved, actualMeeting);
            #endregion

        }

        #endregion
    }
}
