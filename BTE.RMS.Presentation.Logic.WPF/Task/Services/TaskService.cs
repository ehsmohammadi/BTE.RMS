using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Presentation.Logic.Task
{
    public class TaskService : ITaskService
    {
        #region Temprory
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

        private static List<CrudTaskCategory> taskCategoryList = new List<CrudTaskCategory>
        {
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

        private long getNextId()
        {

            if (taskItemList.Count == 0)
            {
                return 1;
            }
            return taskItemList.Max(t => t.Id) + 1;
        }

        #endregion

        public void GetAll(Action<List<SummeryTaskItem>, Exception> action)
        {
            action(taskItemList.Select(t => new SummeryTaskItem
            {
                Id = t.Id,
                Title = t.Title,
                TaskItemType = t.TaskItemType,
                CategoryTitle = taskCategoryList.Single(tc => tc.Id == t.Id).Title,
                EndTime = t.EndTime,
                StartDate = t.StartDate,
                WorkProgressPercent = t.WorkProgressPercent,
                StartTime = t.StartTime,
                SyncId = t.SyncId
            }).ToList(), null);

        }
    }

}
