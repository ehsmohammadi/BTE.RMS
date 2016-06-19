using System;

namespace BTE.Core
{
    public interface IArgumentException : IException
    {
        string DomainObjectName { get; }
        string ArgumentName { get; }
    }

    public class ArgumentException :Exception,  IArgumentException
    {
        public ArgumentException(string message, string domainObjectName, string argumentName)
            : base(message)
        {
            Code = ApiExceptionCode.InvalidArgument.Value;
            DomainObjectName = domainObjectName;
            ArgumentName = argumentName;
        }

        public ArgumentException(string domainObjectName, string argumentName)
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
