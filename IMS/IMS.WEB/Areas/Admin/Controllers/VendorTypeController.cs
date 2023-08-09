using IMS.Services.Helpers;
using IMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class VendorTypeController : Controller
    {
        private IVendorTypeService _vendorTypeService;

        public VendorTypeController()
        {
            _vendorTypeService = new VendorTypeService();
        }

        public ActionResult Index()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var vendorTypes = _vendorTypeService.GetAll(session);
                    return View(vendorTypes);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }




            return View();
        }
        public ActionResult GetVendorTypes()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var vendorTypes = _vendorTypeService.GetAll(session);
                    vendorTypes.OrderBy(x => x.Rank);


                    if (vendorTypes == null || !vendorTypes.Any())
                    {

                        return Json(new List<ConfigurationDto>(), JsonRequestBehavior.AllowGet);
                    }

                    return Json(vendorTypes, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
            return Json(new { error = "An error occurred while fetching data." });

        }

        // POST: Admin/VendorType/Create
        [HttpPost]
        public ActionResult Create(ConfigurationFormData vendorTypeFormData)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _vendorTypeService.Create(vendorTypeFormData, session);


                        return Json(new { success = true, message = "VendorType added successfully." });

                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while adding VendorType.", ex.Message });
            }

        }


        // POST: Admin/VendorType/Edit/
        [HttpPost]
        public ActionResult Edit(ConfigurationFormData vendorTypeFormData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _vendorTypeService.Update(vendorTypeFormData, session);

                        return Json(new { success = true, message = "VendorType updated successfully." });

                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while updating VendorType.", ex.Message });
            }
        }



        // POST: Admin/VendorType/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _vendorTypeService.Delete(id, session);
                    return Json(new { success = true, message = "Vendor Type deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the Vendor Type: " + ex.Message });
            }
        }
    }
}
