using System;

namespace BTE.Core
{
    public class ApiExceptionCode:Enumeration
    {
        public static ApiExceptionCode Unknown = new ApiExceptionCode("100", "unexpected exception occured");
        public static ApiExceptionCode Duplicated = new ApiExceptionCode("101", "Duplicated");
        public static ApiExceptionCode DeleteFailed = new ApiExceptionCode("102", "DeleteFailed");
        public static ApiExceptionCode InvalidArgument = new ApiExceptionCode("103", "InvalidArgument");
        public static ApiExceptionCode ModifyForbidden = new ApiExceptionCode("105", "ModifyForbidden");
        public static ApiExceptionCode InvalidCompare = new ApiExceptionCode("105", "InvalidCompare");
        public static ApiExceptionCode InvalidStateOperation = new ApiExceptionCode("124", "Invalid Operation on State");

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
