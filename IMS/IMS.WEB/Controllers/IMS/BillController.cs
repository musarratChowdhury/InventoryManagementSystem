using System;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.Bill;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.GridData;
using IMS.Services.Helpers;
using IMS.Services.SecondaryServices;
using Microsoft.AspNet.Identity;

namespace IMS.WEB.Controllers.IMS
{
    public class BillController : Controller
    {
        private readonly BillService _billService;

        public BillController()
        {
            _billService = new BillService();
        }
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource(DataRequest request)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = new DataResult<BillDto>
                {
                    count = _billService.GetTotalCount(session),
                    result = _billService.GetAll(session, request)
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
                    var result = _billService.GetDropDownList(session);

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Insert(CRUDRequest<BillFormDto> billCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _billService.Create(billCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        } 
        
        [HttpPost]
        public ActionResult Update(CRUDRequest<BillDto> billCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    
                    _billService.Update(billCreateReq.value, User.Identity.GetUserId<long>(), session);

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
                    _billService.UpdateRank(changeRankDto, session);
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
        public ActionResult Delete(DeleteRequest billCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _billService.Delete(billCreateReq.Key, session);

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