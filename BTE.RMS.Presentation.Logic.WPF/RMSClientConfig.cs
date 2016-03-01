using System;

namespace BTE.RMS.Presentation.Logic
{
    public class RMSClientConfig
    {
        public static string BaseApiAddress { get { return string.Format("{0}/api/", BaseApiSiteAddress); } }

        public static string BaseApiSiteAddress { get; set; }

    }
}
