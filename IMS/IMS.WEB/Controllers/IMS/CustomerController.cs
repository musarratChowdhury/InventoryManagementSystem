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
        public ActionResult DataSource(DataRequest request)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    var result = new DataResult<CustomerDto>();
                    var getAllEntities = _customerService.GetAll(session);
                    result.count = getAllEntities.Count();
                    result.result = getAllEntities.Skip(request.skip).Take(request.take).ToList();

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Insert(CRUDRequest<CustomerFormDto> customerCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _customerService.Create(customerCreateReq.value, session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        }
    }
}