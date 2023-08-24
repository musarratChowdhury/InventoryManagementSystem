﻿using IMS.BusinessModel.Dto.GridData;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.Product;
using IMS.Services.SecondaryServices;
using IMS.Services.Helpers;
using Microsoft.AspNet.Identity;

namespace IMS.WEB.Controllers.IMS
{
    public class ProductController : Controller
    {
         private readonly ProductService _productService = new ProductService();

         // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DataSource(DataRequest request)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = new DataResult<ProductDto>
                {
                    count = await _productService.GetTotalCount(session),
                    result = await _productService.GetAll(session, request)
                };


                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetProductById(DropDownDto req)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = await _productService.GetProductById(session, req.Id);
                
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> DropDownList()
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var result = await _productService.GetDropDownList(session);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(CRUDRequest<ProductFormDto> productCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    await _productService.Create(productCreateReq.value, User.Identity.GetUserId<long>(), session);

                    return Json(new { success = true, message = "Added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }
        } 
        
        [HttpPost]
        public async Task<ActionResult> Update(CRUDRequest<ProductDto> productCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    await _productService.Update(productCreateReq.value, User.Identity.GetUserId<long>(), session);
                    return Json(new { success = true, message = "Updated successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Updating.", ex.Message });
            }
        } 
        
        [HttpPost]
        public async Task<ActionResult> UpdateRank(ChangeRankDto changeRankDto)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    await _productService.UpdateRank(changeRankDto, session);
                    var response = new { message = "Rank updated successfully." };
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Updating.", ex.Message });
            }
            
        }
        
        [HttpPost]
        public async Task<ActionResult> Delete(DeleteRequest productCreateReq)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    await _productService.Delete(productCreateReq.Key, session);
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