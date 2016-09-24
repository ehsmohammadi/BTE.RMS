using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Presentation.Logic.Meeting.Model;
using Microsoft.EntityFrameworkCore;

namespace BTE.RMS.Presentation.Logic.Meeting
{
    public class RMSDB:DbContext
    {
        public DbSet<MeetingDB> Meetings;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./blog.db");
        }
    }
}
