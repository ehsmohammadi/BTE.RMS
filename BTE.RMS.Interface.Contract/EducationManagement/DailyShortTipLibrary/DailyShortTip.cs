using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class DailyShortTip:Library
    {
        private string source;

        public string Source
        {
            get { return source; }
            set { this.SetField(p=>p.Source,ref source,value);}
        }
    }
}
