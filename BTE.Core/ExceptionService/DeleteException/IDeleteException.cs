﻿using System;

namespace BTE.Core
{
    public interface IDeleteException:IException
    {
        string DomainObjectName { get; }
        string RelatedObjectName { get; }
    }


    public class InvalidDeleteException : Exception, IDeleteException
    {
        public InvalidDeleteException(string message, string domainObjectName, string relatedObjectName)
            : base(message)
        {
            Code = ApiExceptionCode.DeleteFailed.Value;
            DomainObjectName = domainObjectName;
            RelatedObjectName = relatedObjectName;
        }
        public string Code { get; private set; }
        public string DomainObjectName { get; private set; }
        public string RelatedObjectName { get; private set; }
    }
}
