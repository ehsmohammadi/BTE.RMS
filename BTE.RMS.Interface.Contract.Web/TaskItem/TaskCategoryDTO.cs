using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public class TaskCategoryDTO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public Color Color { get; set; }
    }
}
