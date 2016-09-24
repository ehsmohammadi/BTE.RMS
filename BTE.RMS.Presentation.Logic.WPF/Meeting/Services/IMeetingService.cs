using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Core;
using BTE.RMS.Presentation.Logic.Meeting.Model;

namespace BTE.RMS.Presentation.Logic.Meeting.Services
{
    public interface IMeetingService:IService
    {
        void CreateMeeting(PrimaryMeeting meeting);
        void UpdateMeeting(PrimaryMeeting meeting);
        void DeleteMeeting(PrimaryMeeting meeting);
    }
}
