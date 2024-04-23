using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;   //burayı tanımlayarak devfolio projesideki model klasörünü bi aç ,yani içine                         git dedik

namespace DevFolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // dbdev... isimli sınıftan nesne ürettik
        //db aracılığıyla değerlerimize ulaşıcaz bunlar da bizim propertylerimiz olacak.

       
        public ActionResult SocialMediaList()
        {
            //tablodaki tüm değerleri görmek istiyoruz.ve tabloda birden çok değişken türü var ,bunların hepsini var değişen türüyle karşılayabiliriz. 
            //entity frameworkde verileri listelemek için kullanılan metotdur. 
            //bütün verileri koşulsuz getiriyor. sql deki select * from table name sorgusuna karşılık gelir.
            var values = db.TblSocialMedia.ToList();
            //values değişkeni şuanda sosyal medya tablomdan çekmeye çalıştığım bütün verileri içeriyor.ama biz bunu view ın içinde göndermezsek o zaman sayfaya yansımaz ve veriler gelmez.verilerin gelmesi için diyoruz ki sayfa yüklendiğinde sen bu values in içinde ne varsa onları da bu sayfanın içine taşı diyoruz.

            return View(values);
            //sayfa yüklendiğinde sen bu values un içindekileri de bu sayfanın içine taşı diyoruz.
        }
    }
}