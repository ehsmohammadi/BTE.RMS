using BTE.Core;

namespace BTE.RMS.Services.Contract.Synchronization
{
    public interface ISyncService:IService
    {
        void SyncByCreate(ISyncCommand syncCommand);
    }
}
