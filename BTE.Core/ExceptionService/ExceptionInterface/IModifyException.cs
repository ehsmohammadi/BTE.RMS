using System;

namespace BTE.Core
{
    public interface IModifyException:IException
    {
        string DomainObjectName { get; }
        string PropertyName { get; }
    }

    public class ModifyException : Exception, IModifyException
    {
        public ModifyException(string message, string domainObjectName, string propertyName):base(message)
        {
            Code = int.Parse(ApiExceptionCode.ModifyForbidden.Value);
            DomainObjectName = domainObjectName;
            PropertyName = propertyName;
        }
        public int Code { get; private set; }
        public string DomainObjectName { get; private set; }
        public string PropertyName { get; private set; }
    }
}
