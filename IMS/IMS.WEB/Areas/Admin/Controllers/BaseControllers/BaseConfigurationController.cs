using IMS.Services.Helpers;
using IMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.Services.BaseServices;
using IMS.BusinessModel.Entity.Common;
using IMS.BusinessModel.Dto.GridData;

namespace IMS.WEB.Areas.Admin.Controllers.BaseControllers
{
    public class BaseConfigurationController<TEntity> : Controller where TEntity : IConfigurationEntity
    {
        private BaseConfigurationService<ConfigurationDto, ConfigurationFormData, TEntity> _baseConfigurationService;

        public BaseConfigurationController()
        {
            _baseConfigurationService = new BaseConfigurationService<ConfigurationDto, ConfigurationFormData, TEntity>();
        }

        [HttpPost]
        public ActionResult DataSource()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var result = new DataResult<ConfigurationDto>();
                    result.result = _baseConfigurationService.GetAll(session).ToList();
                    result.count = result.result.Count;

                    return Json(result, JsonRequestBehavior.AllowGet);  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult DropDownList() 
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    var result = _baseConfigurationService.GetDropDownList(session);

                    return Json(result, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {

                    var CustomerTypes = _baseConfigurationService.GetAll(session);
                    CustomerTypes.OrderBy(x => x.Rank);

                    if (CustomerTypes == null || !CustomerTypes.Any())
                    {
                        return Json(new List<ConfigurationDto>(), JsonRequestBehavior.AllowGet);
                    }

                    return Json(CustomerTypes, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }

            return Json(new { error = "An error occurred while fetching data." });

        }

        // POST: Admin/Type/Create
        [HttpPost]
        public ActionResult Create(ConfigurationFormData CustomerTypeFormData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _baseConfigurationService.Create(CustomerTypeFormData, session);


                        return Json(new { success = true, message = "Added successfully." });

                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while Adding.", ex.Message });
            }

        }


        // POST: Admin/Type/Edit/
        [HttpPost]
        public ActionResult Edit(ConfigurationFormData CustomerTypeFormData)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (var session = NHibernateConfig.OpenSession())
                    {
                        _baseConfigurationService.Update(CustomerTypeFormData, session);

                        return Json(new { success = true, message = "Updated successfully." });

                    }
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while updating", ex.Message });
            }
        }



        // POST: Admin/Type/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _baseConfigurationService.Delete(id, session);

                    return Json(new { success = true, message = "Deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting" + ex.Message });
            }
        }
    }
}
