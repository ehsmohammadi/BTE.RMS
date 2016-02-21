using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.ViewModels;
using BTE.RMS.Presentation.Logic.WPF.Views;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeTaskItemServiceWrapper : ITaskItemServiceWrapper
    {
        #region List

        private static List<CrudTaskItem> taskItemList = new List<CrudTaskItem>
        {
            new CrudTaskItem
            {
                Id = 1,
                CategoryId = 2,
                TaskItemType = TaskItemType.Note,
                Title = "علی",
                WorkProgressPercent = 20,
                StartDate = new DateTime?(DateTime.Now)
            },
                        new CrudTaskItem
            {
                Id = 2,
                CategoryId = 2,
                 TaskItemType = TaskItemType.Appointment,
                Title = "علی",
                WorkProgressPercent = 20,
                StartDate = new DateTime?(DateTime.Now)
            },
                        new CrudTaskItem
            {
                Id = 3,
                CategoryId = 4,
                TaskItemType = TaskItemType.Note,
                Title = "علی",
                WorkProgressPercent = 20,
                StartDate = new DateTime?(DateTime.Now)
            },
        };
        private static List<TaskItemType> taskItemTypeList = new List<TaskItemType>
        {
            

        };
        private static List<CrudTaskCategory> taskCategoryList = new List<CrudTaskCategory>
        {
            new CrudTaskCategory
            {
                Id = 1,
                Title = "همه رسته ها",
            },
            new CrudTaskCategory
            {
                Id = 2,
                Title = "کاری",
                Color = Color.Aqua,
            },
            new CrudTaskCategory
            {
                Id = 3,
                Title = "شخصی",
                Color = Color.Aqua,
            },
            new CrudTaskCategory
            {
                Id = 4,
                Title = "عمومی",
                Color = Color.Aqua,
            }
        };
        #endregion

        #region PrivateMethods
        private long getNextId()
        {

            if (taskItemList.Count == 0)
            {
                return 1;
            }
            return taskItemList.Max(t => t.Id) + 1;
        }

        #endregion

        #region Public Methods



        public void GetTaskItem(Action<CrudTaskItem, Exception> action, long id)
        {
            var task = taskItemList.SingleOrDefault(c => c.Id == id);
            action(task, null);
        }

        public void GetAllTaskItem(Action<CrudTaskItem, Exception> action, CrudTaskItem selectedTaskItem)
        {
         
        }

        public void GetAllTaskItemList(Action<List<SummeryTaskItem>, Exception> action, SummeryTaskItem selectedTaskItemList)
        {

        }

        public void GetAllTaskCategoryList(Action<List<CrudTaskCategory>, Exception> action, CrudTaskCategory selectedTaskCategory, SummeryTaskItem selectedTaskItemList)
        {
            
        }

        public void GetAllTaskItemTypeList(Action<List<TaskItemType>, Exception> action, TaskItemType selectedTaskItemType, SummeryTaskItem selectedTaskItemList)
        {

        }
        public void ShowTaskItemTypeFilter(Action<List<SummeryTaskItem>, Exception> action, TaskItemType selectedTaskItemType, CrudTaskCategory selectedTaskCategory, FilterType selectedFilterType)
        {

        }

        public void ShowCategoryFilter(Action<List<SummeryTaskItem>, Exception> action, CrudTaskCategory selectedTaskCategory)
        {
            

        }


        public void UpdateSelectedTaskItem(Action<SummeryTaskItem, Exception> action, SummeryTaskItem selectedTaskItemList)
        {
            
        }


        public void RemoveSelectedTaskItem(Action<SummeryTaskItem, Exception> action, SummeryTaskItem selectedTaskItemList)
        {
            
        }

        public void RegisterTaskItem(Action<CrudTaskItem, Exception> action, CrudTaskItem selectedTaskItem, CrudTaskCategory selectedTaskCategory,
            TaskItemType selectedTaskItemType)
        {
            
        }
        #endregion

    }

}
