using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface INotesAndAppointmentsServiceWrapper:IServiceWrapper
    {
        void GetAllOveralObjectives(Action<List<SummeryNoteAndAppointment>, Exception> action);
    }
}
