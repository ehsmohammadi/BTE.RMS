using System;

namespace BTE.RMS.Model.Meetings.MeetingStates.States
{
    public class MeetingApprovedState : MeetingState
    {
        public MeetingApprovedState()
            : base("MeetingApprovedState", "2")
        {
        }

        public override void Hold(Meeting meeting)
        {
            meeting.State = MeetingState.Held;

        }

        public override void Cancel(Meeting meeting)
        {
            meeting.State = MeetingState.Canceled;
        }

        public override void Transfer(Meeting meeting, DateTime startDate, int duration)
        {
            meeting.SetMeetingDateTime(startDate, duration);
            meeting.State = MeetingState.Transferred;
        }
    }
}
