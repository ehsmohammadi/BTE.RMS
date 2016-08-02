using System.Windows.Controls;
using BTE.RMS.Presentation.Logic.Meeting.View;
using BTE.RMS.Presentation.Logic.WPF.Views;
using ViewBase = BTE.Presentation.UI.WPF.ViewBase;

namespace BTE.RMS.Presentation.WPF.Meeting
{
    /// <summary>
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Meeting : ViewBase,IMeeting
    {
        public Meeting()
        {
            InitializeComponent();
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            
        }
    }
}
