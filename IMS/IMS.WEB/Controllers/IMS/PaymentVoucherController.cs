using System;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.PaymentVoucher;
using IMS.Services.Helpers;
using IMS.Services.SecondaryServices;
using Microsoft.AspNet.Identity;

namespace IMS.WEB.Controllers.IMS
{
    public class PaymentVoucherController : Controller
    {
        private readonly PaymentVoucherService _paymentVoucherService;

        public PaymentVoucherController()
        {
            _paymentVoucherService = new PaymentVoucherService();
        }
        // GET: PaymentVoucher
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource(DataRequest request)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = new DataResult<PaymentVoucherDto>
                {
                    count = _paymentVoucherService.GetTotalCount(session),
                    result = _paymentVoucherService.GetAll(session, request)
                };


                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Insert(CRUDRequest<PaymentVoucherFormDto> paymentVoucherCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentVoucherService.Create(paymentVoucherCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        }  
        
        [HttpPost]
        public ActionResult Create(PaymentVoucherFormDto paymentVoucherCreateDto)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentVoucherService.Create(paymentVoucherCreateDto, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        } 
        
        [HttpPost]
        public ActionResult Update(CRUDRequest<PaymentVoucherDto> paymentVoucherCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    
                    _paymentVoucherService.Update(paymentVoucherCreateReq.value, User.Identity.GetUserId<long>(), session);

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
                    _paymentVoucherService.UpdateRank(changeRankDto, session);
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
        public ActionResult Delete(DeleteRequest paymentVoucherDeleteReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentVoucherService.Delete(paymentVoucherDeleteReq.Key, session);

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