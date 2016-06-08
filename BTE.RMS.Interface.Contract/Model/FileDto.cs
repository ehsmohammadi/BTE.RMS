using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Model
{
    public class FileDto
    {
        public string ContentType { get; set; }

        public byte[] FileContent { get; set; }
    }
}
