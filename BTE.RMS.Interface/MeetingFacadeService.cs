using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.Model.Meetings;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Services.Contract.Meetings;
using BTE.RMS.Services.Contract.Meetings.Commands;

namespace BTE.RMS.Interface
{
    public class MeetingFacadeService : IMeetingFacadeService
    {
        private readonly IMeetingService meetingService;
        private readonly IMeetingRepository meetingRepository;

        public MeetingFacadeService(IMeetingService meetingService, IMeetingRepository meetingRepository)
        {
            this.meetingService = meetingService;
            this.meetingRepository = meetingRepository;
        }

        public void Create(MeetingDto meetingModel)
        {
            //todo:why this shit is here if logic in facade service 
            if (meetingModel.MeetingType == MeetingType.Working)
            {
                var command = RMSMapper.Map<MeetingDto, CreateWorkingMeetingCmd>(meetingModel);
                meetingService.CreateWorkingMeeting(command);
            }
            else if (meetingModel.MeetingType == MeetingType.NonWorking)
            {
                var command = new CreateNonWorkingMeetingCmd
                {
                    Subject = meetingModel.Subject,
                    Progress = meetingModel.Progress,
                    StartDate = meetingModel.StartDate,
                    Duration = meetingModel.Duration,
                    Attendees = meetingModel.Attendees,
                    Latitude = meetingModel.Latitude,
                    Longitude = meetingModel.Longitude,
                    Description = meetingModel.Description,
                    Address = meetingModel.Address,
                    Reminder = meetingModel.Reminder.Select(r =>
                        new CreateReminderCommand
                        {
                            RemindTypes = r.RemindTypes,
                            RemindeTime = r.RemindeTime,
                            RepeatingType = r.RepeatingType
                        }).ToList(),
                    Agenda = meetingModel.Agenda,
                };
                //var command=RMSMapper.Map<MeetingDto, CreateNonWorkingMeetingCmd>(meetingModel);
                meetingService.CreateNonWorkingMeeting(command);
            }
            throw new Exception("MeetingType is not set correctlly");

        }

        public List<MeetingDto> GetAll()
        {
            var res = meetingRepository.GetAll();
            return res.Select(RMSMapper.Map<Meeting, MeetingDto>).ToList();
        }
    }
}
