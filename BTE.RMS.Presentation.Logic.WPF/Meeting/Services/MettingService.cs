using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Presentation.Logic.Meeting.Model;
using BTE.RMS.Presentation.Logic.Meeting.Repository;

namespace BTE.RMS.Presentation.Logic.Meeting.Services
{
    public class MeetingService:IMeetingService
    {
        
        private readonly IMeetingRepository repository;

        public void CreateMeeting(PrimaryMeeting meeting)
        {
            MeetingDB temp = Converter.ConvertToMeetingDb(meeting);
            repository.Create(temp);
        }

        public void UpdateMeeting(PrimaryMeeting meeting)
        {
            MeetingDB temp = Converter.ConvertToMeetingDb(meeting);
            repository.Update(temp);
        }

        public void DeleteMeeting(PrimaryMeeting meeting)
        {
            MeetingDB temp = Converter.ConvertToMeetingDb(meeting);
            repository.Delete(temp);
        }

        public MeetingService(IMeetingRepository repository)
        {
            this.repository = repository;
        }
    }
}
