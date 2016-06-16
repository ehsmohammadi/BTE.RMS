using System.Collections.Generic;
using System.Linq;

namespace BTE.Core
{
    public class CompareExceptionConvertor :IExceptionConvertor<ICompareException>
    {

        public Dictionary<string, string> Convert(ICompareException exception)
        {
            var expData = new Dictionary<string, string>();
            expData.Add("Message", exception.Message);
            expData.Add("Type", typeof(ICompareException).Name);
            expData.Add("Code", exception.Code.ToString());
            expData.Add("DomainObjectName", exception.DomainObjectName);
            expData.Add("PropertyNameSource", exception.PropertyNameSource);
            expData.Add("PropertyNameCompare", exception.PropertyNameCompare);
            return expData;
        }



        public ICompareException ConvertBack(Dictionary<string, string> expData)
        {
            if (!expData.Keys.Contains("Type") || !expData.Keys.Contains("Message"))
                return null;
            var exceptionType = expData["Type"];
            if (exceptionType != typeof(ICompareException).Name)
                return null;
            var message = expData["Message"];
            var domainName = expData["DomainObjectName"];
            var propertyNameSource = expData["PropertyNameSource"];
            var propertyNameCompare = expData["PropertyNameCompare"];

            return new CompareException(message, domainName, propertyNameSource,propertyNameCompare);

        }


    }
}
