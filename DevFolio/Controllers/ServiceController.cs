﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ServiceController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult ServiceList()
        {
            var values = db.TblService.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        
        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblService.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var value = db.TblService.Find(p.ServiceID);
            value.ServiceTitle = p.ServiceTitle;
            value.ServiceImageUrl = p.ServiceImageUrl;
            value.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

    }
}