﻿using IMS.BusinessModel.Dto.GridData;
using System;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.Vendor;
using IMS.Services.SecondaryServices;
using IMS.Services.Helpers;
using Microsoft.AspNet.Identity;

namespace IMS.WEB.Controllers.IMS
{
    [Authorize]
    public class VendorController : Controller
    {
        private readonly VendorService _vendorService;

        public VendorController()
        {
            _vendorService = new VendorService();
        }
        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource(DataRequest request)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = new DataResult<VendorDto>
                {
                    count = _vendorService.GetTotalCount(session),
                    result = _vendorService.GetAll(session, request)
                };


                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Insert(CRUDRequest<VendorFormDto> vendorCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _vendorService.Create(vendorCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        } 
        
        [HttpPost]
        public ActionResult Update(CRUDRequest<VendorDto> vendorCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    
                    _vendorService.Update(vendorCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Updated successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Updating.", ex.Message });
            }
        } 
        
        [HttpPost]
        public ActionResult UpdateRank(ChangeRankDto changeRankDto)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _vendorService.UpdateRank(changeRankDto, session);
                    var response = new { message = "Rank updated successfully." };
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Updating.", ex.Message });
                throw;
            }
            
        }
        
        [HttpPost]
        public ActionResult Delete(DeleteRequest vendorCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _vendorService.Delete(vendorCreateReq.Key, session);

                    return Json(new { success = true, message = "Deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while deleting.", ex.Message });
            }
        }
    }
}