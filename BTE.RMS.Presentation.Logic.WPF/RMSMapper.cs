using AutoMapper;

namespace BTE.RMS.Presentation.Logic
{
    public static class RMSMapper
    {
        private static readonly MapperConfiguration config;
        static RMSMapper()
        {
            config = new MapperConfiguration(cfg =>
            {

            });

        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper=config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
