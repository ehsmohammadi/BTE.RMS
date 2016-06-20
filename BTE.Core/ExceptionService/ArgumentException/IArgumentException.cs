using System;

namespace BTE.Core
{
    public interface IArgumentException : IException
    {
        string DomainObjectName { get; }
        string ArgumentName { get; }
    }

    public class InvalidArgumentException :Exception,  IArgumentException
    {
        public InvalidArgumentException(string message, string domainObjectName, string argumentName)
            : base(message)
        {
            Code = ApiExceptionCode.InvalidArgument.Value;
            DomainObjectName = domainObjectName;
            ArgumentName = argumentName;
        }

        public InvalidArgumentException(string domainObjectName, string argumentName)
            : base("Invalid " + argumentName + " in " + domainObjectName)
        {
            Code = ApiExceptionCode.InvalidArgument.Value;
            DomainObjectName = domainObjectName;
            ArgumentName = argumentName;
        }

        public string Code { get; private set; }
        public string DomainObjectName { get; private set; }
        public string ArgumentName { get; private set; }
    }
}
