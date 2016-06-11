using AutoMapper;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Files;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Model.Meetings;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.RMSFiles;
using BTE.RMS.Services.Contract;
using BTE.RMS.Services.Contract.Meetings;

namespace BTE.RMS.Interface
{
    public static class RMSMapper
    {
        private static readonly MapperConfiguration config;
        static RMSMapper()
        {
            config = new MapperConfiguration(cfg =>
            {
                #region Map DomainModel to DTO

                cfg.CreateMap<Meeting, MeetingDto>()
                    .ForMember(dto => dto.MeetingType,
                               m =>m.MapFrom(dm =>dm.GetType() == typeof (NoneWorkingMeeting)? MeetingType.NonWorking: MeetingType.Working))
                    .ForMember(dto => dto.Decisions, 
                               m => m.MapFrom(dm =>dm.GetType() == typeof(WorkingMeeting) ? (dm as WorkingMeeting).Decisions : string.Empty))
                    .ForMember(dto => dto.Details, 
                                m => m.MapFrom(dm => dm.GetType() == typeof(WorkingMeeting) ? (dm as WorkingMeeting).Details : string.Empty));

                cfg.CreateMap<Meeting, MeetingSyncItem>()
                    .ForMember(ms=>ms.Meeting,mm=>mm.MapFrom(s=>s));

                cfg.CreateMap<Reminder, ReminderDto>();

                cfg.CreateMap<RMSFile, FileDto>();

                #endregion

                #region Map DTO to command
                cfg.CreateMap<MeetingDto, CreateWorkingMeetingCmd>();
                cfg.CreateMap<MeetingDto, CreateNonWorkingMeetingCmd>();
                cfg.CreateMap<MeetingDto, ModifyWorkingMeetingCmd>();
                cfg.CreateMap<MeetingDto, ModifyNonWorkingMeetingCmd>();
                cfg.CreateMap<ReminderDto, CreateReminderCommand>();
                cfg.CreateMap<FileDto, CreateFileCmd>(); 
                #endregion
            

            });

        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper=config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
