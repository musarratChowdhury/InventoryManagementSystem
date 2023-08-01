using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.Configuration;
using IMS.BusinessModel.Entity;
using IMS.Services; // Add the namespace for your service interfaces

namespace IMS.WEB.Controllers.Admin
{
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        // GET: PaymentType
        public ActionResult Index()
        {
            // Retrieve a list of all PaymentTypes from the service
            var paymentTypes = _paymentTypeService.GetAllPaymentTypes();

            // Pass the list to the view
            return View(paymentTypes);
        }

        // GET: PaymentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentType/Create
        [HttpPost]
        public ActionResult Create(PaymentTypeDto paymentTypeDto)
        {
            if (ModelState.IsValid)
            {
                // Map the PaymentTypeDto to the entity and add it through the service
                var paymentType = new PaymentType
                {
                    Name = paymentTypeDto.Name,
                    Description = paymentTypeDto.Description,
                    Status = paymentTypeDto.Status
                    // Map other properties as needed
                };

                _paymentTypeService.AddPaymentType(paymentType);

                // Redirect to the Index action to show the updated list of PaymentTypes
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the view with validation errors
            return View(paymentTypeDto);
        }

        // GET: PaymentType/Edit/5
        public ActionResult Edit(long id)
        {
            // Retrieve the PaymentType by id from the service
            var paymentType = _paymentTypeService.GetPaymentTypeById(id);

            if (paymentType == null)
                return HttpNotFound();

            // Map the entity to a PaymentTypeDto and pass it to the view
            var paymentTypeDto = new PaymentTypeDto
            {
                Id = paymentType.Id,
                Name = paymentType.Name,
                Description = paymentType.Description,
                Status = paymentType.Status
                // Map other properties as needed
            };

            return View(paymentTypeDto);
        }

        // POST: PaymentType/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, PaymentTypeDto paymentTypeDto)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing PaymentType by id from the service
                var existingPaymentType = _paymentTypeService.GetPaymentTypeById(id);

                if (existingPaymentType == null)
                    return HttpNotFound();

                // Update the existing PaymentType with data from the DTO
                existingPaymentType.Name = paymentTypeDto.Name;
                existingPaymentType.Description = paymentTypeDto.Description;
                existingPaymentType.Status = paymentTypeDto.Status;
                // Update other properties as needed

                // Save the changes through the service
                _paymentTypeService.UpdatePaymentType(existingPaymentType);

                // Redirect to the Index action to show the updated list of PaymentTypes
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the view with validation errors
            return View(paymentTypeDto);
        }

        // GET: PaymentType/Delete/5
        public ActionResult Delete(long id)
        {
            // Retrieve the PaymentType by id from the service
            var paymentType = _paymentTypeService.GetPaymentTypeById(id);

            if (paymentType == null)
                return HttpNotFound();

            return View(paymentType);
        }

        // POST: PaymentType/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            // Retrieve the PaymentType by id from the service
            var paymentType = _paymentTypeService.GetPaymentTypeById(id);

            if (paymentType == null)
                return HttpNotFound();

            // Delete the PaymentType through the service
            _paymentTypeService.DeletePaymentType(paymentType);

            // Redirect to the Index action to show the updated list of PaymentTypes
            return RedirectToAction("Index");
        }
    }
}
