using System.Windows;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudOveralObjective : BaseOveralObjective
    {

        private long periorityTypeId;

        public long PeriorityTypeId
        {
            get { return periorityTypeId; }
            set { this.SetField(p => p.PeriorityTypeId, ref periorityTypeId, value); }
        }

        private string overview;
        public string Overview
        {
            get { return overview; }
            set { this.SetField(p => p.Overview, ref overview, value); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { this.SetField(p => p.Image, ref image, value); }
        }
    }
}
