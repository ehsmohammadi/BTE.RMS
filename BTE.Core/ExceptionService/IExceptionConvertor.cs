using System.Collections.Generic;

namespace BTE.Core
{
    public interface IExceptionConvertor
    {
        Dictionary<string, string> TryConvert(IException exp);
        IException TryConvertBack(Dictionary<string, string> expData);
    }

    public interface IExceptionConvertor<T> where T : IException
    {
        Dictionary<string, string> Convert(T exception);
        T ConvertBack(Dictionary<string, string> expData);
    }

    public class ExceptionConvertor<T> : IExceptionConvertor where T : IException
    {
        private IExceptionConvertor<T> converter;
        public ExceptionConvertor(IExceptionConvertor<T> converter)
        {
            this.converter = converter;
        }
        public Dictionary<string, string> TryConvert(IException exp)
        {
            if (exp is T)
                return converter.Convert((T)exp);
            return null;
        }

        public IException TryConvertBack(Dictionary<string, string> expData)
        {
            return converter.ConvertBack(expData);
        }
    }
}
