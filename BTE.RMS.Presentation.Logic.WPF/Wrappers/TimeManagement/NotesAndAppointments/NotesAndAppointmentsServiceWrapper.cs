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
               Category = new Category
               {
                   Id = 1000,
                   Title = "کاری",
               },
               RecordCategory = RecordCategory.Note,
               Title = "دستورات مالی",
               WorkProgressPercent = 80,

           }

        }; 
        public void GetAllOveralObjectives(Action<List<NoteAndAppointment>, Exception> action)
        {
            action(noteAndAppointmentList, null);
        }
    }

}
