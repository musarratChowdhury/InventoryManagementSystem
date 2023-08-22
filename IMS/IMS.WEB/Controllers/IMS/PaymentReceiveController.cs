using System;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.PaymentReceive;
using IMS.Services.Helpers;
using IMS.Services.SecondaryServices;
using Microsoft.AspNet.Identity;

namespace IMS.WEB.Controllers.IMS
{
    public class PaymentReceiveController : Controller
    {
        private readonly PaymentReceiveService _paymentReceiveService;

        public PaymentReceiveController()
        {
            _paymentReceiveService = new PaymentReceiveService();
        }
        // GET: PaymentReceive
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource(DataRequest request)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = new DataResult<PaymentReceiveDto>
                {
                    count = _paymentReceiveService.GetTotalCount(session),
                    result = _paymentReceiveService.GetAll(session, request)
                };


                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Insert(CRUDRequest<PaymentReceiveFormDto> salesOrderCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentReceiveService.Create(salesOrderCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        }  
        
        [HttpPost]
        public ActionResult Create(PaymentReceiveFormDto salesOrderCreateDto)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentReceiveService.Create(salesOrderCreateDto, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        } 
        
        [HttpPost]
        public ActionResult Update(CRUDRequest<PaymentReceiveDto> salesOrderCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    
                    _paymentReceiveService.Update(salesOrderCreateReq.value, User.Identity.GetUserId<long>(), session);

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
                    _paymentReceiveService.UpdateRank(changeRankDto, session);
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
        public ActionResult Delete(DeleteRequest salesOrderCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentReceiveService.Delete(salesOrderCreateReq.Key, session);

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