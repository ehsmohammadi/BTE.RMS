using System;
using AutoMapper;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.Tasks.Model;

namespace BTE.RMS.Presentation.Logic
{
    public static class RMSMapper
    {
        private static readonly MapperConfiguration config;
        static RMSMapper()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CrudTaskItem, Task>().ReverseMap();
                cfg.CreateMap<Task, CrudTaskItem>().ForMember(d => d.CategoryId, s => s.MapFrom(ss => ss.Category.Id))
                    .ForMember(d=>d.StartTime,s=>s.MapFrom(
                    ss => DateTime.Now)).ForMember(d => d.EndTime, s => s.MapFrom(
                    ss => DateTime.Now));
                cfg.CreateMap<Task, SummeryTaskItem>()
                    .ForMember(d => d.CategoryTitle, s => s.MapFrom(ss => ss.Category.Title));
                cfg.CreateMap<TaskCategory, CrudTaskCategory>().ReverseMap();
                cfg.CreateMap<TaskType, TaskTypeDTO>().ReverseMap();
            });

        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper=config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
