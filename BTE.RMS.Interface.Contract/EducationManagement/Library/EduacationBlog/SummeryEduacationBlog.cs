using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryEduacationBlog:SummeryLibrary
    {
        private string headLine;

        public string HeadLine
        {
            get { return headLine; }
            set { this.SetField(p=>p.HeadLine,ref headLine,value);}
        }
        private long crudId;

        public long CrudId
        {
            get { return crudId; }
            set { this.SetField(p => p.CrudId, ref crudId, value); }
        }

    }
}
