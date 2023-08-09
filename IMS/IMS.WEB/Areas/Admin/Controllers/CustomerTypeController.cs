using IMS.Services.Helpers;
using IMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class CustomerTypeController : Controller
    {
        private ICustomerTypeService _CustomerTypeService;

        public CustomerTypeController()
        {
            _CustomerTypeService = new CustomerTypeService();
        }

        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult GetCustomerTypes()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var CustomerTypes = _CustomerTypeService.GetAll(session);
                    CustomerTypes.OrderBy(x => x.Rank);

                    if (CustomerTypes == null || !CustomerTypes.Any())
                    {
                        return Json(new List<ConfigurationDto>(), JsonRequestBehavior.AllowGet);
                    }

                    return Json(CustomerTypes, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
            
            return Json(new { error = "An error occurred while fetching data." });

        }

        // POST: Admin/CustomerType/Create
        [HttpPost]
        public ActionResult Create(ConfigurationFormData CustomerTypeFormData)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _CustomerTypeService.Create(CustomerTypeFormData, session);

                        
                        return Json(new { success = true, message = "CustomerType added successfully." });

                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while adding CustomerType.", ex.Message });
            }

        }


        // POST: Admin/CustomerType/Edit/
        [HttpPost]
        public ActionResult Edit(ConfigurationFormData CustomerTypeFormData)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _CustomerTypeService.Update(CustomerTypeFormData, session);

                        return Json(new { success = true, message = "CustomerType updated successfully." });

                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while updating CustomerType.", ex.Message });
            }
        }



        // POST: Admin/CustomerType/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _CustomerTypeService.Delete(id, session);
                    
                    return Json(new { success = true, message = "Customer Type deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the Customer Type: " + ex.Message });
            }
        }
    }
}
