using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.WPF.ViewModels;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface ITaskItemServiceWrapper:IServiceWrapper
    {
        #region TaskItemList
        void UpdateSelectedTaskItem(Action<SummeryTaskItem, Exception> action, SummeryTaskItem selectedTaskItemList);
        void RemoveSelectedTaskItem(Action<SummeryTaskItem, Exception> action, SummeryTaskItem selectedTaskItemList);
        void ShowCategoryFilter(Action<List<SummeryTaskItem>, Exception> action, CrudTaskCategory selectedTaskCategory);
        void GetAllTaskItem(Action<CrudTaskItem, Exception> action, CrudTaskItem selectedTaskItem);
        void GetAllTaskItemList(Action<List<SummeryTaskItem>, Exception> action, SummeryTaskItem selectedTaskItemList);
        #endregion

        #region TaskItem
        void GetTaskItem(Action<CrudTaskItem, Exception> action, long id);
        void RegisterTaskItem(Action<CrudTaskItem, Exception> action, CrudTaskItem selectedTaskItem, CrudTaskCategory selectedTaskCategory, TaskItemType selectedTaskItemType);
        #endregion

        #region TaskCategory
        void GetAllTaskCategoryList(Action<List<CrudTaskCategory>, Exception> action, CrudTaskCategory selectedTaskCategory, SummeryTaskItem selectedTaskItemList);
        #endregion

        #region TaskItemType
        void GetAllTaskItemTypeList(Action<List<TaskItemType>, Exception> action, TaskItemType selectedTaskItemType, SummeryTaskItem selectedTaskItemList);
        #endregion
    }
}
