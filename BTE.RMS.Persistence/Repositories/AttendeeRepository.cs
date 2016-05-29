using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Model.Attendees;

namespace BTE.RMS.Persistence
{
    public class AttendeeRepository : IAttendeeRepository
    {
        #region Fields
        private readonly RMSContext ctx;
        #endregion

        #region Constructors
        public AttendeeRepository(RMSContext rmsContext)
        {
            this.ctx = rmsContext;
        }
        #endregion

        #region Public Methods

        public IList<Attendee> GetAll()
        {
            return
                ctx.Attendees.AsNoTracking()
                    .ToList();
        }

        public Attendee GetBy(long id)
        {
            return ctx.Attendees.Single(t => t.Id == id);
        }

        public void Create(Attendee attendee)
        {
            ctx.Attendees.Add(attendee);
            ctx.SaveChanges();
        }

        public void Update(Attendee attendee)
        {
            ctx.SaveChanges();
        }

        public void Delete(Attendee attendee)
        {
            ctx.Attendees.Remove(attendee);
            ctx.SaveChanges();
        }

        //public Attendee GetBy(Guid syncId)
        //{
        //    return ctx.Attendees.Single(t => t.SyncId == syncId);
        //}

        #endregion

        #region Query Base Methods

        public List<Attendee> FindAttendeesById(List<long> idList)
        {
            return idList==null ? new List<Attendee>() : ctx.Attendees.Where(a => idList.Contains(a.Id)).ToList();
        }

        //public List<Attendee> GetAttendeeByStartDate(DateTime startDate)
        //{
        //    var res = ctx.Attendees.AsNoTracking().Where(t => t.StartDate.Date == startDate.Date);
        //    return res.ToList();

        //}

        //public IEnumerable<Attendee> GetAllUnsyncForAndroidApp()
        //{
        //    var res = ctx.Attendees.AsNoTracking().Include("Category").Where(t => !t.SyncedWithAndriodApp);
        //    return res.ToList();
        //}

        //public IEnumerable<Attendee> GetAllUnsyncForDesktopApp()
        //{
        //    var res = ctx.Attendees.AsNoTracking().Include("Category").Where(t => !t.SyncedWithDesktopApp);
        //    return res.ToList();
        //}

        #endregion

    }
}
