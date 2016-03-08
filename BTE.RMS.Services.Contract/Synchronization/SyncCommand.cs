using System;
using BTE.RMS.Common;

namespace BTE.RMS.Services.Contract.Synchronization
{
    public class SyncCommand<T>:ISyncCommand
    {
        public T Data { get; set; }

        public Guid SyncId { get; set; }

        public AppType ActionTypeOwner { get; set; }
    }

    public interface ISyncCommand
    {
        Guid SyncId { get; set; }

        AppType ActionTypeOwner { get; set; }
    }
}
