using BTE.Presentation;
namespace BTE.RMS.Interface.Contract
{
    public class SummeryFinancialAccount : Category
    {
        private string accountTitle;

        public string AccountTitle
        {
            get { return accountTitle; }
            set { this.SetField(p=>p.AccountTitle,ref accountTitle,value);}
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                this.SetField(p => p.Description, ref description, value);
            }
        }
    }
}
