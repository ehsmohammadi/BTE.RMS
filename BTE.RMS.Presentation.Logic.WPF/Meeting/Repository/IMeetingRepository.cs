using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Core;
using BTE.RMS.Presentation.Logic.Meeting.Model;

namespace BTE.RMS.Presentation.Logic.Meeting.Repository
{
    public interface IMeetingRepository:IRepository,IRepository<MeetingDB>
    {
        List<MeetingDB> GetMeetings();
        List<MeetingDB> GetMeetings(DateTime startTime);
    }
}
