using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.PersonalFinancialManagement.PersonalBudgeting
{
    public class SummeryIncome:ViewModelBase
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

        private long monthlyIncome;

        public long MonthlyIncome
        {
            get { return monthlyIncome; }
            set { this.SetField(p => p.MonthlyIncome, ref monthlyIncome, value); }
        }

        private long yearlyIncome;

        public long YearlyIncome
        {
            get { return yearlyIncome; }
            set { this.SetField(p => p.YearlyIncome, ref yearlyIncome, value); }
        }
    }
}
