using System;

namespace BTE.RMS.Model.Meetings.MeetingStates.States
{
    public class MeetingScheduledState:MeetingState
    {
        public MeetingScheduledState()
            : base("MeetingScheduledState", "1")
        {
        }

        public override void Approve(Meeting meeting)
        {
            meeting.State = Approved;
        }

        public override void Transfer(Meeting meeting, DateTime startDate, int duration)
        {
            meeting.SetMeetingDateTime(startDate, duration);
            meeting.State = MeetingState.Transferred;
        }
    }
}
