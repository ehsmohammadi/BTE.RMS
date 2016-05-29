﻿using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Model.Meetings;

namespace BTE.RMS.Services.Contract.Meetings
{
    public interface IMeetingService:IService
    {
        void CreateWorkingMeeting(CreateWorkingMeetingCmd command);
        void CreateNonWorkingMeeting(CreateNonWorkingMeetingCmd command);
        void SyncWithAndriodApp(List<Meeting> meetings);
        void SyncWithDesktopApp(List<Meeting> meetings);
    }
}
