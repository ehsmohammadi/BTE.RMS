
using System;
using System.Windows;
using BTE.Presentation.UI.WPF;
using BTE.RMS.Presentation.Logic.WPF.Views;
using BTE.RMS.Presentation.WPF.Today.OutLookCalendar;
using OutlookCalendar.Model;

namespace BTE.RMS.Presentation.WPF.Today
{
    /// <summary>
    /// Interaction logic for SummaryScheduleTodayView.xaml
    /// </summary>
    public partial class TodaySummaryPlanningView : ViewBase, ITodaySummaryPlanningView
    {
        //private Appointments appointments = new Appointments();
        public TodaySummaryPlanningView()
        {
            InitializeComponent();
        }

        //private void Calendar_AddAppointment(object sender, RoutedEventArgs e)
        //{
        //    Appointment appointment = new Appointment();
        //    appointment.Subject = "Subject?";
        //    appointment.StartTime = new DateTime(2008, 10, 22, 16, 00, 00);
        //    appointment.EndTime = new DateTime(2008, 10, 22, 17, 00, 00);

        //    AddAppointmentWindow aaw = new AddAppointmentWindow();
        //    aaw.DataContext = appointment;
        //    aaw.ShowDialog();

        //    appointments.Add(appointment);
        //}
    }
}
