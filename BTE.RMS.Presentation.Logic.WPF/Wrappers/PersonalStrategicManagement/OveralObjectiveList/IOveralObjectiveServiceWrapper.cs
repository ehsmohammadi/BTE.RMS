using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IOveralObjectiveServiceWrapper:IServiceWrapper
    {
        void CreateOveralObjective(Action<CrudOveralObjective, Exception> action, CrudOveralObjective overalObjective);

        void ModifyOveralObjective(Action<CrudOveralObjective, Exception> action, CrudOveralObjective overalObjective);

        void DeleteOveralObjective(Action<string, Exception> action, long id);

        void GetOveralObjective(Action<CrudOveralObjective, Exception> action, long id);

        void GetAllOveralObjectives(Action<List<SummeryOveralObjective>, Exception> action);

        //void GetAllOveralObjectives(Action<PageResultDTO<SummeryOveralObjective>, Exception> action, int pageSize, int pagePost);
    }

}
