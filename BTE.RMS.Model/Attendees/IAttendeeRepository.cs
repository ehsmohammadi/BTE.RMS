using System.Collections.Generic;
using BTE.Core;

namespace BTE.RMS.Model.Attendees
{
    public interface IAttendeeRepository : IRepository<Attendee>, IRepository
    {
        List<Attendee> FindAttendeesById(List<long> idList);
    }
}
