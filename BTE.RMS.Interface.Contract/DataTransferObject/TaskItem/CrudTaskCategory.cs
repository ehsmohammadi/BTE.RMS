using System;
using System.Drawing;
using BTE.RMS.Common;

namespace BTE.RMS.Interface.Contract.TaskItem
{
    public partial class CrudTaskCategory
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public Color Color { get; set; }
        public int ActionType { get; set; }
        public Guid SyncId { get; set; }
    }
}
