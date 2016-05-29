using System;
using BTE.RMS.Common;

namespace BTE.RMS.Services.Contract.Synchronization
{
    public class SyncCommand:UserBaseCommad,ISyncCommand
    {
        public Guid SyncId { get; set; }

        public AppType AppType { get; set; }
    }

    public interface ISyncCommand
    {
        Guid SyncId { get; set; }

        AppType AppType { get; set; }
    }
}
