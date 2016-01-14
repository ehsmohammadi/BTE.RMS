using System.Text.RegularExpressions;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryOveralObjective : BaseOveralObjective
    {
        private string periorityTypeTitle;

        public string PeriorityTypeTitle
        {
            get { return periorityTypeTitle; }
            set { this.SetField(p => p.PeriorityTypeTitle, ref periorityTypeTitle, value); }
        }
    }
}
