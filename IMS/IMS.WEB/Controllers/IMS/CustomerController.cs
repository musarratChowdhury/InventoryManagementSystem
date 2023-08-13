using IMS.BusinessModel.Dto.GridData;
using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.Customer;
using System.Web.Mvc;
using IMS.BusinessModel.Entity;
using IMS.Services.SecondaryServices;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.Services.Helpers;

namespace IMS.WEB.Controllers.IMS
{
    public class CustomerController : Controller
    {
        private CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var result = new DataResult<CustomerDto>();
                    result.result = _customerService.GetAll(session).ToList();
                    result.count = result.result.Count;

                    return Json(result, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}