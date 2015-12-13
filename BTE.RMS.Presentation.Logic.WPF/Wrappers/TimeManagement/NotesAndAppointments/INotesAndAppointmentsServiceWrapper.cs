using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface INotesAndAppointmentsServiceWrapper:IServiceWrapper
    {
        void GetAllOveralObjectives(Action<List<NoteAndAppointment>, Exception> action);
    }
}
