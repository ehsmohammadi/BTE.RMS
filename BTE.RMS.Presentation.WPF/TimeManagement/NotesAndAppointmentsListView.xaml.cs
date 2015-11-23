using System.Windows;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic.WPF.Views;

namespace BTE.RMS.Presentation.WPF.Views.TimeManagement
{
    /// <summary>
    /// Interaction logic for NotesAndAppointmentsListView.xaml
    /// </summary>
    public partial class NotesAndAppointmentsListView : ViewBase, INotesAndAppointmentsListView
    {
        public NotesAndAppointmentsListView()
        {
            InitializeComponent();
        }
        private void FiletrCombo_OnLoaded(object sender, RoutedEventArgs e)
        {
            TableFilterCombo.SelectedIndex = 0;
            CalendarFilterCombo.SelectedIndex = 0;
        }

    }
}
