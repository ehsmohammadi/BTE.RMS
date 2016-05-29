using System;

namespace BTE.RMS.Presentation.Web
{
    public static class RMSClientConfig
    {
        public static string BaseApiAddress { get { return String.Format("{0}/api/", BaseApiSiteAddress); } }

        public static string BaseApiSiteAddress = "http://localhost:9461/";
    }
}
