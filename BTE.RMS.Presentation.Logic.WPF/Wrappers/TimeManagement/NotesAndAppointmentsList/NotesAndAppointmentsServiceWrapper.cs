using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeNotesAndAppointmentsServiceWrapper : INotesAndAppointmentsServiceWrapper
    {
        private List<SummeryNoteAndAppointment> noteAndAppointmentList = new List<SummeryNoteAndAppointment>
        {
            new SummeryNoteAndAppointment
            {
                Category = "کاری",
                PercentRun = 20,
                Title = "ارائه نرم افزار"
            }
        }; 
        public void GetAllOveralObjectives(Action<List<SummeryNoteAndAppointment>, Exception> action)
        {
            action(noteAndAppointmentList, null);
        }
    }

}
