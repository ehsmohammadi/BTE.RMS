using System;

namespace BTE.Core
{
    public interface IDeleteException:IException
    {
        string DomainObjectName { get; }
        string RelatedObjectName { get; }
    }


    public class DeleteException : Exception, IDeleteException
    {
        public DeleteException(string message, string domainObjectName, string relatedObjectName)
            : base(message)
        {
            Code = int.Parse(ApiExceptionCode.DeleteFailed.Value);
            DomainObjectName = domainObjectName;
            RelatedObjectName = relatedObjectName;
        }
        public int Code { get; private set; }
        public string DomainObjectName { get; private set; }
        public string RelatedObjectName { get; private set; }
    }
}
