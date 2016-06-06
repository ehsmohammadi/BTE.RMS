using System.ComponentModel.DataAnnotations;

namespace BTE.RMS.Model.RMSFiles
{
    public class RMSFile
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
