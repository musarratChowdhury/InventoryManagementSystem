using IMS.Services.Helpers;
using IMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class PaymentTypeController : Controller
    {
        private IPaymentTypeService _paymentTypeService;

        public PaymentTypeController()
        {
            _paymentTypeService = new PaymentTypeService();
        }

        public ActionResult Index()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var paymentTypes = _paymentTypeService.GetAll(session);
                    return View(paymentTypes);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
           
            //_logger.Info("hello from home");


            return View();
        }
        public ActionResult GetPaymentTypes()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var paymentTypes = _paymentTypeService.GetAll(session);
                    paymentTypes.OrderBy(x => x.Rank);

                    // Check if paymentTypes is null or empty
                    if (paymentTypes == null || !paymentTypes.Any())
                    {
                        // Return an empty JSON array to indicate no data found
                        return Json(new List<ConfigurationDto>(), JsonRequestBehavior.AllowGet);
                    }

                    return Json(paymentTypes, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
            // Handle any other error scenarios and return appropriate responses
            return Json(new { error = "An error occurred while fetching data." });

        }

        // POST: Admin/PaymentType/Create
        [HttpPost]
        public ActionResult Create(ConfigurationFormData paymentTypeFormData)
        {
            try
            {
                // Perform validation if needed
                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _paymentTypeService.Create(paymentTypeFormData, session);

                        // Return a JSON response indicating success
                        return Json(new { success = true, message = "PaymentType added successfully." });
   
                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                return Json(new { success = false, message = "Error occurred while adding PaymentType.",ex.Message });
            }

        }


        // POST: Admin/PaymentType/Edit/
        [HttpPost]
        public ActionResult Edit(ConfigurationFormData paymentTypeFormData)
        {
            try
            {
                // Perform validation if needed
                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _paymentTypeService.Update(paymentTypeFormData, session);

                        // Return a JSON response indicating success
                        return Json(new { success = true, message = "PaymentType updated successfully." });

                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                return Json(new { success = false, message = "Error occurred while updating PaymentType.", ex.Message });
            }
        }

     

        // POST: Admin/PaymentType/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentTypeService.Delete(id,session);
                    // Return a success message as JSON
                    return Json(new { success = true, message = "Payment Type deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                // Return an error message as JSON
                return Json(new { success = false, message = "An error occurred while deleting the Payment Type: " + ex.Message });
            }
        }
    }
}
