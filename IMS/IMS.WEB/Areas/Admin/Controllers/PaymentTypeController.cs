﻿using IMS.Services.Helpers;
using IMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.WEB.Areas.Admin.Controllers
{
    public class PaymentTypeController : Controller
    {
        private IPaymentTypeService _paymentTypeService;

        public PaymentTypeController()
        {

        }

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        public ActionResult Index()
        {
            try
            {
                using (var session = NHibernateConfig.OpenSession())
                {
                    _paymentTypeService = new PaymentTypeService();

                    var paymentTypes = _paymentTypeService.GetAllPaymentTypes(session);
                    return View(paymentTypes);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }
            Console.WriteLine("hello");
            //_logger.Info("hello from home");


            return View();
        }

        // GET: Admin/PaymentType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/PaymentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PaymentType/Create
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

        // GET: Admin/PaymentType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/PaymentType/Edit/5
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

        // GET: Admin/PaymentType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/PaymentType/Delete/5
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