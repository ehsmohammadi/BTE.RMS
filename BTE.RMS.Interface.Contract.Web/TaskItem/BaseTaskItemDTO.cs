using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public class BaseTaskItemDTO
    {
        public long Id { get; set; }

        public TaskItemType TaskItemType { get; set; }

        public string Title { get; set; }

        public int WorkProgressPercent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public long CategoryId { get; set; }


    }
}
