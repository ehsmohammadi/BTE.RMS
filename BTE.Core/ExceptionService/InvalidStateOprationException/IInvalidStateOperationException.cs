using System;

namespace BTE.Core
{
    public interface IInvalidOperationOnStateException : IException
    {
        string DomainObjectName { get; }
        string StateName { get; }
        string OperationName { get; }

    }

    public class InvalidOperationOnOnStateException : Exception, IInvalidOperationOnStateException
    {
        public InvalidOperationOnOnStateException(string message, string domainObjectName,
            string stateName, string operationName)
            : base(message)
        {
            Code = ApiExceptionCode.InvalidStateOperation.Value;
            DomainObjectName = domainObjectName;
            StateName = stateName;
            OperationName = operationName;
        }
        public string Code { get; private set; }
        public string DomainObjectName { get; private set; }
        public string StateName { get; private set; }
        public string OperationName { get; private set; }
    }
}
