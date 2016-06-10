using System;
using System.Collections.Generic;

namespace BTE.RMS.Interface.Contract
{
    public class SyncReuest
    {
        public int AppType { get; set; }

    }

    public class SyncItem
    {
        public Guid SyncId { get; set; }

        public int ActionType { get; set; }
    }

}
