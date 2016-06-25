using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Core;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public class MeetingValidationService:IMeetingValidationService
    {
        private readonly IMeetingRepository meetingRepository;

        public MeetingValidationService(IMeetingRepository meetingRepository)
        {
            this.meetingRepository = meetingRepository;
        }

        public void ValidateStartDateAndDuration(Meeting meeting, DateTime startDate, int duration)
        {
            var res = meetingRepository.GetMeetinginDuration(startDate, duration,meeting.CreatorUser);
            if (res.Any(m => m.Id!=meeting.Id))
                throw new DuplicateException("Time Of meeting id dublicated", "Meeting", "StartDate , Duration");
        }
    }
}
