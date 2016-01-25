using System.Drawing;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public class TaskCategoryDTO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public Color Color { get; set; }
    }
}
