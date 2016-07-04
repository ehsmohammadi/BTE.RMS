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
           // meeting.State = Approved;
        }
    }
}
