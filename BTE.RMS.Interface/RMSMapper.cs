using AutoMapper;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Model.Meetings;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.TaskCategories;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract;
using BTE.RMS.Services.Contract.Meetings;
using BTE.RMS.Services.Contract.Tasks;

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
                    .ForMember(m => 
                        m.MeetingType,s =>s.MapFrom(ss =>
                            ss.GetType() == typeof (NoneWorkingMeeting)? MeetingType.NonWorking: MeetingType.Working));
                cfg.CreateMap<Meeting, MeetingSyncItem>().ForMember(ms=>ms.Meeting,mm=>mm.MapFrom(s=>s));
                cfg.CreateMap<Reminder, ReminderDto>();

                #endregion

                #region Map DTO to command
                cfg.CreateMap<MeetingDto, CreateWorkingMeetingCmd>();
                cfg.CreateMap<MeetingDto, CreateNonWorkingMeetingCmd>();
                cfg.CreateMap<MeetingDto, ModifyWorkingMeetingCmd>();
                cfg.CreateMap<MeetingDto, ModifyNonWorkingMeetingCmd>();
                cfg.CreateMap<ReminderDto, CreateReminderCommand>(); 
                #endregion


                cfg.CreateMap<CrudTaskItem, CreateTaskCommand>();
                cfg.CreateMap<CrudTaskItem, UpdateTaskCommand>();

                cfg.CreateMap<Task, SummeryTaskItem>()
                    .ForMember(d => d.CategoryTitle, s => s.MapFrom(ss => ss.Category.Title));
                cfg.CreateMap<Task, CrudTaskItem>().ForMember(d => d.CategoryId, s => s.MapFrom(ss => ss.Category.Id));
                cfg.CreateMap<TaskCategory, CrudTaskCategory>();
             

            });

        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper=config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
