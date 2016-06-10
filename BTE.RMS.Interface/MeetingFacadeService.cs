using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Files;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Model;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Services.Contract.Meetings;

namespace BTE.RMS.Interface
{
    public class MeetingFacadeService : IMeetingFacadeService
    {
        #region Fields
        private readonly IMeetingService meetingService;
        private readonly IMeetingRepository meetingRepository;
        private readonly ISecurityService securityService;

        #endregion

        #region Constructors
        public MeetingFacadeService(IMeetingService meetingService, IMeetingRepository meetingRepository, ISecurityService securityService)
        {
            this.meetingService = meetingService;
            this.meetingRepository = meetingRepository;
            this.securityService = securityService;
        }

        #endregion

        #region Methods
        public List<MeetingDto> GetAll()
        {

            var userName = securityService.GetCurrentUserName();
            var res = meetingRepository.GetAllByUserName(userName);
            return Enumerable.ToList<MeetingDto>(res.Select(RMSMapper.Map<Meeting, MeetingDto>));
        }

        public void Create(MeetingDto meetingModel, AppType appType, Guid syncId)
        {
            var userName = securityService.GetCurrentUserName();
            switch ((MeetingType)meetingModel.MeetingType)
            {
                case MeetingType.Working:
                    {
                        var command = RMSMapper.Map<MeetingDto, CreateWorkingMeetingCmd>(meetingModel);
                        command.AppType = appType;
                        command.CreatorUserName = userName;
                        command.SyncId = syncId;
                        meetingService.CreateWorkingMeeting(command);
                    }
                    break;
                case MeetingType.NonWorking:
                    {
                        var command = RMSMapper.Map<MeetingDto, CreateNonWorkingMeetingCmd>(meetingModel);
                        command.AppType = appType;
                        command.CreatorUserName = userName;
                        command.SyncId = syncId;
                        meetingService.CreateNonWorkingMeeting(command);
                    }
                    break;
                default:
                    throw new Exception("MeetingType is not set correctlly");
            }
        }

        public void Modify(MeetingDto meetingModel, AppType appType,Guid syncId)
        {
            var userName = securityService.GetCurrentUserName();
            switch ((MeetingType)meetingModel.MeetingType)
            {
                case MeetingType.Working:
                    {
                        var command = RMSMapper.Map<MeetingDto, ModifyWorkingMeetingCmd>(meetingModel);
                        command.AppType = appType;
                        command.SyncId = syncId;
                        command.CreatorUserName = userName;
                        meetingService.ModifyWorkingMeeting(command);
                    }
                    break;
                case MeetingType.NonWorking:
                    {
                        var command = RMSMapper.Map<MeetingDto, ModifyNonWorkingMeetingCmd>(meetingModel);
                        command.AppType = appType;
                        command.SyncId = syncId;
                        command.CreatorUserName = userName;
                        meetingService.ModifyNonWorkingMeeting(command);
                    }
                    break;
                default:
                    throw new Exception("MeetingType is not set correctlly");
            }
        }

        public void Delete(MeetingDto dto, AppType appType,Guid syncId)
        {
            var userName = securityService.GetCurrentUserName();
            var command = new DeleteMeetingCmd(dto.Id, userName, appType, syncId);
            meetingService.Delete(command);

        }

        public MeetingDto GetBy(long id)
        {
            var userName = securityService.GetCurrentUserName();
            var res = meetingRepository.GetByUserName(userName, id);
            return RMSMapper.Map<Meeting, MeetingDto>(res);
        }

        #endregion

        #region Sync methods
        public IEnumerable<MeetingSyncItem> GetAllUnSync(int deviceType)
        {
            var userName = securityService.GetCurrentUserName();
            if (deviceType == 0)
                throw new ArgumentException("deviceType not set correctlly", "deviceType");
            //todo:Change this section , decision mut not be set in this layer
            switch ((AppType)deviceType)
            {
                case AppType.AndriodApp:
                    {
                        var result = new List<MeetingSyncItem>();
                        var res = meetingRepository.GetAllUnsyncForAndroidAppByCreator(userName).ToList();
                        meetingService.SyncWithAndriodApp(res);
                        foreach (var item in res)
                        {
                            if(item is WorkingMeeting)
                            {
                                var dto = RMSMapper.Map<WorkingMeeting, MeetingSyncItem>(item as WorkingMeeting);
                                dto.Meeting.Decisions = (item as WorkingMeeting).Decisions;
                                dto.Meeting.Details = (item as WorkingMeeting).Details;
                                result.Add(dto);
                            }
                            else
                            {
                                result.Add(RMSMapper.Map<NoneWorkingMeeting, MeetingSyncItem>(item as NoneWorkingMeeting));
                            }
                        }
                        return result;
                    }
                case AppType.DesktopApp:
                    {
                        var res = meetingRepository.GetAllUnsyncForDesktopAppByCreator(userName).ToList();
                        meetingService.SyncWithDesktopApp(res);
                        return Enumerable.ToList(res.Select(RMSMapper.Map<Meeting, MeetingSyncItem>));
                    }
                case AppType.All:
                    {
                        var res = meetingRepository.GetAll();
                        return Enumerable.ToList(res.Select(RMSMapper.Map<Meeting, MeetingSyncItem>));
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
                if (syncItem.ActionType == (int)EntityActionType.Create)
                    Create(syncItem.Meeting, appType,syncItem.SyncId);
                if (syncItem.ActionType == (int) EntityActionType.Modify)
                    Modify(syncItem.Meeting, appType, syncItem.SyncId);
                if (syncItem.ActionType == (int) EntityActionType.Delete)
                    Delete(syncItem.Meeting, appType,syncItem.SyncId);
            }
        }

        #endregion

    }

    
}
