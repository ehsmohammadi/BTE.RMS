using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTE.RMS.Common;

namespace BTE.RMS.Model.Meetings
{
    public class MeetingHistory
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public long Id { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Meeting")]
        public long MeetingId { get; set; }

        public Meeting Meeting { get; set; }

        public MeetingOperationEnum Operation { get; set; }

        public DateTime OperationDate { get; set; } 
        #endregion

        #region Constructors
        public MeetingHistory()
        {

        }

        public MeetingHistory(MeetingOperationEnum operation)
        {
            Operation = operation;
            OperationDate = DateTime.Now;
        } 
        #endregion
    }
}
