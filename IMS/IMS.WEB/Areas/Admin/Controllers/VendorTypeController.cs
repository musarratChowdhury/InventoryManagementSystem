using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class VendorTypeController : Controller
    {
        // GET: Admin/VendorType
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/VendorType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/VendorType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/VendorType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/VendorType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/VendorType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/VendorType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/VendorType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
