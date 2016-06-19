using System;

namespace BTE.Core
{
    public class ApiExceptionCode:Enumeration
    {
        public static ApiExceptionCode Unknown = new ApiExceptionCode("00001", "unexpected exception occured");
        public static ApiExceptionCode Duplicated = new ApiExceptionCode("00002", "Duplicated");
        public static ApiExceptionCode DeleteFailed = new ApiExceptionCode("00003", "DeleteFailed");
        public static ApiExceptionCode InvalidArgument = new ApiExceptionCode("00004", "InvalidArgument");
        public static ApiExceptionCode InvalidStateOperation = new ApiExceptionCode("00005", "Invalid Operation on State");

        public ApiExceptionCode()
            : base()
        {
        }

        public ApiExceptionCode(string value, string displayName)
            : base(value, displayName)
        {
        }

        public static explicit operator int(ApiExceptionCode x)
        {
            if (x == null)
                throw new InvalidCastException();
            return Convert.ToInt32(x.Value);
        }
        public static implicit operator ApiExceptionCode(int val)
        {
            return FromValue<ApiExceptionCode>(val.ToString());
        }


        
    }
}
