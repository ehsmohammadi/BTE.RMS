using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    //public enum PeriorityType : int
    //{
    //    //[LocalizableDescription(@"A", typeof (Resource1))] A = 1,
    //    //[LocalizableDescription(@"B", typeof (Resource1))] B = 2,
    //    //[LocalizableDescription(@"C", typeof (Resource1))] C = 3,
    //    //[LocalizableDescription(@"D", typeof (Resource1))] D = 4
    //    [Description("مهم-فوری")]
    //    A = 1,
    //    [Description("غیر مهم -فوری")]
    //    B = 2,
    //    [Description("مهم - غیر فوری")]
    //    C = 3,
    //    [Description("غیر مهم -غیر فوری")]
    //    D = 4
    //};

    public class PeriorityType : ViewModelBase
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { this.SetField(p => p.Title, ref title, value); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { this.SetField(p => p.Description, ref description, value); }
        }
    }
}
