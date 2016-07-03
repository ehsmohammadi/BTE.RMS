using System;
using BTE.Core;
using BTE.RMS.Model.Meetings.MeetingStates.States;

namespace BTE.RMS.Model.Meetings.MeetingStates
{
    public class MeetingState : Enumeration
    {

        public static MeetingState Scheduled = new MeetingScheduledState();
        public static MeetingState Approved = new MeetingApprovedState();
        public static MeetingState Held = new MeetingHeldState();
        public static MeetingState Canceled = new MeetingCanceledState();
        public static MeetingState Transferred = new MeetingTransferredState();
        public static MeetingState NotHeld = new MeetingNotHeldState();

        public MeetingState()
            : base()
        {
        }

        public MeetingState(string displayName, string value)
            : base(displayName, value)
        {
        }

        public static explicit operator int(MeetingState x)
        {
            if (x == null)
                throw new InvalidCastException();
            return Convert.ToInt32(x.Value);
        }
        public static implicit operator MeetingState(int val)
        {
            return FromValue<MeetingState>(val.ToString());
        }
    }
}
