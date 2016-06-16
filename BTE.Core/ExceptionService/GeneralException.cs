using System;

namespace BTE.Core
{
    internal class GeneralException:Exception, IException
    {
        public GeneralException(int code, string message):base(message)
        {
            Code = code;
        }

        public int Code { get; private set; }
    }
}
