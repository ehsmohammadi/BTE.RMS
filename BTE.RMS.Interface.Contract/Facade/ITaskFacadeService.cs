using System.Collections.Generic;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface ITaskFacadeService
    {
        List<SummeryTaskItem> GetAll();
    }
}
