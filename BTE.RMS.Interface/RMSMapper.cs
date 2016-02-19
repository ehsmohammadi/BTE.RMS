using AutoMapper;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract;

namespace BTE.RMS.Interface
{
    public static class RMSMapper
    {
        private static readonly MapperConfiguration config;
        static RMSMapper()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CrudTaskItem, CreateTaskCommand>();
                cfg.CreateMap<Task, CrudTaskItem>();
            });

        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper=config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
