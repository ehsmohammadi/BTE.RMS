using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Interface
{
    public class TaskFacadeService : ITaskFacadeService
    {
        #region Temporary
        public static List<CrudTaskItem> taskItems = new List<CrudTaskItem>
        {
            new CrudTaskItem
                {
                    Id = 1,
                    Title = "طراحی واسط کاربری",
                    StartDate = DateTime.Now,
                    EndTime = DateTime.Now,
                    WorkProgressPercent = 70,
                    StartTime = DateTime.Now,
                    TaskItemType = TaskItemType.Note,
                    CategoryId = 1
                },

                new CrudTaskItem
                {
                    Id = 2,
                    Title = "jlsdkflsdk",
                    StartDate = DateTime.Now,
                    EndTime = DateTime.Now,
                    WorkProgressPercent = 70,
                    StartTime = DateTime.Now,
                    TaskItemType = TaskItemType.Note,
                    CategoryId = 1
                }
        };

        private static List<CrudTaskCategory> categories = new List<CrudTaskCategory>
        {
            new CrudTaskCategory{Id = 1,Title = "کار",Color = Color.White},
            new CrudTaskCategory{Id = 2,Title = "خانواده",Color = Color.White}
        };

        private long getNextId()
        {
            return taskItems.Max(t => t.Id) + 1;
        }
        #endregion


        public List<SummeryTaskItem> GetAll()
        {
            var summeryTasks =
                taskItems.Select(
                    t =>
                        new SummeryTaskItem
                        {
                            CategoryTitle = categories.Single(c => c.Id == t.CategoryId).Title,
                            Id = t.Id,
                            Title = t.Title,
                            EndTime = t.EndTime,
                            StartDate = t.StartDate,
                            TaskItemType = t.TaskItemType,
                            WorkProgressPercent = t.WorkProgressPercent,
                            StartTime = t.StartTime
                        }).ToList();
            return summeryTasks;
        }
    }
}
