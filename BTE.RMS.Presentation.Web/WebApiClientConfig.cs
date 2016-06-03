using System;
using System.Configuration;

namespace BTE.RMS.Presentation.Web
{
    public static class WebApiClientConfig
    {
        public static string WebApiUrl { get { return String.Format("{0}/api/", WebApiSite); } }
        public static string WebApiSite { get { return ConfigurationManager.AppSettings["WebApiSite"]; } }

    }
}
