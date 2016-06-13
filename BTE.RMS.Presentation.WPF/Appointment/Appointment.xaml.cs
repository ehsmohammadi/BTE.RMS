using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic.WPF.Views;

namespace BTE.RMS.Presentation.WPF.Appointments
{
    /// <summary>
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : ViewBase , IAppointment
    {
        PooyaMenu parent;
        MenuPage pre;
        public Appointment(PooyaMenu sender , MenuPage p)
        {
            InitializeComponent();
            this.parent = sender;
            this.pre = p;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.parent.Main.Navigate(this.pre);
        }
    }
}
