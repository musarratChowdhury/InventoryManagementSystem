using IMS.BusinessModel.Entity.Configuration;
using IMS.Services.Helpers;
using IMS.WEB.Areas.Admin.Controllers.BaseControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class InvoiceTypeController : BaseConfigurationController<InvoiceType>
    {
        public ActionResult Index()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var result = GetAll();
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }

            return View();
        }
    }
}