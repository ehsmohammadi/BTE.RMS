using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public class TaskIteration
    {
        public IterationType Type { get; set; }

        public int IterationNo { get; set; }

        public List<string> DayOfWeek { get; set; }

        public List<string> DayOfMonth { get; set; }

        public List<string> Month { get; set; } 


    }
}
