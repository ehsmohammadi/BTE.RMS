using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using BTE.Core;
using BTE.RMS.Interface;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Web.ViewModel.Task;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class TasksController : Controller
    {
        #region Tasks

        // GET: Tasks
        public ActionResult Index()
        {
            var viewModel = ServiceLocator.Current.GetInstance<TaskListVM>();
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
            var viewModel = ServiceLocator.Current.GetInstance<TaskVM>();
            viewModel.Load(null);
            return View("CreateTask", viewModel);
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskVM taskVM)
        {
            if (ModelState.IsValid)
            {
                taskVM.Create();
                return RedirectToAction("Index");
            }
            else
            {
                taskVM.Load(null);
                return View("CreateTask", taskVM);
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(long id)
        {
            var viewModel = ServiceLocator.Current.GetInstance<TaskVM>();
            viewModel.Load(id);
            return View("EditTask", viewModel);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, TaskVM taskVM)
        {
            if (ModelState.IsValid)
            {
                taskVM.Update();
                return RedirectToAction("Index");
            }
            else
            {
                taskVM.Load(id);
                return View("EditTask", taskVM);
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(long id)
        {
            var viewModel = ServiceLocator.Current.GetInstance<TaskVM>();
            viewModel.Load(id);
            return View("DeleteTask", viewModel);
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection formCollection)
        {
            var viewModel = ServiceLocator.Current.GetInstance<TaskVM>();
            viewModel.Delete(id);
                return RedirectToAction("Index");
        }
        #endregion

        #region Late Reminder
        public ActionResult ReviewTaskList()
        {

            var viewModel = ServiceLocator.Current.GetInstance<TaskListVM>();
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
