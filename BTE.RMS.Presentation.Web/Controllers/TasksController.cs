using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTE.RMS.Interface.Contract.Web.Facade;

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
            return View("TaskList");
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
