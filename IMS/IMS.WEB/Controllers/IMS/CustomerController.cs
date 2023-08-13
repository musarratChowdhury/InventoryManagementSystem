using IMS.BusinessModel.Dto.GridData;
using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.Customer;
using System.Web.Mvc;
using IMS.BusinessModel.Entity;

namespace IMS.WEB.Controllers.IMS
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource()
        {
            var result = new DataResult<CustomerDto>();
            result.result.Add(new CustomerDto()
            {
                FirstName = "muhit",
                LastName = "chow",
                Address = "dhaka",
                Phone = "019",
                Email = "lorp@gmail.com",
                CustomerTypeId = 1,
                Id = 1,
                Rank = 1,
                CreatedBy = 1,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                ModifiedBy = 1,
                BusinessId = "ims",
                Status = 1,
                Version = 1,
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}