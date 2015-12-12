using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeNotesAndAppointmentsServiceWrapper : INotesAndAppointmentsServiceWrapper
    {
        private List<NoteAndAppointment> noteAndAppointmentList = new List<NoteAndAppointment>
        {
            new NoteAndAppointment
            {
                Title = "asdasdasdasd",
                Id = 1,
                Name = "کاری",
                PercentRun = 20,
                RecordType = RecordType.Appointment
            }
        }; 
        public void GetAllOveralObjectives(Action<List<NoteAndAppointment>, Exception> action)
        {
            action(noteAndAppointmentList, null);
        }
    }

}
