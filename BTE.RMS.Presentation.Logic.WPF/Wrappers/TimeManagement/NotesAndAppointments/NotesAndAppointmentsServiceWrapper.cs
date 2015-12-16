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
                Name = "asdasd",
                PercentRun = 20,
                RecordType = RecordType.Appointment,
                Title = "sadsadad"
            },
                        new NoteAndAppointment
            {
                Id = 1000,
                Name = "asdasd",
                PercentRun = 20,
                RecordType = RecordType.Appointment,
                Title = "sadsadad"
            },
                        new NoteAndAppointment
            {
                Id = 1000,
                Name = "asdasd",
                PercentRun = 20,
                RecordType = RecordType.Appointment,
                Title = "sadsadad"
            },
                        new NoteAndAppointment
            {
                Id = 1000,
                Name = "asdasd",
                PercentRun = 20,
                RecordType = RecordType.Appointment,
                Title = "sadsadad"
            },            new NoteAndAppointment
            {
                Id = 1000,
                Name = "asdasd",
                PercentRun = 20,
                RecordType = RecordType.Appointment,
                Title = "sadsadad"
            },            new NoteAndAppointment
            {
                Id = 1000,
                Name = "asdasd",
                PercentRun = 20,
                RecordType = RecordType.Appointment,
                Title = "sadsadad"
            },            new NoteAndAppointment
            {
                Id = 1000,
                Name = "asdasd",
                PercentRun = 20,
                RecordType = RecordType.Appointment,
                Title = "sadsadad"
            },
            new NoteAndAppointment
            {
                Id = 12300,
                Name = "asdasd",
                PercentRun = 50,
                RecordType = RecordType.Note,
                Title = "asdasd"
            }

        }; 
        public void GetAllOveralObjectives(Action<List<NoteAndAppointment>, Exception> action)
        {
            action(noteAndAppointmentList, null);
        }
    }

}
