using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IOveralObjectiveServiceWrapper:IServiceWrapper
    {
        void GetAllOveralObjectives(Action<List<SummeryOveralObjective>, Exception> action);
        void PeriorityTypeList(Action<List<PeriorityType>, Exception> action);
        void CreateOveralObjective(Action<CrudOveralObjective, Exception> action, CrudOveralObjective overalObjective,PeriorityType periorityTypeList);
        void RemoveOveralObjective(Action<SummeryOveralObjective, Exception> action, SummeryOveralObjective selectedOveralObjective);

        void UpdateOveralObjectice(Action<CrudOveralObjective, Exception> action, SummeryOveralObjective selectedOveralObjective);
    }

}
