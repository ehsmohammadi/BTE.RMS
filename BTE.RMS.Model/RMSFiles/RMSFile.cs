using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTE.RMS.Model.Meetings;

namespace BTE.RMS.Model.RMSFiles
{
    public class RMSFile
    {
        #region Properties
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }

        //[ForeignKey("Meeting")]
        //public long Meeting_Id { get; set; }

        //public Meeting Meeting { get; set; }
        #endregion

        #region Costructors
        protected RMSFile()
        {

        }
        public RMSFile(string fileName, string contentType, string content)
        {
            FileName = fileName;
            ContentType = contentType;
            Content = content;
        } 
        #endregion
       
    }
}
