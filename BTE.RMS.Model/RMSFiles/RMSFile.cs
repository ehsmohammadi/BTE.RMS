using System.ComponentModel.DataAnnotations;

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
