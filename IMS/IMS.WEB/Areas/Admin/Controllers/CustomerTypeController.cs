using IMS.WEB.Areas.Admin.Controllers.BaseControllers;
using IMS.BusinessModel.Entity.Configuration;
using IMS.Services.Helpers;
using System.Web.Mvc;
using System;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class CustomerTypeController : BaseConfigurationController<CustomerType>
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
