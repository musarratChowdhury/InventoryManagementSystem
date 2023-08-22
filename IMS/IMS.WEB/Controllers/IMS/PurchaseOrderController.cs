using System;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.PurchaseOrder;
using IMS.Services.Helpers;
using IMS.Services.SecondaryServices;
using Microsoft.AspNet.Identity;

namespace IMS.WEB.Controllers.IMS
{
    public class PurchaseOrderController : Controller
    {
        private readonly PurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController()
        {
            _purchaseOrderService = new PurchaseOrderService();
        }
        // GET: PurchaseOrder
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource(DataRequest request)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = new DataResult<PurchaseOrderDto>
                {
                    count = _purchaseOrderService.GetTotalCount(session),
                    result = _purchaseOrderService.GetAll(session, request)
                };


                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public ActionResult DropDownList()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    var result = _purchaseOrderService.GetDropDownList(session);

                    return Json(result, JsonRequestBehavior.AllowGet);
                }

            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Insert(CRUDRequest<PurchaseOrderFormDto> purchaseOrderCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _purchaseOrderService.Create(purchaseOrderCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        }  
        
        [HttpPost]
        public ActionResult Create(PurchaseOrderFormDto purchaseOrderCreateDto)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _purchaseOrderService.Create(purchaseOrderCreateDto, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        } 
        
        [HttpPost]
        public ActionResult Update(CRUDRequest<PurchaseOrderDto> purchaseOrderCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    
                    _purchaseOrderService.Update(purchaseOrderCreateReq.value, User.Identity.GetUserId<long>(), session);

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
                    _purchaseOrderService.UpdateRank(changeRankDto, session);
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
        public ActionResult Delete(DeleteRequest purchaseOrderCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _purchaseOrderService.Delete(purchaseOrderCreateReq.Key, session);

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