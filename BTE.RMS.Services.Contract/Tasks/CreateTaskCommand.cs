using System;
using BTE.RMS.Common;

namespace BTE.RMS.Services.Contract
{
    public class CreateTaskCommand
    {
        public DeviceType DeviceType { get; set; }

        public long CategoryId { get; set; }

        public string Title { get; set; }
            
        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int WorkProgressPercent { get; set; }

        public string Content { get; set; }



        

    }
}
 