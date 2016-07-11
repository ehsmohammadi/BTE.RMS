using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Common;

namespace BTE.RMS.Interface.Contract.Meetings
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
        IList<MeetingDto> GetAll(DateTime startDate);
        List<MeetingHistoryDto> GetMeetingHistories(long meetingId);
        List<MeetingHistoryDto> GetMeetingHistories(AppType meetingId, Guid syncId);


        IEnumerable<MeetingSyncItem> GetAllUnSync(int deviceType);
        void Sync(MeetingSyncRequest syncReuest);




    }
}
