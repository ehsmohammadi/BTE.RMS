using BTE.Presentation;
namespace BTE.RMS.Interface.Contract
{
    public class SummeryFinancialAccount : BaseFinancialAccount
    {
        private ReceiptAndPayment receiptAndPayment;

        public ReceiptAndPayment ReceiptAndPayment
        {
            get { return receiptAndPayment; }
            set { this.SetField(p=>p.ReceiptAndPayment,ref receiptAndPayment,value);}
        }

        private long cash;

        public long Cash
        {
            get { return cash; }
            set { this.SetField(p=>p.Cash,ref cash,value);}
        }
    }
}
