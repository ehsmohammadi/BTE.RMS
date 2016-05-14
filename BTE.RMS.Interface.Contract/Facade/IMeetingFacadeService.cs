using BTE.Core;
using BTE.RMS.Interface.Contract.Model.Meeting;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface IMeetingFacadeService :IFacadeService
    {
        void Create(MeetingModel meetingModel);
    }
}
