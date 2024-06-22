using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult Index()
        {
            var value = db.TblProject.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> kategoriler = (from i in db.TblCategory.ToList()
                                                select new SelectListItem 
                                                {
                                                    Text=i.CategoryName,
                                                    Value=i.CategoryID.ToString(),
                                                }).ToList();
            ViewBag.kategori = kategoriler;

            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {

            //kategoriyi dropdowndan seçip ekliycez.
            var kategori = db.TblCategory.Where(m => m.CategoryID == p.TblCategory.CategoryID).FirstOrDefault();
            p.TblCategory = kategori;
            p.CreatedDate = DateTime.Now;
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProject.Find(id);

            List<SelectListItem> degerler = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryID.ToString(),

                                             }).ToList();
            ViewBag.degerler = degerler;

            return View( value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var value = db.TblProject.Find(p.ProjectID);
            value.Title = p.Title;
            value.CoverImageUrl = p.CoverImageUrl;
            var kategori = db.TblCategory.Where(m => m.CategoryID == p.TblCategory.CategoryID).FirstOrDefault();
            value.ProjectCategory = kategori.CategoryID;
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}