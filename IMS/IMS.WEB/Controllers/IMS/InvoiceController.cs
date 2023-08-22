using System;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.Invoice;
using IMS.Services.Helpers;
using IMS.Services.SecondaryServices;
using Microsoft.AspNet.Identity;

namespace IMS.WEB.Controllers.IMS
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController()
        {
            _invoiceService = new InvoiceService();
        }
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataSource(DataRequest request)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = new DataResult<InvoiceDto>
                {
                    count = _invoiceService.GetTotalCount(session),
                    result = _invoiceService.GetAll(session, request)
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
                    var result = _invoiceService.GetDropDownList(session);

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Insert(CRUDRequest<InvoiceFormDto> invoiceCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _invoiceService.Create(invoiceCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        } 
        
        [HttpPost]
        public ActionResult Update(CRUDRequest<InvoiceDto> invoiceCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    
                    _invoiceService.Update(invoiceCreateReq.value, User.Identity.GetUserId<long>(), session);

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
                    _invoiceService.UpdateRank(changeRankDto, session);
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
        public ActionResult Delete(DeleteRequest invoiceCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _invoiceService.Delete(invoiceCreateReq.Key, session);

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