using System;
using System.Collections.Generic;
using System.IO;
using BTE.Core;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Files;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Model;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface IMeetingFacadeService : IFacadeService
    {
        void Create(MeetingDto meetingModel, AppType appType, Guid syncId);
        void Modify(MeetingDto meetingModel, AppType appType, Guid syncId);
        void Delete(MeetingDto dto, AppType appType,Guid syncId);
        void Approve(long meetingId, Guid syncId);
        void Hold(long meetingId, Guid syncId);
        void Cancel(long meetingId, Guid syncId);

        MeetingDto GetBy(long id);
        List<MeetingDto> GetAll();


        IEnumerable<MeetingSyncItem> GetAllUnSync(int deviceType);
        void Sync(MeetingSyncRequest syncReuest);
        IList<MeetingDto> GetAll(DateTime startDate);


        List<MeetingHistoryDto> GetMeetingHistories(long meetingId);
    }
}
