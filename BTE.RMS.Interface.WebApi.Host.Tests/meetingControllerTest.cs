﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Files;
using BTE.RMS.Interface.Contract.Meetings;
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
    public class MeetingControllerTest : BaseControllerTest
    {
        
        #region Utility Methods

        public static void AreEqual_BaseMeetingDto(MeetingDto expect, MeetingDto actual)
        {
            Assert.AreEqual(expect.Subject, actual.Subject);
            Assert.AreEqual(expect.StartDate.ToString(CultureInfo.CurrentCulture),
                actual.StartDate.ToString(CultureInfo.CurrentCulture));
            Assert.AreEqual(expect.MeetingType, actual.MeetingType);
            Assert.AreEqual(expect.Duration, actual.Duration);
            Assert.AreEqual(expect.Description, actual.Description);
            Assert.AreEqual(expect.LocationAddress, actual.LocationAddress);
            Assert.AreEqual(expect.LocationLatitude, actual.LocationLatitude);
            Assert.AreEqual(expect.LocationLongitude, actual.LocationLongitude);
            Assert.AreEqual(expect.Agenda, actual.Agenda);
            Assert.AreEqual(expect.Attendees, actual.Attendees);
            
        }

        public static void AreEqual_State(MeetingStateEnum state, MeetingDto actual)
        {
            Assert.AreEqual(state,actual.State);
        }

        public static void AreEqual_WorkingMeetingDto(MeetingDto expect, MeetingDto actual)
        {
            Assert.AreEqual(expect.Decisions, actual.Decisions);
            Assert.AreEqual(expect.Details, actual.Details);

        }

        public static void AreEqual_FileDto(FileDto expect, FileDto actual)
        {
            Assert.AreEqual(expect.ContentType, actual.ContentType);
            Assert.AreEqual(expect.Content, actual.Content);

        }

        public static void AreEqual_ReminderDto(ReminderDto expect, ReminderDto actual)
        {
            Assert.AreEqual(expect.CustomReminderTime, actual.CustomReminderTime);
            Assert.AreEqual(expect.ReminderTimeType, actual.ReminderTimeType);
            Assert.AreEqual(expect.ReminderType, actual.ReminderType);
            Assert.AreEqual(expect.RepeatingType, actual.RepeatingType);
        }

        private static MeetingDto createBaseMeetingDto(DateTime startDate,int duration)
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
                Reminder = new ReminderDto
                {
                    CustomReminderTime = 10,
                    ReminderTimeType = ReminderTimeType.OnTime,
                    ReminderType = ReminderType.TelegramMessage,
                    RepeatingType = RepeatingType.Weekly
                },
                Attendees = "ehsan mohammadi,reza akbari, davood shokri,mohammad reza bayat",
            };
            return dto;

        }

        public static void CreateWorkingMeeting(DateTime startDate, int duration)
        {
            var dto = createBaseMeetingDto(startDate,duration);
            dto.MeetingType = (int)MeetingType.Working;
            var controller = ServiceLocator.Current.GetInstance<MeetingsController>();
            controller.PostMeeting(dto);
        }

        public static void CreateNoneWorkingMeeting(DateTime startDate, int duration)
        {
            var dto = createBaseMeetingDto(startDate, duration);
            dto.MeetingType = (int)MeetingType.NonWorking;
            var controller = ServiceLocator.Current.GetInstance<MeetingsController>();
            controller.PostMeeting(dto);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void GetAllMeeting()
        {

            #region Arrange

            //for (int i = 2; i <6; i++)
            //{
                CreateWorkingMeeting(DateTime.Now.AddHours(1),1);
            //}
            //for (int i = 6; i < 10; i++)
            //{
                CreateNoneWorkingMeeting(DateTime.Now.AddHours(5), 1);
            //}

            #endregion

            #region Act

            var controller = ServiceLocator.Current.GetInstance<MeetingsController>();
            var meetings = controller.GetAll();

            #endregion

            #region Assert

            Assert.AreEqual(2, meetings.Count);

            #endregion

        }

        [TestMethod]
        public void Get_Should_GetWorkingMeeting_with_BaseAttribute_Remminder_Decisions_Files()
        {
            #region Arrange
            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            CreateWorkingMeeting(DateTime.Now,1);
            var currentMeeting = actionController.GetAll().First();
            currentMeeting.Decisions = "this is test decision for our project";
            currentMeeting.Details = "this test details creation for our project";
            currentMeeting.Files = new List<FileDto>
            {
                new FileDto
                {
                    ContentType = ".jpeg",
                    Content = Utility.Base64ConvertedFile
                },
                new FileDto
                {
                    ContentType = ".jpeg",
                    Content = Utility.Base64ConvertedFile
                }
            };

            actionController.PutMeeting(currentMeeting);

            #endregion

            #region Act



            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var resultDto = assertController.Get(currentMeeting.Id);
            if (resultDto.Id == 0)
                Assert.Fail("Id is not set");

            AreEqual_BaseMeetingDto(currentMeeting, resultDto);
            AreEqual_ReminderDto(currentMeeting.Reminder, resultDto.Reminder);
            AreEqual_WorkingMeetingDto(currentMeeting, resultDto);
            if (resultDto.Files.Count != 2)
                Assert.Fail("File saving is not correct");


            #endregion

        }

        [TestMethod]
        public void Post_Should_CreateWorkingMeeting_with_BaseAttribute_Remminder()
        {
            #region Arrange

            var dto = createBaseMeetingDto(DateTime.Now,1);
            dto.MeetingType = (int)MeetingType.Working;

            #endregion

            #region Act

            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            actionController.PostMeeting(dto);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var resultDto = assertController.GetAll().Single();
            if (resultDto.Id == 0)
                Assert.Fail("Id is not set");

            AreEqual_BaseMeetingDto(dto, resultDto);
            AreEqual_ReminderDto(dto.Reminder, resultDto.Reminder);


            #endregion

        }

        [TestMethod]
        public void Post_Should_CreateNoneWorkingMeeting_with_BaseAttribute_Remminder()
        {
            #region Arrange

            var dto = createBaseMeetingDto(DateTime.Now, 1);
            dto.MeetingType = (int)MeetingType.NonWorking;

            #endregion

            #region Act

            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            actionController.PostMeeting(dto);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var resultDto = assertController.GetAll().Single();
            if (resultDto.Id == 0)
                Assert.Fail("Id is not set");

            AreEqual_BaseMeetingDto(dto, resultDto);
            AreEqual_ReminderDto(dto.Reminder, resultDto.Reminder);


            #endregion

        }

        [TestMethod]
        public void Put_Should_ModifyNoneWorkingMeeting_with_BaseAttribute_Remminder()
        {
            #region Arrange
            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            CreateNoneWorkingMeeting(DateTime.Now, 1);
            var currentMeeting = actionController.GetAll().First();

            #endregion

            #region Act

            currentMeeting.StartDate = DateTime.Now.AddDays(3).AddMinutes(4);
            currentMeeting.Subject = "New Subject";
            currentMeeting.Description = "new desciption";
            currentMeeting.Attendees = "new attendees";
            currentMeeting.Duration = 4;
            currentMeeting.Agenda = "new agenda text";
            currentMeeting.LocationAddress = "new Location";
            currentMeeting.LocationLongitude = 6.444444444;
            currentMeeting.LocationLatitude = 3.44444;

            actionController.PutMeeting(currentMeeting);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var resultDto = assertController.GetAll().Single();
            if (resultDto.Id == 0)
                Assert.Fail("Id is not set");

            AreEqual_BaseMeetingDto(currentMeeting, resultDto);
            AreEqual_ReminderDto(currentMeeting.Reminder, resultDto.Reminder);


            #endregion

        }

        [TestMethod]
        public void Put_Should_Modify_Reminder_Meeting()
        {
            #region Arrange
            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            CreateWorkingMeeting(DateTime.Now, 1);
            var currentMeeting = actionController.GetAll().First();

            #endregion

            #region Act
            var newReminder = new ReminderDto
            {
                CustomReminderTime = 3,
                ReminderTimeType = ReminderTimeType.Even10M,
                ReminderType = ReminderType.ShortMessage,
                RepeatingType = RepeatingType.Yearly
            };
            currentMeeting.Reminder = newReminder;
            actionController.PutMeeting(currentMeeting);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var resultDto = assertController.GetAll().Single();

            AreEqual_ReminderDto(newReminder, resultDto.Reminder);

            #endregion

        }

        [TestMethod]
        public void Put_Should_ModifyWorkingMeeting_with_BaseAttribute_Remminder()
        {
            #region Arrange
            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            CreateWorkingMeeting(DateTime.Now, 1);
            var currentMeeting = actionController.GetAll().First();

            #endregion

            #region Act

            currentMeeting.StartDate = DateTime.Now.AddDays(3).AddMinutes(4);
            currentMeeting.Subject = "New Subject";
            currentMeeting.Description = "new desciption";
            currentMeeting.Attendees = "new attendees";
            currentMeeting.Duration = 4;
            currentMeeting.Agenda = "new agenda text";
            currentMeeting.LocationAddress = "new Location";
            currentMeeting.LocationLongitude = 6.444444444;
            currentMeeting.LocationLatitude = 3.44444;

            actionController.PutMeeting(currentMeeting);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var resultDto = assertController.GetAll().Single();
            if (resultDto.Id == 0)
                Assert.Fail("Id is not set");

            AreEqual_BaseMeetingDto(currentMeeting, resultDto);
            AreEqual_ReminderDto(currentMeeting.Reminder, resultDto.Reminder);


            #endregion

        }


        [TestMethod]
        public void Put_Should_ModifyWorkingMeeting_with_Decision_Details_Files()
        {
            #region Arrange
            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            CreateWorkingMeeting(DateTime.Now, 1);
            var currentMeeting = actionController.GetAll().First();

            #endregion

            #region Act

            currentMeeting.Decisions = "this is test decision for our project";
            currentMeeting.Details = "this test details creation for our project";
            currentMeeting.Files = new List<FileDto>
            {
                new FileDto
                {
                    ContentType = ".jpeg",
                    Content = Utility.Base64ConvertedFile
                },
                new FileDto
                {
                    ContentType = ".jpeg",
                    Content = Utility.Base64ConvertedFile
                }
            };

            actionController.PutMeeting(currentMeeting);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var resultDto = assertController.GetAll().Single();
            if (resultDto.Id == 0)
                Assert.Fail("Id is not set");

            AreEqual_BaseMeetingDto(currentMeeting, resultDto);
            AreEqual_ReminderDto(currentMeeting.Reminder, resultDto.Reminder);
            AreEqual_WorkingMeetingDto(currentMeeting, resultDto);
            if (resultDto.Files.Count != 2)
                Assert.Fail("File saving is not correct");



            #endregion

        }

        [TestMethod]
        public void Put_Should_Modify_Files_WorkingMeeting()
        {
            #region Arrange
            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            CreateWorkingMeeting(DateTime.Now, 1);
            var currentMeeting = actionController.GetAll().First();
            currentMeeting.Decisions = "this is test decision for our project";
            currentMeeting.Details = "this test details creation for our project";
            currentMeeting.Files = new List<FileDto>
            {
                new FileDto
                {
                    ContentType = ".jpeg",
                    Content = Utility.Base64ConvertedFile
                },
                new FileDto
                {
                    ContentType = ".jpeg",
                    Content = Utility.Base64ConvertedFile
                }
            };

            actionController.PutMeeting(currentMeeting);

            #endregion

            #region Act

            currentMeeting.Files = new List<FileDto>
            {
                new FileDto
                {
                    ContentType = ".x",
                    Content = Utility.Base64ConvertedFile
                }
            };

            actionController.PutMeeting(currentMeeting);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var resultDto = assertController.GetAll().Single();

            if (resultDto.Files.Count != 1)
                Assert.Fail("File saving is not correct");
            AreEqual_FileDto(currentMeeting.Files.First(), resultDto.Files.First());

            #endregion

        }


        [TestMethod]
        public void Put_Should_Modify_StartDate_Duration_with_changing_state_to_Transfered_With_approvedState()
        {
            #region Arrange
            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            CreateWorkingMeeting(DateTime.Now, 1);
            var currentMeeting = actionController.GetAll().First();

            #endregion

            #region Act

            currentMeeting.StartDate=DateTime.Now.AddDays(1);
            currentMeeting.Duration = 1;
            actionController.PutMeeting(currentMeeting);

            #endregion

            #region Assert

            var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var actualMeeting = assertController.GetAll().Single();
            AreEqual_State(MeetingStateEnum.Approved, currentMeeting);
            AreEqual_State(MeetingStateEnum.Transferred, actualMeeting);

           // AreEqual_ReminderDto(newReminder, resultDto.Reminder);

            #endregion

        }


        [TestMethod]
        public void PostMeetings_SyncFromDevice_Should_CreateMeeting_Working_Or_NoneWorking_ByAndriod()
        {
            #region Arrange

            var workingMeetingDto = createBaseMeetingDto(DateTime.Now, 1);
            workingMeetingDto.MeetingType = (int)MeetingType.Working;

            var noneWorkingMeetingDto = createBaseMeetingDto(DateTime.Now.AddHours(4), 1);
            noneWorkingMeetingDto.MeetingType = (int)MeetingType.NonWorking;

            var meetingSyncRequest = new MeetingSyncRequest
            {
                AppType = (int)AppType.AndriodApp,
                Items = new List<MeetingSyncItem>
                {
                    new MeetingSyncItem
                    {
                        Meeting = workingMeetingDto,
                        SyncId = Guid.NewGuid(),
                        ActionType = (int)EntityActionType.Create
                    },
                    new MeetingSyncItem
                    {
                        Meeting = noneWorkingMeetingDto,
                        SyncId = Guid.NewGuid(),
                        ActionType = (int)EntityActionType.Create
                    }
                }
            }; 

            #endregion

            #region Act

            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            actionController.PostMeetings(meetingSyncRequest, "forEhsan"); 

            #endregion

            #region Assert
            var context=new RMSContext();
            
           // var assertController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var actualMembers = context.Meetings.ToList();

            if(actualMembers.Count!=2)
                Assert.Fail("it didnt create by sync correctly");
            if(actualMembers.Count(r=>meetingSyncRequest.Items.Select(i=>i.SyncId).Contains(r.SyncId))!=2)
                Assert.Fail("Sync Id didnt set correctly");
            if (actualMembers.Count(r => r.ActionType==EntityActionType.Create)!=2)
                Assert.Fail("ActionType didnt set correctly");
            if(actualMembers.Count(r => r.SyncedWithAndriodApp)!=2)
                Assert.Fail("Sync with andriod didnt set correctly");


            #endregion

        }


        [TestMethod]
        public void GetAllByDeviceType_Should_GetAllUnSyncedFor_AndriodApp_SetSync_By_AndriodApp()
        {
            #region Arrange

            CreateWorkingMeeting(DateTime.Now, 1);
            CreateNoneWorkingMeeting(DateTime.Now.AddHours(4), 1); 

            #endregion

            #region Act

            var actionController=ServiceLocator.Current.GetInstance<MeetingsController>();
            var result=actionController.GetAll((int)AppType.AndriodApp);

            #endregion

            #region Assert

            var context = new RMSContext();
            var actualMembers = context.Meetings.ToList();

            if (actualMembers.Count != 2)
                Assert.Fail("it didnt create by sync correctly");

            if (actualMembers.Count(r => r.SyncedWithAndriodApp) != 2)
                Assert.Fail("Sync with andriod didnt set correctly");

            #endregion
        }

        [TestMethod]
        public void PostMeetings_SyncFromDevice_Should_ModifyMeeting_Working_Or_NoneWorking_ByAndriod_WithCreationSyncing()
        {
            #region Arrange

            var workingMeetingDto = createBaseMeetingDto(DateTime.Now, 1);
            workingMeetingDto.MeetingType = (int)MeetingType.Working;

            var noneWorkingMeetingDto = createBaseMeetingDto(DateTime.Now.AddHours(4), 1);
            noneWorkingMeetingDto.MeetingType = (int)MeetingType.NonWorking;

            var meetingSyncRequest = new MeetingSyncRequest
            {
                AppType = (int)AppType.AndriodApp,
                Items = new List<MeetingSyncItem>
                {
                    new MeetingSyncItem
                    {
                        Meeting = workingMeetingDto,
                        SyncId = Guid.NewGuid(),
                        ActionType = (int)EntityActionType.Create
                    },
                    new MeetingSyncItem
                    {
                        Meeting = noneWorkingMeetingDto,
                        SyncId = Guid.NewGuid(),
                        ActionType = (int)EntityActionType.Create
                    }
                }
            };
            var arrangeController = ServiceLocator.Current.GetInstance<MeetingsController>();
            arrangeController.PostMeetings(meetingSyncRequest, "forEhsan");

            #endregion

            #region Act

            var expectedModifiedMeeting = meetingSyncRequest.Items.First();
            expectedModifiedMeeting.ActionType = (int)EntityActionType.Modify;
            expectedModifiedMeeting.Meeting.Decisions = "ksldfsdfsdfsdf";
            expectedModifiedMeeting.Meeting.Files = new List<FileDto>
            {
                new FileDto
                {
                    ContentType = ".x",
                    Content = Utility.Base64ConvertedFile
                }
            };

            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            actionController.PostMeetings(new MeetingSyncRequest
            {
                AppType = (int) AppType.AndriodApp,
                Items = new List<MeetingSyncItem>
                {
                    expectedModifiedMeeting
                }
            }, "ehsan");

            #endregion

            #region Assert

            //var context = new RMSContext();
            //var actualMembers = context.Meetings.ToList();

            //if (actualMembers.Count != 2)
            //    Assert.Fail("it didnt create by sync correctly");
            //if (actualMembers.Count(r => meetingSyncRequest.Items.Select(i => i.SyncId).Contains(r.SyncId)) != 2)
            //    Assert.Fail("Sync Id didnt set correctly");
            //if (actualMembers.Count(r => r.ActionType == EntityActionType.Create) != 2)
            //    Assert.Fail("ActionType didnt set correctly");
            //if (actualMembers.Count(r => r.SyncedWithAndriodApp) != 2)
            //    Assert.Fail("Sync with andriod didnt set correctly");

            #endregion

        }


        [TestMethod]
        public void Addfile_to_Meeting_and_modify_File_in_andriod_Must_Work_Correctly()
        {
            #region Arrange
            //Create meeting by web with file
            var actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            CreateWorkingMeeting(DateTime.Now.AddHours(4), 1);
            var currentMeeting = actionController.GetAll().First();
            currentMeeting.Decisions = "this is test decision for our project";
            currentMeeting.Details = "this test details creation for our project";
            currentMeeting.Files = new List<FileDto>
            {
                new FileDto
                {
                    ContentType = ".jpeg",
                    Content = "File 1 From Web"
                },
                new FileDto
                {
                    ContentType = ".kk",
                    Content = "File 2 From Web"
                }
            };

            actionController.PutMeeting(currentMeeting);
            // Get By andriod 
            actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var result = actionController.GetAll((int)AppType.AndriodApp);


            #endregion

           
            #region Act
            // Post Modified Meeting with fileList change from andriod
            var modifiedMeeting = result.First().Meeting;
            modifiedMeeting.Files.Remove(modifiedMeeting.Files.First());
            modifiedMeeting.Files.Add(new FileDto
            {
                ContentType = ".ss",
                Content = "File from Andriod"
            });


            var meetingSyncRequest = new MeetingSyncRequest
            {
                AppType = (int)AppType.AndriodApp,
                Items = new List<MeetingSyncItem>
                {
                    new MeetingSyncItem
                    {
                        Meeting = modifiedMeeting,
                        SyncId = result.First().SyncId,
                        ActionType = (int)EntityActionType.Modify
                    }
                }
            };
            actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            actionController.PostMeetings(meetingSyncRequest, "SyncByMe"); 
            #endregion

            #region Assert
            //Get result 
            actionController = ServiceLocator.Current.GetInstance<MeetingsController>();
            var finalResult = actionController.GetAll(); 
            #endregion







        }

        #endregion
    }
}
