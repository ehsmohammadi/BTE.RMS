using System;
using System.Collections.Generic;
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

        //public TasksController(ITaskFacadeService taskService)
        //{
        //    this.taskService = taskService;
        //}

        // GET: Tasks
        public ActionResult Index()
        {
            var summeryTasks = new List<SummeryTaskItemDTO>
            {
                new SummeryTaskItemDTO
                {
                    Id = 1,
                    Title = "jlsdkflsdk",
                    StartDate = DateTime.Now,
                    EndTime = DateTime.Now,
                    WorkProgressPercent = 70,
                    StartTime = DateTime.Now,
                    TaskItemType = TaskItemType.Note
                },

                new SummeryTaskItemDTO
                {
                    Id = 1,
                    Title = "jlsdkflsdk",
                    StartDate = DateTime.Now,
                    EndTime = DateTime.Now,
                    WorkProgressPercent = 70,
                    StartTime = DateTime.Now,
                    TaskItemType = TaskItemType.Note
                }
            };
            var taskListVM=new TaskListVM(summeryTasks);
            return View("TaskList",taskListVM);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View("TaskList");
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View("TaskList");
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("TaskList");
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View("TaskList");
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View("TaskList");
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("TaskList");
            }
        }
    }
}
