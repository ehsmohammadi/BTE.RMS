using System.Collections.Generic;
using System.Linq;

namespace BTE.Core
{
    public class ArgumentExceptionConvertor :IExceptionConvertor<IArgumentException>
    {

        public  Dictionary<string, string> Convert(IArgumentException exception)
        {
            var expData = new Dictionary<string, string>();
            expData.Add("Message", exception.Message);
            expData.Add("Type", typeof(IArgumentException).Name);
            expData.Add("Code", exception.Code.ToString());
            expData.Add("DomainObjectName", exception.DomainObjectName);
            expData.Add("ArgumentName", exception.ArgumentName);
            
            return expData;
        }



        public  IArgumentException ConvertBack(Dictionary<string, string> expData)
        {
            if (!expData.Keys.Contains("Type") || !expData.Keys.Contains("Message"))
                return null;
            var exceptionType = expData["Type"];
            if (exceptionType != typeof(IArgumentException).Name)
                return null;
            var message = expData["Message"];
            var domainName = expData["DomainObjectName"];
            var argumentName = expData["ArgumentName"];

            return new InvalidArgumentException(message, domainName, argumentName);

        }


    }
}
