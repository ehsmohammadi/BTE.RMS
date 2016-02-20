﻿using AutoMapper;
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
