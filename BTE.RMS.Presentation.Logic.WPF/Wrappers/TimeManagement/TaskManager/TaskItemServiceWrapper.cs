using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.ViewModels;
using BTE.RMS.Presentation.Logic.WPF.Views;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeTaskItemServiceWrapper : ITaskItemServiceWrapper
    {
        #region List
        private long getNextId()
        {
            return taskItemList.Max(t => t.Id) + 1;
        }
        private static List<CrudTaskItem> taskItemList = new List<CrudTaskItem>
        {
            new CrudTaskItem
            {
                Id = 1,
                CategoryId = 2,
                TaskItemTypeId = 1,
                Content = "Asdasdasdasd",
                Title = "Asasdasdasd",
                WorkProgressPercent = 20
            }
        };
        private static List<TaskItemType> taskItemTypeList=new List<TaskItemType>
        {
            new TaskItemType
            {
                Id = 1,
                Title = "یادداشت"
            },
            new TaskItemType
            {
                Id = 2,
                Title = "قرار ملاقات"
            }
        }; 
        private static List<TaskCategory> taskCategoryList = new List<TaskCategory>
        {
            new TaskCategory
            {
                Id = 1,
                Title = "کاری",
            },
            new TaskCategory
            {
                Id = 2,
                Title = "شخصی",
            },
            new TaskCategory
            {
                Id = 3,
                Title = "عمومی"
            },

        };
        #endregion


        #region Public Property
        public void GetAllTaskItemList(Action<List<SummeryTaskItem>, Exception> action)
        {
            var summeryTasks = taskItemList.Select(
                t =>
                    new SummeryTaskItem
                    {
                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
                        TaskItemTypeTitle = taskItemTypeList.Single(c=>c.Id==t.TaskItemTypeId).Title,
                        Id = t.Id,
                        Title = t.Title,
                        EndTime = t.EndTime,
                        StartDate = t.StartDate,
                        WorkProgressPercent = t.WorkProgressPercent,
                        StartTime = t.StartTime,
                        
                    }).ToList();
            action(summeryTasks, null);
        }


        public void GetAllTaskCategory(Action<List<TaskCategory>, Exception> action)
        {
            action(taskCategoryList, null);
        }

        public void GetAllTaskItemType(Action<List<TaskItemType>, Exception> action)
        {
            action(taskItemTypeList, null);
        }

        public void CreateTaskItem(Action<CrudTaskItem, Exception> action, CrudTaskItem taskItem, TaskCategory selectedTaskCategory,
            TaskItemType selectedTaskItemType)
        {
            taskItem.Id = getNextId();
            taskItem.CategoryId = selectedTaskCategory.Id;
            taskItem.TaskItemTypeId = selectedTaskItemType.Id;
            taskItemList.Add(taskItem);
        }

        public void RemoveTaskItem(Action<SummeryTaskItem, Exception> action, SummeryTaskItem selectedTaskItem)
        {
            taskItemList.Remove(taskItemList.Single(c => c.Id == selectedTaskItem.Id));
        }

        #endregion
    }

}
