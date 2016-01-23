using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryLibrary:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { this.SetField(p => p.Date, ref date, value); }
        }
        private string context;

        public string Context
        {
            get { return context; }
            set { this.SetField(p => p.Context, ref context, value); }
        }
    }
}
