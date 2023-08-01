using IMS.BusinessModel.Entity;
using IMS.Services.Helpers;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    // Open a session and test the connection with a simple query
                    var paymentTypes = session.Query<PaymentType>().ToList();

                    // Check if any payment types were retrieved
                    if (paymentTypes.Any())
                    {
                        ViewBag.Message = "Connection to the database is successful.";
                    }
                    else
                    {
                        ViewBag.Message = "No data found. Check your database and mappings.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}