using System;
using System.Collections.Generic;

namespace BTE.Core
{
    public static class ExceptionConverterService
    {
        private static List<IExceptionConvertor> exceptionConvertors = new List<IExceptionConvertor>();

        public static void RegisterExceptionConvertor<T>(IExceptionConvertor<T> exceptionConvertor)
            where T : IException
        {
            exceptionConvertors.Add(new ExceptionConvertor<T>(exceptionConvertor));
        }

        public static Dictionary<string, string> Convert(Exception exp)
        {
            var res = new Dictionary<string, string>();
            if (!(exp is IException))
            {
                res.Add("Message",exp.Message);
                return res;
            }
            
            foreach (var convertor in exceptionConvertors)
            {
                var dic = convertor.TryConvert(exp as IException);
                if (dic != null)
                {
                    foreach (var itm in dic)
                        res.Add(itm.Key, itm.Value);
                    break;
                }
            }
            if (res.Count == 0)
            {
                res.Add("Message", exp.Message);
                res.Add("Code",((IException)exp).Code.ToString());
                res.Add("Type",typeof(IException).Name);
            }

            return res;
        }

        public static Exception ConvertBack(Dictionary<string, string> dic)
        {
            foreach (var convertor in exceptionConvertors)
            {
                var exp = convertor.TryConvertBack(dic);
                if (exp != null)
                    return exp as Exception;
            }
            if (dic.ContainsKey("Type") && dic["Type"] == typeof (IException).Name)
            {
                return new GeneralException(dic["Code"], dic["Message"]);
            }
            if (dic.ContainsKey("Message") )
                return new Exception(dic["Message"]);
            var message = string.Empty;
            foreach (var dicMember in dic)
            {
                message += dicMember.Key + " : " + dicMember.Value+"      ";
            }
            return new Exception(message);
        }

    }
}
