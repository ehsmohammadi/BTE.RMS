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
            //selectedTaskItem.StartDate = DateTime.Now.ToString("d");

        }

        public void GetAllTaskItemList(Action<List<SummeryTaskItem>, Exception> action, SummeryTaskItem selectedTaskItemList)
        {



            //var summeryTasks = taskItemList.Select(
            //    t =>
            //        new SummeryTaskItem
            //        {
            //            CategoryTitle = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
            //            TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
            //            Id = t.Id,
            //            Title = t.Title,
            //            EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
            //            StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
            //            WorkProgressPercent = t.WorkProgressPercent,
            //            StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
            //        }).ToList();
            //action(summeryTasks, null);

        }


        public void GetAllTaskCategoryList(Action<List<CrudTaskCategory>, Exception> action, CrudTaskCategory selectedTaskCategory, SummeryTaskItem selectedTaskItemList)
        {
            //if (selectedTaskItemList.Id == 0)
            //{
            //    var sel = taskCategoryList.Single(c => c.Id == 2);
            //    selectedTaskCategory.Id = sel.Id;
            //    selectedTaskCategory.Title = sel.Title;
            //    selectedTaskCategory.Color = sel.Color;
            //    action(taskCategoryList.Where(c => c.Id != 1).ToList(), null);
            //}
            //else
            //{
            //    var minid = taskCategoryList.Min(c => c.Id);
            //    var sel = taskCategoryList.Single(c => c.Id == minid);
            //    selectedTaskCategory.Id = sel.Id;
            //    selectedTaskCategory.Title = sel.Title;
            //    selectedTaskCategory.Color = sel.Color;
            //    action(taskCategoryList, null);
            //}
        }

        public void GetAllTaskItemTypeList(Action<List<TaskItemType>, Exception> action, TaskItemType selectedTaskItemType, SummeryTaskItem selectedTaskItemList)
        {
            //if (selectedTaskItemList.Id == 0)
            //{
            //    var sel = taskItemTypeList.Single(c => c.Id == 1);
            //    selectedTaskItemType.Id = sel.Id;
            //    selectedTaskItemType.Title = sel.Title;
            //    action(taskItemTypeList.Where(c => c.Id <= 2).ToList(), null);
            //}
            //else
            //{
            //    var sel = taskItemTypeList.Single(c => c.Id == 3);
            //    selectedTaskItemType.Id = sel.Id;
            //    selectedTaskItemType.Title = sel.Title;
            //    action(taskItemTypeList.Where(c => c.Id != 2 && c.Id != 1).ToList(), null);
            //}
            //var sel = taskItemTypeList.Single(c => c.Id == 1);
            //selectedTaskItemType.Id = sel.Id;
            //selectedTaskItemType.Title = sel.Title;
            //action(taskItemTypeList.Where(c => c.Id <= 2).ToList(), null);
        }
        //public void ShowTaskItemTypeFilter(Action<List<SummeryTaskItem>, Exception> action, TaskItemType selectedTaskItemType, TaskCategory selectedTaskCategory, FilterType selectedFilterType)
        //{
        //    //                   new FilterType
        //    //{
        //    //    Title = "تمام یادداشت ها و قرار های ملاقات"
        //    //},
        //    //new FilterType
        //    //{
        //    //    Title = "تمام یادداشت ها"
        //    //},
        //    //new FilterType
        //    //{
        //    //    Title = "یادداشت های انجام شده"
        //    //},
        //    //new FilterType
        //    //{
        //    //    Title = "یادداشت های انجام نشده"
        //    //},
        //    //new FilterType
        //    //{
        //    //    Title = "تمام قرار ملاقات ها"
        //    //},
        //    //            new FilterType
        //    //{
        //    //    Title = "قرار ملاقات های انجام شده"
        //    //},
        //    //new FilterType
        //    //{
        //    //    Title = "قرار ملاقات های انجام نشده"
        //    //}

        //    if (selectedTaskItemType.Id == 3)
        //    {
        //        if (selectedTaskCategory.Id == 1)
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId <= 2).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //        else
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId <= 2 && e.CategoryId == selectedTaskCategory.Id).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //    }
        //    else if (selectedTaskItemType.Id == 4)
        //    {
        //        if (selectedTaskCategory.Id == 1)
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 1).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //        else
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 1 && e.CategoryId == selectedTaskCategory.Id).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //    }
        //    else if (selectedTaskItemType.Id == 5)
        //    {
        //        if (selectedTaskCategory.Id == 1)
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 1 && e.WorkProgressPercent > 0).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //        else
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 1 && e.CategoryId == selectedTaskCategory.Id && e.WorkProgressPercent > 0).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //    }
        //    else if (selectedTaskItemType.Id == 6)
        //    {
        //        if (selectedTaskCategory.Id == 1)
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 1 && e.WorkProgressPercent == 0).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //        else
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 1 && e.CategoryId == selectedTaskCategory.Id && e.WorkProgressPercent == 0).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //    }
        //    else if (selectedTaskItemType.Id == 7)
        //    {
        //        if (selectedTaskCategory.Id == 1)
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 2).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //        else
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 2 && e.CategoryId == selectedTaskCategory.Id).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //    }
        //    else if (selectedTaskItemType.Id == 8)
        //    {
        //        if (selectedTaskCategory.Id == 1)
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 2 && e.WorkProgressPercent > 0).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //        else
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 2 && e.CategoryId == selectedTaskCategory.Id && e.WorkProgressPercent > 0).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //    }
        //    else if (selectedTaskItemType.Id == 9)
        //    {
        //        if (selectedTaskCategory.Id == 1)
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 2 && e.WorkProgressPercent == 0).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //        else
        //        {
        //            var sel = taskItemList.Where(e => e.TaskItemTypeId == 2 && e.CategoryId == selectedTaskCategory.Id && e.WorkProgressPercent == 0).ToList();
        //            var summeryTasks = sel.Select(
        //                t =>
        //                    new SummeryTaskItem
        //                    {
        //                        CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
        //                        TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
        //                        Id = t.Id,
        //                        Title = t.Title,
        //                        EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
        //                        StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
        //                        WorkProgressPercent = t.WorkProgressPercent,
        //                        StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
        //                    }).ToList();
        //            action(summeryTasks, null);
        //        }
        //    }
        //}

        public void ShowCategoryFilter(Action<List<SummeryTaskItem>, Exception> action, CrudTaskCategory selectedTaskCategory)
        {
            //if (selectedTaskCategory.Id == 1)
            //{
            //    var sel = taskItemList.Where(c => c.CategoryId > 1).ToList();
            //    var summeryTasks = sel.Select(
            //        t =>
            //            new SummeryTaskItem
            //            {
            //                CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
            //                TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
            //                Id = t.Id,
            //                Title = t.Title,
            //                EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
            //                StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
            //                WorkProgressPercent = t.WorkProgressPercent,
            //                StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
            //            }).ToList();
            //    action(summeryTasks, null);
            //}
            //else
            //{
            //    var sel = taskItemList.Where(c => c.CategoryId == selectedTaskCategory.Id).ToList();
            //    var summeryTasks = sel.Select(
            //        t =>
            //            new SummeryTaskItem
            //            {
            //                CategoryName = taskCategoryList.Single(c => c.Id == t.CategoryId).Title,
            //                TaskItemTypeTitle = taskItemTypeList.Single(c => c.Id == t.TaskItemTypeId).Title,
            //                Id = t.Id,
            //                Title = t.Title,
            //                EndTime = Convert.ToDateTime(t.EndTime).ToString("t"),
            //                StartDate = Convert.ToDateTime(t.StartDate).ToString("d"),
            //                WorkProgressPercent = t.WorkProgressPercent,
            //                StartTime = Convert.ToDateTime(t.StartTime).ToString("t"),
            //            }).ToList();
            //    action(summeryTasks, null);
            //}

        }


        public void UpdateSelectedTaskItem(Action<SummeryTaskItem, Exception> action, SummeryTaskItem selectedTaskItemList)
        {
            var task = taskItemList.Single(c => c.Id == selectedTaskItemList.Id);
            task.Title = selectedTaskItemList.Title;
            task.WorkProgressPercent = selectedTaskItemList.WorkProgressPercent;
            task.StartTime = selectedTaskItemList.StartTime;
            task.EndTime = selectedTaskItemList.EndTime;
            task.StartDate = selectedTaskItemList.StartDate;
            //task.CategoryId = taskCategoryList.Single(c => c.Title == selectedTaskItemList.CategoryName).Id;
            //task.TaskItemTypeId = taskItemTypeList.Single(c => c.Title == selectedTaskItemList.TaskItemTypeTitle).Id;
        }


        public void RemoveSelectedTaskItem(Action<SummeryTaskItem, Exception> action, SummeryTaskItem selectedTaskItemList)
        {
            if (taskItemList.Count == 0)
            {
                MessageBox.Show("سطری برای حذف کردن وجود ندارد");
            }
            else
            {
                MessageBox.Show("حذف اطلاعات کاربر " + Environment.NewLine + "((" + selectedTaskItemList.Title + "))" +
                                Environment.NewLine + "با موفقیت انجام شود");
                //MessageBox.Show("حذف اطلاعات کاربر " + Environment.NewLine + "((" + selectedTaskItem.Title + "))" +
                //               Environment.NewLine + "با موفقیت انجام شود", "حذف یادداشت//قرار ملاقات", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.RightAlign);
                taskItemList.Remove(taskItemList.Single(c => c.Id == selectedTaskItemList.Id));
            }
        }

        public void RegisterTaskItem(Action<CrudTaskItem, Exception> action, CrudTaskItem selectedTaskItem, CrudTaskCategory selectedTaskCategory,
            TaskItemType selectedTaskItemType)
        {
            //if (selectedTaskItem.Id == 0)
            //{
            //    selectedTaskItem.Id = getNextId();
            //    selectedTaskItem.TaskItemTypeId = selectedTaskItemType.Id;
            //    selectedTaskItem.CategoryId = selectedTaskCategory.Id;

            //    taskItemList.Add(selectedTaskItem);
            //    MessageBox.Show("ثبت اطلاعات جدید با موفقیت انجام شد");
            //}
            //else
            //{
            //    var task = taskItemList.Single(c => c.Id == selectedTaskItem.Id);
            //    task.Title = selectedTaskItem.Title;
            //    task.StartDate = selectedTaskItem.StartDate;
            //    task.StartTime = selectedTaskItem.StartTime;
            //    task.EndTime = selectedTaskItem.EndTime;
            //    task.TaskItemTypeId = selectedTaskItemType.Id;
            //    task.CategoryId = selectedTaskCategory.Id;

            //    MessageBox.Show("اطلاعات با موفقیت ویرایش شد");
            //}
        }
        #endregion

    }

}
