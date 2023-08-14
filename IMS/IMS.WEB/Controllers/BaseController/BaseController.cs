using IMS.BusinessModel.Dto.Customer;
using IMS.BusinessModel.Dto.GridData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.WEB.Controllers.BaseController
{
    public class BaseController : Controller
    {
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