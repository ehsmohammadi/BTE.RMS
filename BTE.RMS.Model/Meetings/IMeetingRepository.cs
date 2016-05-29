using System.Collections.Generic;
using BTE.Core;

namespace BTE.RMS.Model.Meetings
{
    public interface IMeetingRepository : IRepository<Meeting>, IRepository
    {
        IEnumerable<Meeting> GetAllUnsyncForAndroidApp();
        IEnumerable<Meeting> GetAllUnsyncForDesktopApp();
    }
}
