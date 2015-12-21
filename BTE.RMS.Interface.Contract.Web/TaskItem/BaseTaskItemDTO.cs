using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }




    }
}
