using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class CustomerTypeController : Controller
    {
        // GET: Admin/CustomerType
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult GetCustomerTypes()
        //{
        //    // Get your customer type data from the database or any other source
        //    //// For example:
        //    //var customerTypes = 
        //    //return Json(customerTypes, JsonRequestBehavior.AllowGet);
        //}
    }
}