using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.PersonalFinancialManagement.PersonalBudgeting
{
    public class SummeryCostTopic : ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { this.SetField(p => p.Title, ref title, value); }
        }

        private long monthlyCost;

        public long MonthlyCost
        {
            get { return monthlyCost; }
            set { this.SetField(p => p.MonthlyCost,ref monthlyCost, value); }
        }

        private long yearlyCost;

        public long YearlyCost
        {
            get { return yearlyCost; }
            set { this.SetField(p=>p.YearlyCost,ref yearlyCost,value);}
        }
    }
}
