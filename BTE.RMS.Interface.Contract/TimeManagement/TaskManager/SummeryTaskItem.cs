using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryTaskItem:BaseTaskItem
    {
        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { this.SetField(p=>p.CategoryName,ref categoryName,value);}
        }
        private string taskItemTypeTitle;

        public string TaskItemTypeTitle
        {
            get { return taskItemTypeTitle; }
            set { this.SetField(p => p.TaskItemTypeTitle, ref taskItemTypeTitle, value); }
        }
    }
}
