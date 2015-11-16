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

        private string explaingoal;
        public string ExplainGoal
        {
            get { return explaingoal; }
            set { this.SetField(p => p.ExplainGoal, ref explaingoal, value); }
        }


        private string image;
        public string Image
        {
            get { return image; }
            set { this.SetField(p => p.Image, ref image, value); }
        }

    }
}
