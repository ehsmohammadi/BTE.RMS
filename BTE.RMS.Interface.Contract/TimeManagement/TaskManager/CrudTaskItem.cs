using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudTaskItem:BaseTaskItem
    {
        private string content;

        public string Content
        {
            get { return content; }
            set { this.SetField(p=>p.Content,ref content,value);}
        }

        private long categoryId;
        public long CategoryId
        {
            get { return categoryId; }
            set { this.SetField(p=>p.CategoryId,ref categoryId,value);}
        }
        private long taskItemTypeId;

        public long TaskItemTypeId
        {
            get { return taskItemTypeId; }
            set { this.SetField(p => p.TaskItemTypeId, ref taskItemTypeId, value); }
        }
    }
}
