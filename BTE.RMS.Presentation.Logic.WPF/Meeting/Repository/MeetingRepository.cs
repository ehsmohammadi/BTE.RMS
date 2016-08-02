using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using BTE.RMS.Common;
using BTE.RMS.Presentation.Logic.Meeting.Model;
using Microsoft.EntityFrameworkCore;

namespace BTE.RMS.Presentation.Logic.Meeting.Repository
{
    public class MeetingRepository:IMeetingRepository
    {
        private RMSDB context;
        private readonly IQueryable<MeetingDB> Meetings;
        public MeetingRepository(RMSDB rmsContext)
        {
            this.context = rmsContext;
            Meetings = context.Meetings;
        }
        public MeetingDB GetBy(long id)
        {
            return Meetings.Single(t => t.Id == id);
        }
        public IList<MeetingDB> GetAll()
        {
            return Meetings.ToList();
        }
        public List<MeetingDB> GetMeetings()
        {
            var res = Meetings.ToList();
            return res;
        }

        public List<MeetingDB> GetMeetings(DateTime startTime)
        {
            var res = Meetings.Where(s => s.StartDate == startTime).ToList();
            return res;
        }

        public void Create(MeetingDB meet)
        {
            context.Meetings.Add(meet);
            context.SaveChanges();
        }

        public void Delete(MeetingDB meet)
        {
            context.Meetings.Remove(meet);
            context.SaveChanges();
        }

        public void Update(MeetingDB meet)
        {
            context.SaveChanges();
        }
    }
}
