﻿using System;

namespace BTE.Core
{
    public interface IDuplicateException : IException
    {
        string DomainObjectName { get; }
        string PropertyName { get; }
    }

    public class DuplicateException : Exception, IDuplicateException
    {
        public DuplicateException(string message, string domainObjectName, string propertyName)
            : base(message)
        {
            Code = int.Parse(ApiExceptionCode.Duplicated.Value);
            DomainObjectName = domainObjectName;
            PropertyName = propertyName;
        }

        public string DomainObjectName { private set; get; }

        public string PropertyName { private set; get; }

        public int Code { private set; get; }


    }
}
