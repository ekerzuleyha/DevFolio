using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class DefaultController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

         public PartialViewResult PartialStatistic()
        {
            ViewBag.projectcount = db.TblProject.Count();
            ViewBag.servicecount = db.TblService.Count();
            ViewBag.categorycount = db.TblCategory.Count();
            ViewBag.skillcount = db.TblSkill.Count();
            return PartialView();
        }  


        public PartialViewResult PartialPortfolio()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialReferans()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }


        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

        public PartialViewResult PartialAddress()
        {
            var values = db.TblAddress.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialMedia()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }

         
    }
}