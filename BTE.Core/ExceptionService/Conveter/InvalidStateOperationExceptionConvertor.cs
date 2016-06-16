using System.Collections.Generic;
using System.Linq;

namespace BTE.Core
{
    public class InvalidStateOperationExceptionConvertor :IExceptionConvertor<IInvalidStateOperationException>
    {

        public Dictionary<string, string> Convert(IInvalidStateOperationException exception)
        {
            var expData = new Dictionary<string, string>();
            expData.Add("Message", exception.Message);
            expData.Add("Type", typeof(IInvalidStateOperationException).Name);
            expData.Add("Code", exception.Code.ToString());
            expData.Add("DomainObjectName", exception.DomainObjectName);
            expData.Add("StateName", exception.StateName);
            expData.Add("OperationName", exception.OperationName);
            return expData;
        }



        public IInvalidStateOperationException ConvertBack(Dictionary<string, string> expData)
        {
            if (!expData.Keys.Contains("Type") || !expData.Keys.Contains("Message"))
                return null;
            var exceptionType = expData["Type"];
            if (exceptionType != typeof(IInvalidStateOperationException).Name)
                return null;
            var message = expData["Message"];
            var domainName = expData["DomainObjectName"];
            var stateName = expData["StateName"];
            var operationName = expData["OperationName"];

            return new InvalidStateOperationException(message, domainName, stateName, operationName);

        }


    }
}
