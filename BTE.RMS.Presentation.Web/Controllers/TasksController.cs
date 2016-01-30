using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using BTE.RMS.Interface;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Web.ViewModel.Task;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class TasksController : Controller
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

        public static List<CrudTaskCategory> Categories = new List<CrudTaskCategory>
        {
            new CrudTaskCategory{Id = 1,Title = "کار",Color = Color.White},
            new CrudTaskCategory{Id = 2,Title = "خانواده",Color = Color.White}
        };

        private long getNextId()
        {
            return taskItems.Max(t => t.Id) + 1;
        }
        #endregion

        #region Fields
        private readonly ITaskFacadeService taskService; 
        #endregion

        #region Constructors
        public TasksController()
        {
            this.taskService = new TaskFacadeService();
        }

        public TasksController(ITaskFacadeService taskService)
        {
            this.taskService = taskService;
        } 
        #endregion

        #region Tasks
        // GET: Tasks
        public ActionResult Index()
        {
            var viewModel = new TaskListVM(taskService);
            viewModel.Load();
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
            var viewModel = new TaskVM();
            return View("CreateTask", viewModel);
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskVM taskVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    taskVM.Update();
                    var task = taskVM.Task;
                    task.Id = getNextId();
                    taskItems.Add(task);
                    return RedirectToAction("Index");
                }
                else
                {
                    taskVM.TaskCategories = Categories;
                    return View("CreateTask", taskVM);
                }
            }
            catch
            {
                taskVM.TaskCategories = Categories;
                return View("CreateTask", taskVM);
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            var task = taskItems.Single(t => t.Id == id);
            var viewModel = new TaskVM { Task = task, TaskCategories = Categories };
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
            var viewModel = new TaskVM { Task = task, TaskCategories = Categories };
            return View("DeleteTask", viewModel);
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
        #endregion

        #region Late Reminder
        public ActionResult ReviewTaskList()
        {

            var viewModel = new TaskListVM(taskService);
            viewModel.Load();
            return View("ReviewTaskList", viewModel);
        } 
        #endregion

        #region Calender View
        public ActionResult CalenderYearView()
        {
            var viewModel = new CalenderYearVM(0);
            return View("CalenderYearView", viewModel);
        }

        public ActionResult NextYear(int year)
        {
            var viewModel = new CalenderYearVM(year + 1);
            return View("CalenderYearView", viewModel);
            //return Content(viewModel.YearView, "text/html");
        }

        public ActionResult PreviousYear(int year)
        {
            var viewModel = new CalenderYearVM(year - 1);
            return View("CalenderYearView", viewModel);
            //return Content(viewModel.YearView, "text/html");
        } 
        #endregion


    }
}
