using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Meetings;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface IMeetingFacadeService : IFacadeService
    {
        void Create(MeetingDto meetingModel, AppType appType);
        void Modify(MeetingDto meetingModel, AppType appType, Guid syncId);
        void Delete(MeetingDto dto, AppType appType,Guid syncId);
        MeetingDto GetBy(long id);
        List<MeetingDto> GetAll();


        IEnumerable<MeetingSyncItem> GetAllUnSync(int deviceType);
        void Sync(MeetingSyncRequest syncReuest);

    }
}
