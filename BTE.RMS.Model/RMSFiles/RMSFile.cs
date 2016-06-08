using System.ComponentModel.DataAnnotations;

namespace BTE.RMS.Model.RMSFiles
{
    public class RMSFile
    {
        public RMSFile(string fileName, string contentType, byte[] content)
        {
            FileName = fileName;
            ContentType = contentType;
            Content = content;
        }

        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
