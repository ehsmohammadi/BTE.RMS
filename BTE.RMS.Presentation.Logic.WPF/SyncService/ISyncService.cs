using System;
using BTE.Core;

namespace BTE.RMS.Presentation.Logic
{
    public interface ISyncService : IService
    {
        void Sync(Action<string, Exception> action);
    }
}
