using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class FeatureController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult FeatureList()
        {
            var value = db.TblFeature.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFeature(TblFeature p)
        {

            db.TblFeature.Add(p);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            db.TblFeature.Remove(value);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)
        {

            var value = db.TblFeature.Find(p.FeatureID);
            value.HeaderTitle = p.HeaderTitle;
            value.HeaderDescription = p.HeaderDescription;
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}