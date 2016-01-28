using System.Drawing;

namespace BTE.RMS.Interface.Contract.TaskItem
{
    public partial class CrudTaskCategory
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public Color Color { get; set; }
    }
}
