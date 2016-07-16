using System.Linq;

namespace BTE.RMS.Model.Meetings.MeetingStates.States
{
    public class MeetingHeldState:MeetingState
    {
        public MeetingHeldState()
            : base("MeetingHeldState", "3")
        {
        }

        public override void Revert(Meeting meeting)
        {
            var meetingHistory = meeting.MeetingHistories.OrderByDescending(m => m.OperationDate).FirstOrDefault();
            if (meetingHistory != null)
            {
                meeting.State = (int) meetingHistory.CurrentState;
            }
        }
    }
}