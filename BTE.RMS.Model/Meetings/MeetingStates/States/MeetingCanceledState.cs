using System;

namespace BTE.RMS.Model.Meetings.MeetingStates.States
{
    public class MeetingCanceledState:MeetingState
    {
        public MeetingCanceledState()
            : base("MeetingCanceledState", "4")
        {
        }

        public override void Transfer(Meeting meeting, DateTime startDate, int duration)
        {
            if (!meeting.IsMeetingDateTimeChanged(startDate, duration)) return;
            meeting.SetMeetingDateTime(startDate, duration);
            meeting.State = MeetingState.Transferred;
        }

    }
}
