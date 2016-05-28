using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Model.Meetings.MeetingStates.States
{
    public class MeetingNewState:MeetingState
    {
        public MeetingNewState()
            : base("MeetingNewState", "1")
        {
        }
        internal override void Approve(Meeting meeting)
        {
            //meeting.MeetingState = MeetingState.Approved;
        }


    }
}
