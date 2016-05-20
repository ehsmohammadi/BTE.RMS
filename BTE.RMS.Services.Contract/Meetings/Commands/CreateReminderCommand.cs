using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Common;

namespace BTE.RMS.Services.Contract.Meetings.Commands
{
    public class CreateReminderCommand
    {
        public long Id { get; set; }
        public RepeatingType RepeatingType { get; set; }
        public RemindType RemindTypes { get; set; }
        public DateTime RemindeTime { get; set; }
        public SeveralTimes SeveralTimes { get; set; }
    }
}
