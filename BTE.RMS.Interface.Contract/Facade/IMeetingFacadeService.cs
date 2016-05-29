using BTE.Core;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.Model.Meetings;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface IMeetingFacadeService :IFacadeService
    {
        void Create(MeetingDto meetingModel);
        List<MeetingDto> GetAll();
    }
}
