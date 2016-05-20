using BTE.Core;

namespace BTE.RMS.Services.Contract.Meetings
{
    public interface IMeetingService:IService
    {
        void CreateWorkingMeeting(CreateWorkingMeetingCmd command);
        void CreateNonWorkingMeeting(CreateNonWorkingMeetingCmd command);
    }
}
