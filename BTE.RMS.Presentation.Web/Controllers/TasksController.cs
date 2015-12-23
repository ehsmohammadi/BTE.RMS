using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTE.RMS.Interface.Contract.Web.Facade;
using BTE.RMS.Interface.Contract.Web.TaskItem;
using BTE.RMS.Presentation.Web.ViewModel;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskFacadeService taskService;

        #region Temporary
        private static List<TaskItemDTO> taskItems = new List<TaskItemDTO>
        {
            new TaskItemDTO
                {
                    Id = 1,
                    Title = "jlsdkflsdk",
                    StartDate = DateTime.Now,
                    EndTime = DateTime.Now,
                    WorkProgressPercent = 70,
                    StartTime = DateTime.Now,
                    TaskItemType = TaskItemType.Note,
                    CategoryId = 1
                },

                new TaskItemDTO
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

        private static List<TaskCategoryDTO> categories = new List<TaskCategoryDTO>
        {
            new TaskCategoryDTO{Id = 1,Title = "friend",Color = Color.White},
            new TaskCategoryDTO{Id = 2,Title = "Family",Color = Color.White}
        };

        private long getNextId()
        {
            return taskItems.Max(t => t.Id) + 1;
        } 
        #endregion


        // GET: Tasks
        public ActionResult Index()
        {
            var summeryTasks =
                taskItems.Select(
                    t =>
                        new SummeryTaskItemDTO
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
            var viewModel = new TaskListVM(summeryTasks);
            return View("TaskList", viewModel);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View("TaskList");
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            var viewModel = new TaskVM { TaskCategories = categories };
            return View("CreateTask", viewModel);
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskVM taskVM)
        {
            try
            {
                var task = taskVM.Task;
                task.Id = getNextId();
                taskItems.Add(task);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateTask");
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            var task = taskItems.Single(t => t.Id == id);
            var viewModel = new TaskVM {Task = task, TaskCategories = categories};
            return View("EditTask", viewModel);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaskVM taskVM)
        {
            try
            {
                var task = taskItems.Single(t => t.Id == id);
                task.CategoryId = taskVM.Task.CategoryId;
                task.Title = taskVM.Task.Title;
                task.EndTime = taskVM.Task.EndTime;
                task.StartDate = taskVM.Task.StartDate;
                task.StartTime = taskVM.Task.StartTime;
                task.EndTime = taskVM.Task.EndTime;
                task.WorkProgressPercent = taskVM.Task.WorkProgressPercent;

                return RedirectToAction("Index");
            }
            catch
            {
                return View("TaskList");
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            var task = taskItems.Single(t => t.Id == id);
            var viewModel = new TaskVM { Task = task, TaskCategories = categories };
            return View("DeleteTask",viewModel);
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            try
            {
                var task = taskItems.Single(t => t.Id == id);
                taskItems.Remove(task);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("TaskList");
            }
        }
    }
}
