using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface ITaskFacadeService:IFacadeService
    {
        List<SummeryTaskItem> GetAll();
        List<CrudTaskCategory> GetAllCategories();
        CrudTaskItem Get(long id);
        CrudTaskItem Create(CrudTaskItem task);
        CrudTaskItem Update(CrudTaskItem task);
        void Delete(long id);
    }
}
