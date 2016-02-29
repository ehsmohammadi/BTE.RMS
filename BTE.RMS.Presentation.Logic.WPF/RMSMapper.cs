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
                cfg.CreateMap<CrudTaskItem, Tasks.Model.Task>();
                cfg.CreateMap<CrudTaskItem, Tasks.Model.Task>();

                cfg.CreateMap<Tasks.Model.Task, SummeryTaskItem>()
                    .ForMember(d => d.CategoryTitle, s => s.MapFrom(ss => ss.Category.Title));
                cfg.CreateMap<Tasks.Model.Task, CrudTaskItem>().ForMember(d => d.CategoryId, s => s.MapFrom(ss => ss.Category.Id));
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
