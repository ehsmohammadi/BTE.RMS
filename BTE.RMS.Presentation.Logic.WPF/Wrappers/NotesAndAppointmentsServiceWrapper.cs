using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeNotesAndAppointmentsServiceWrapper : INotesAndAppointmentsServiceWrapper
    {
        private List<SummeryNoteAndAppointment> noteAndAppointmentList = new List<SummeryNoteAndAppointment>
        {
            new SummeryNoteAndAppointment
            {
                Id = 1,
                Category = "asasd",
            }
        }; 
        public void GetAllOveralObjectives(Action<List<SummeryNoteAndAppointment>, Exception> action)
        {
            action(noteAndAppointmentList, null);
        }
    }

}
