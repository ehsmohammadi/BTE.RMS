using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class FinancPayReceiptController : Controller
    {
        //
        // GET: /FinancPayReceipt/
        public ActionResult FinancPayReceiptList()
        {
            return View();
        }

        public ActionResult CreateFinancReceipt()
        {
            return View();
        }
        public ActionResult CreateFinancPay()
        {
            return View();
        }
        public ActionResult EditFinancReceipt()
        {
            return View();
        }
        public ActionResult EditFinancPay()
        {
            return View();
        }

        public ActionResult DeleteFinancReceipt()
        {
            return View();
        }
        public ActionResult DeleteFinancPay()
        {
            return View();
        }
	}
}