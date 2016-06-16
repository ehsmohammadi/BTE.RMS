using System.Collections.Generic;
using System.Linq;

namespace BTE.Core
{
    public class DuplicateExceptionConvertor :IExceptionConvertor<IDuplicateException>
    {

        public Dictionary<string, string> Convert(IDuplicateException exception)
        {
            var expData = new Dictionary<string, string>();
            expData.Add("Message", exception.Message);
            expData.Add("Type", typeof(IDuplicateException).Name);
            expData.Add("Code", exception.Code.ToString());
            expData.Add("DomainObjectName", exception.DomainObjectName);
            expData.Add("PropertyName", exception.PropertyName);
            return expData;
        }



        public IDuplicateException ConvertBack(Dictionary<string, string> expData)
        {
            if (!expData.Keys.Contains("Type") || !expData.Keys.Contains("Message"))
                return null;
            var exceptionType = expData["Type"];
            if (exceptionType != typeof(IDuplicateException).Name)
                return null;
            var message = expData["Message"];
            var domainName = expData["DomainObjectName"];
            var propertyName = expData["PropertyName"];

            return new DuplicateException(message, domainName, propertyName);

        }


    }
}
