using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Services.Contract.Meetings;

namespace BTE.RMS.Services
{
    public class MeetingService : IMeetingService
    {
        #region Fields
        private readonly IMeetingRepository meetingRepository;
        private readonly IAttendeeRepository attendeeRepository;

        #endregion

        #region Constructors
        public MeetingService(IMeetingRepository meetingRepository,IAttendeeRepository attendeeRepository)
        {
            this.meetingRepository = meetingRepository;
            this.attendeeRepository = attendeeRepository;
        }

        #endregion

        #region Public methods
        public void CreateWorkingMeeting(CreateWorkingMeetingCmd command)
        {
            var attendees = attendeeRepository.FindAttendeesById(command.Attendees);
            //todo: location must be created inside bse meeting  class
            var location = new Location(command.Address, command.Latitude, command.Longitude);
            var meeting = new WorkingMeeting(command.Subject, command.StartDate, command.Duration, command.Description,
                location, attendees);
            meetingRepository.Create(meeting);
        }

        public void CreateNonWorkingMeeting(CreateNoneWorkingMeetingCmd command)
        {
            var attendees = attendeeRepository.FindAttendeesById(command.Attendees);
            //todo: location must be created inside bse meeting  class
            var location = new Location(command.Address, command.Latitude, command.Longitude);
            var meeting = new NoneWorkingMeeting(command.Subject, command.StartDate, command.Duration, command.Description,
                location, attendees);
            meetingRepository.Create(meeting);
        } 
        #endregion

       
    }



}
