using System.Collections.Generic;
using System.Linq;

namespace BTE.Core
{
    public class ModifyExceptionConvertor : IExceptionConvertor<IModifyException>
    {

        public Dictionary<string, string> Convert(IModifyException exception)
        {
            var expData = new Dictionary<string, string>();
            expData.Add("Message", exception.Message);
            expData.Add("Type", typeof(IModifyException).Name);
            expData.Add("Code", exception.Code.ToString());
            expData.Add("DomainObjectName", exception.DomainObjectName);
            expData.Add("PropertyName", exception.PropertyName);
            return expData;
        }



        public IModifyException ConvertBack(Dictionary<string, string> expData)
        {
            if (!expData.Keys.Contains("Type") || !expData.Keys.Contains("Message"))
                return null;
            var exceptionType = expData["Type"];
            if (exceptionType != typeof(IModifyException).Name)
                return null;
            var message = expData["Message"];
            var domainName = expData["DomainObjectName"];
            var propertyName = expData["PropertyName"];

            return new ModifyException(message, domainName, propertyName);

        }


    }
}
