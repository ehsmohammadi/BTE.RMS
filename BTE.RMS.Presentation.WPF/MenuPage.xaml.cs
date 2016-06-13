using BTE.RMS.Presentation.WPF.Appointments;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic.WPF.Views;
using BTE.RMS.Presentation.Logic.ViewModels.Appointment;

namespace BTE.RMS.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for MeunPage.xaml
    /// </summary>
    public partial class MenuPage : ViewBase, IPooyaMenuView
    {
        PooyaMenu parent;
        Appointment app;

        public MenuPage(PooyaMenu sender )
        {
            InitializeComponent();
            this.parent = sender;

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var l = new AppointmentVM();
            this.app = new Appointment(this.parent, this);
            app.ViewModel = l;
            this.parent.Main.Navigate(app);
        }
    }
}
