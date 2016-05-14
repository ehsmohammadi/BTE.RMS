using System;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract;

namespace BTE.RMS.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository meetingRepository;

        public MeetingService(IMeetingRepository meetingRepository)
        {
            this.meetingRepository = meetingRepository;
        }

        public void Create(string subject, DateTime startDate, int duration, string location, string attendees, string description)
        {
            var meeting = new Meeting(subject, startDate, duration, description, location, attendees);
            meetingRepository.Create(meeting);
        }
    }



}
