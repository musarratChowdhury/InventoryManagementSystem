using System;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.SalesOrder;
using IMS.Services.Helpers;
using IMS.Services.SecondaryServices;
using Microsoft.AspNet.Identity;

namespace IMS.WEB.Controllers.IMS
{
    public class SalesOrderController : Controller
    {
         private readonly SalesOrderService _salesOrderService;

        public SalesOrderController()
        {
            _salesOrderService = new SalesOrderService();
        }
        // GET: SalesOrder
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource(DataRequest request)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = new DataResult<SalesOrderDto>
                {
                    count = _salesOrderService.GetTotalCount(session),
                    result = _salesOrderService.GetAll(session, request)
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
                    var result = _salesOrderService.GetDropDownList(session);

                    return Json(result, JsonRequestBehavior.AllowGet);
                }

            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Insert(CRUDRequest<SalesOrderFormDto> salesOrderCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _salesOrderService.Create(salesOrderCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        }  
        
        [HttpPost]
        public ActionResult Create(SalesOrderFormDto salesOrderCreateDto)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _salesOrderService.Create(salesOrderCreateDto, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        } 
        
        [HttpPost]
        public ActionResult Update(CRUDRequest<SalesOrderDto> salesOrderCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    
                    _salesOrderService.Update(salesOrderCreateReq.value, User.Identity.GetUserId<long>(), session);

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
                    _salesOrderService.UpdateRank(changeRankDto, session);
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
        public ActionResult Archive(DeleteRequest salesOrderDeleteReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _salesOrderService.ArchiveRecord(salesOrderDeleteReq.Key, session);

                    return Json(new { success = true, message = "Archived successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while archiving.", ex.Message });
            }
        }
        
        [HttpPost]
        public ActionResult Delete(DeleteRequest salesOrderDeleteReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _salesOrderService.Delete(salesOrderDeleteReq.Key, session);

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