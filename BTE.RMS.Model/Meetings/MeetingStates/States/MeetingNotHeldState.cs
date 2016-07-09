using System;

namespace BTE.RMS.Model.Meetings.MeetingStates.States
{
    public class MeetingNotHeldState:MeetingState
    {
        public MeetingNotHeldState()
            : base("MeetingNotHeldState", "6")
        {
        }

        public override void Transfer(Meeting meeting, DateTime startDate, int duration)
        {
            if (!meeting.IsMeetingDateTimeChanged(startDate, duration)) return;
            meeting.SetMeetingDateTime(startDate, duration);
            meeting.State = MeetingState.Transferred;
        }

        public override void Cancel(Meeting meeting)
        {
            meeting.State = MeetingState.Canceled;
        }

    }
}
