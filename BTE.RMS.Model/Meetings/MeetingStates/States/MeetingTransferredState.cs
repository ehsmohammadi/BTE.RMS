using System;

namespace BTE.RMS.Model.Meetings.MeetingStates.States
{
    public class MeetingTransferredState:MeetingState
    {
        public MeetingTransferredState()
            : base("MeetingTransferredState", "5")
        {
        }

        public override void Transfer(Meeting meeting, DateTime startDate, int duration)
        {
            meeting.SetMeetingDateTime(startDate, duration);
            meeting.State = MeetingState.Transferred;
        }

        public override void Hold(Meeting meeting)
        {
            meeting.State = MeetingState.Held;

        }

        public override void Cancel(Meeting meeting)
        {
            meeting.State = MeetingState.Canceled;
        }

    }
}
