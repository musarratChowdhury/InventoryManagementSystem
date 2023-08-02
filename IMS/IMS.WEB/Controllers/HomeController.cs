using IMS.BusinessModel.Entity;
using IMS.Services.Helpers;
using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace IMS.WEB.Controllers
{
    public class HomeController : Controller
    {
        protected static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            Console.WriteLine("hello");
            _logger.Info("hello from home");


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