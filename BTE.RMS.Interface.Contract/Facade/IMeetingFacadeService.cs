using BTE.Core;
using System.Collections.Generic;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Model.Meetings;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface IMeetingFacadeService :IFacadeService
    {
        void Create(MeetingDto meetingModel,AppType appType);
        void Modify(MeetingDto meetingModel, AppType appType);
        MeetingDto GetBy(long id);
        List<MeetingDto> GetAll();


        IEnumerable<MeetingDto> GetAllUnSync(int deviceType);
        void Sync(MeetingSyncRequest syncReuest);
        
    }
}
