using System;
using System.Configuration;

namespace BTE.RMS.Presentation.Web
{
    public static class RMSClientConfig
    {
        public static string BaseApiAddress { get { return String.Format("{0}/api/", BaseApiSiteAddress); } }

        //public static string BaseApiSiteAddress = "http://calander.ebte.ir/";
        //public static string BaseApiSiteAddress = "http://localhost:9461/";
        public static string BaseApiSiteAddress = ConfigurationManager.AppSettings["BaseApiSiteAddress"];

    }
}
