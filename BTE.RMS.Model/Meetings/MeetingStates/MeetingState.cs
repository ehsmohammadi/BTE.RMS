using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Model.Meetings.MeetingStates.States;

namespace BTE.RMS.Model.Meetings.MeetingStates
{
    public abstract class MeetingState
    {
        public static MeetingState New=new MeetingNewState();
        public static MeetingState Approved=new MeetingApprovedState();
        public MeetingState(string name,string value)
        {
            
        }
        internal virtual void Approve(Meeting meeting)
        {
            throw new Exception("Access Deniad");
        }

        //internal virtual void Rejecte()
        //{
        //    throw new Exception("Access Deniad");
        //}

        //internal virtual void Inactive()
        //{
        //    throw new Exception("Access Deniad");
        //}
    }
}
