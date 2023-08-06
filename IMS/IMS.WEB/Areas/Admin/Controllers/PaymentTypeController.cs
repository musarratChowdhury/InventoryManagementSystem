using IMS.Services.Helpers;
using IMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IMS.BusinessModel.Dto.Configuration;
using System.Threading;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class PaymentTypeController : Controller
    {
        private IPaymentTypeService _paymentTypeService;

        public PaymentTypeController()
        {

        }

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        public ActionResult Index()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentTypeService = new PaymentTypeService();

                    var paymentTypes = _paymentTypeService.GetAllPaymentTypes(session);
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
                    _paymentTypeService = new PaymentTypeService();

                    var paymentTypes = _paymentTypeService.GetAllPaymentTypes(session);

                    // Check if paymentTypes is null or empty
                    if (paymentTypes == null || !paymentTypes.Any())
                    {
                        // Return an empty JSON array to indicate no data found
                        return Json(new List<PaymentTypeDto>(), JsonRequestBehavior.AllowGet);
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
        public ActionResult Create(PaymentTypeDto paymentTypeDto)
        {
            try
            {
                // Perform validation if needed
                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _paymentTypeService = new PaymentTypeService();
                        // Call the PaymentType service to add the new PaymentType to the database
                        _paymentTypeService.CreatePaymentType(paymentTypeDto, session);


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

        // GET: Admin/PaymentType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/PaymentType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/PaymentType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/PaymentType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
