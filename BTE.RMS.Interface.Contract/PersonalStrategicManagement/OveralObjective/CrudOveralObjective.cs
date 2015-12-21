using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudOveralObjective : SummeryOveralObjective
    {
        private string overview;
        public string Overview
        {
            get { return overview; }
            set { this.SetField(p => p.Overview, ref overview, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { this.SetField(p => p.Description, ref description, value); }
        }


        private string image;
        public string Image
        {
            get { return image; }
            set { this.SetField(p => p.Image, ref image, value); }
        }

    }
}
