using System.Collections.Generic;
using BTE.Core;

namespace BTE.RMS.Model.Meetings
{
    public interface IMeetingRepository : IRepository<Meeting>, IRepository
    {
        IEnumerable<Meeting> GetAllUnsyncForAndroidApp();
        IEnumerable<Meeting> GetAllUnsyncForAndroidAppByCreator(string userName);
        IEnumerable<Meeting> GetAllUnsyncForDesktopApp();
        IEnumerable<Meeting> GetAllUnsyncForDesktopAppByCreator(string userName);
        IEnumerable<Meeting> GetAllByUserName(string userName);


    }
}
