using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Meetings;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Services.Contract.Meetings;
using BTE.RMS.Services.Contract.Meetings.Commands;

namespace BTE.RMS.Interface
{
    public class MeetingFacadeService : IMeetingFacadeService
    {
        #region Fields
        private readonly IMeetingService meetingService;
        private readonly IMeetingRepository meetingRepository;
        #endregion

        #region Constructors
        public MeetingFacadeService(IMeetingService meetingService, IMeetingRepository meetingRepository)
        {
            this.meetingService = meetingService;
            this.meetingRepository = meetingRepository;
        }

        #endregion

        #region Methods
        public void Create(MeetingDto meetingModel,AppType appType)
        {
            var userName = ClaimsPrincipal.Current.Claims.Single(c=>c.Type=="Name").Value;
            switch ((MeetingType)meetingModel.MeetingType)
            {
                case MeetingType.Working:
                {
                    var command = new CreateWorkingMeetingCmd
                    {
                      
                        Subject = meetingModel.Subject,
                        StartDate = meetingModel.StartDate,
                        Duration = meetingModel.Duration,
                        AttendeesName = meetingModel.AttendeesName,
                        Latitude = meetingModel.Latitude,
                        Longitude = meetingModel.Longitude,
                        Description = meetingModel.Description,
                        Address = meetingModel.Address,
                        //Reminder = meetingModel.Reminder.Select(r =>
                        //    new CreateReminderCommand
                        //    {
                        //        RemindTypes = r.RemindTypes,
                        //        RemindeTime = r.RemindeTime,
                        //        RepeatingType = r.RepeatingType
                        //    }).ToList(),
                        Agenda = meetingModel.Agenda,
                        AppType = appType,
                        CreatorUserName = userName,
                        

                    };
                    meetingService.CreateWorkingMeeting(command);
                }
                    break;
                case MeetingType.NonWorking:
                {
                    var command = new CreateNonWorkingMeetingCmd
                    {
                        Subject = meetingModel.Subject,
                        StartDate = meetingModel.StartDate,
                        Duration = meetingModel.Duration,
                        AttendeesName = meetingModel.AttendeesName,
                        Latitude = meetingModel.Latitude,
                        Longitude = meetingModel.Longitude,
                        Description = meetingModel.Description,
                        Address = meetingModel.Address,
                        //Reminder = meetingModel.Reminder.Select(r =>
                        //    new CreateReminderCommand
                        //    {
                        //        RemindTypes = r.RemindTypes,
                        //        RemindeTime = r.RemindeTime,
                        //        RepeatingType = r.RepeatingType
                        //    }).ToList(),
                        Agenda = meetingModel.Agenda,
                        AppType = appType,
                        CreatorUserName = userName,
                    };
                    meetingService.CreateNonWorkingMeeting(command);
                }
                    break;
                default:
                    throw new Exception("MeetingType is not set correctlly");
            }
        }

        public List<MeetingDto> GetAll()
        {
            var userName = ClaimsPrincipal.Current.Claims.Single(c => c.Type == "Name").Value;
            var res = meetingRepository.GetAllByUserName(userName);
            return res.Select(RMSMapper.Map<Meeting, MeetingDto>).ToList();
        }
        #endregion

        #region Sync methods
        public IEnumerable<MeetingDto> GetAllUnSync(int deviceType)
        {
            var userName = ClaimsPrincipal.Current.Claims.Single(c => c.Type == "Name").Value;
            if (deviceType == 0)
                throw new ArgumentException("deviceType not set correctlly", "deviceType");
            //todo:Change this section , decision mut not be set in this layer
            switch ((AppType)deviceType)
            {
                case AppType.AndriodApp:
                    {
                        var res = meetingRepository.GetAllUnsyncForAndroidAppByCreator(userName).ToList();
                        meetingService.SyncWithAndriodApp(res);
                        return res.Select(RMSMapper.Map<Meeting, MeetingDto>).ToList();
                    }
                case AppType.DesktopApp:
                    {
                        var res = meetingRepository.GetAllUnsyncForDesktopAppByCreator(userName).ToList();
                        meetingService.SyncWithDesktopApp(res);
                        return res.Select(RMSMapper.Map<Meeting, MeetingDto>).ToList();
                    }
                case AppType.All:
                    {
                        var res = meetingRepository.GetAll();
                        return res.Select(RMSMapper.Map<Meeting, MeetingDto>).ToList();
                    }
                default:
                    return null;
            }
        }

        public void Sync(MeetingSyncRequest syncReuest)
        {
            if (syncReuest == null)
                throw new ArgumentException("syncRequest can't be null", "syncReuest");
            var appType = (AppType)syncReuest.AppType;
            foreach (var syncItem in syncReuest.Items)
            {
                if (syncItem.ActionType == (int) EntityActionType.Create)
                    Create(syncItem.Meeting, appType);
                if (syncItem.ActionType == (int)EntityActionType.Modify)
                {
                    //var meetingCommand = RMSMapper.Map<CrudTaskItem, UpdateTaskCommand>(syncItem.Meeting);
                    //meetingCommand.AppType = appType;
                    //meetingService.UpdateTask(meetingCommand);
                   // Modify(syncItem.Meeting);

                }
                if (syncItem.ActionType == (int)EntityActionType.Delete)
                {
                    //var meetingCommand = RMSMapper.Map<CrudTaskItem, DeleteTaskCommand>(syncItem.Meeting);
                    //meetingCommand.AppType = appType;
                    //meetingService.DeleteTask(meetingCommand); 
                    //Delete(syncItem.Meeting);
                }

            }
        }
        #endregion
    }
}
