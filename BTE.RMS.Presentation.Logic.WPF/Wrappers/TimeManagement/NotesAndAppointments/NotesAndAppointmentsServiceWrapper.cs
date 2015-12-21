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
                Id = 1000,
                RecordType = RecordType.Note,
                Title = "یادداشت 1",
                WorkProgressPercent = 70,
                Category = new NoteAndAppointmentCategory
                {
                    Id = 10,
                    Title = "کاری",
                }
            },
            new NoteAndAppointment
            {
                Id = 1001,
                RecordType = RecordType.Appointment,
                WorkProgressPercent = 50,
                Title = "یادداشت 2",
                Category = new NoteAndAppointmentCategory
                {
                    Id = 20,
                    Title = "خانوادگی"
                }
            }
        }; 
        public void GetAllOveralObjectives(Action<List<NoteAndAppointment>, Exception> action)
        {
            action(noteAndAppointmentList, null);
        }
    }

}
