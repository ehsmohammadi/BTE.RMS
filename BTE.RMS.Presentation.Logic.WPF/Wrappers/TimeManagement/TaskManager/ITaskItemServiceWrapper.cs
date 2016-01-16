using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.ViewModels;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface ITaskItemServiceWrapper:IServiceWrapper
    {
        void GetAllTaskItemList(Action<List<SummeryTaskItem>, Exception> action);
        void GetAllTaskCategory(Action<List<TaskCategory>, Exception> action);
        void GetAllTaskItemType(Action<List<TaskItemType>, Exception> action);
        void CreateTaskItem(Action<CrudTaskItem, Exception> action, CrudTaskItem taskItem, TaskCategory selectedTaskCategory, TaskItemType selectedTaskItemType);
        void RemoveTaskItem(Action<SummeryTaskItem, Exception> action, SummeryTaskItem selectedTaskItem);
    }
}
