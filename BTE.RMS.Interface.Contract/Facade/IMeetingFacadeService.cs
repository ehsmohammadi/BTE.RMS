using BTE.Core;
using BTE.RMS.Interface.Contract.Model.Meeting;
using System.Collections.Generic;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface IMeetingFacadeService :IFacadeService
    {
        void Create(MeetingModel meetingModel);
        List<MeetingModel> GetAll();
    }
}
