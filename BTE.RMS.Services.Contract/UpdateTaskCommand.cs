using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Services.Contract
{
    public class UpdateTaskCommand
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public int WorkProgressPercent { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime StartTime { get; set; }


        public DateTime EndTime { get; set; }

        public long CategoryId { get; set; }

    }
}
