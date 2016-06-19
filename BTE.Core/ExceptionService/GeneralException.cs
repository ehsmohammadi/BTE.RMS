using System;

namespace BTE.Core
{
    internal class GeneralException:Exception, IException
    {
        public GeneralException(string code, string message):base(message)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}
