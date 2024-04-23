using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class SkillController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult SkillList()
        {
            //skill tablosundaki veriler bana listele sont-ra bana values ı döndür
            var values = db.TblSkill.ToList();

            return View(values);
        }

        //yeni bir yetenek ekleme sayfası oluşturmak istiyorum.
        //köşeli parantez içinde eklenen ifadelerin ismi attribute olur
        //httpget ile creatskille ne demek istiyoruz.veriyi sadece okuycak çağrılırken çalışacak yani normalde createskill sayfası ne zaman cağrılmış oluyor programda ilk olarak (ekleme sayfası çağrılcağı zaman ) yani sayfa yüklendiği anda.sen sayfa yüklendiği zaman yapacağın tek şey o sayfayı bana getirmek.sayfa yüklendiği zaman bana sadece o sayfayı getir.1. create skill sayfamızı bize yükleyecek 2. create skill ekleme yapacak. 
        
        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();

        }
        //ekleme işlemi yapabilmek için bizim buraya bi parametre göndermemiz gerekiyor.Bizim göndereceğimiz parametre tblskill sınıfından türeyen bir p parametresi olacak 
        
        
        [HttpPost]
        public ActionResult CreateSkill(TblSkill p) 
        {
            
            db.TblSkill.Add(p);    //p den gelen değeri ekle
                       
            db.SaveChanges();      //değişiklikleri kaydet

            //redirectToActon metodu sayesinde başka bir sayfaya yönlendirme yapabiliyoruz.ekleme işlemi yaptın değişiklikleri kaydettin, sonra tekrar bu sayfaya git.
            return RedirectToAction("SkillList");


        }

        //silme işlemini id ye göre yapıcaz.
        public ActionResult DeleteSkill(int id) 
        {
            var value = db.TblSkill.Find(id); //find metodu id ye göre değer bulmamızı sağlayan                                           metot.göndermiş olduğumuz bütün satırı ele alır.
            db.TblSkill.Remove(value);//tbl skill içerisinden value değişkenindeki değeri kaldır. value                              komple o satırı tutar.

            db.SaveChanges();
            return RedirectToAction("SkillList");

        }

        //güncelleme işlemini yapmak için ilk olarak güncelenecek verileri getirmeyi deniycez.
        // güncellenecek verileri id ye göre getirdik
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            //güncellenecek veriyi id ye göre bul ve bulduktan sonra bana getir
            var value = db.TblSkill.Find(id);
            return View(value);

        }

        //skill türünde bir p parametresi alacak ki güncellemeyi istediğimiz formatta yapabilsin.
        //ilk önce güncellemek istediğimiz değeri bulcaz.bunun için söyle bir işlem yaptık.

        [HttpPost]
        public ActionResult UpdateSkill(TblSkill p) 
        {
            var value = db.TblSkill.Find(p.SkillID);
            value.SkillTitle = p.SkillTitle;
            value.SkillValue = p.SkillValue;
            db.SaveChanges();
            return RedirectToAction("SkillList");

        }
    }
}