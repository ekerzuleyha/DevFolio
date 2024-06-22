using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult Index()
        {
            //entity frameworkde  count () metodu bir tablodaki kayıt sayısını getirir.
            ViewBag.categoryCount= db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            //ortalama yetenek puanı
            ViewBag.skillAvgValue = db.TblSkill.Average(x=>x.SkillValue);
            //eklenen son başlık adı
            ViewBag.lastSkillTitleName = db.GetLastSkillTitle().FirstOrDefault();
            //EN YÜKSEK DEĞERE SAHİP OLUNAN YETENEK 
            ViewBag.highestSkillValue = db.GetHighestSkillValue().FirstOrDefault();
            //EN DÜŞÜK DEĞERE SAHİP OLUNAN YETENEK 
            ViewBag.lowestSkillValue = db.GetLowestSkillValue().FirstOrDefault();
            //proje katagorisine göre veri getirme
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x=>x.ProjectCategory==1).Count();
            //flutter kategorsine bağlı projeler
            ViewBag.flutterCategoryProjectCount = db.TblProject.Where(x=>x.ProjectCategory==2).Count();








            return View();
        }
    }
}