using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult MessageList()
        {
            var value = db.TblContact.ToList();
            return View(value);

        }

        //mesaj göndermeyi mesaj ekleme metodu gibi yapıcaz.
        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {
            db.TblContact.Add(p);
            p.SendMessageDate = DateTime.Now;
            p.IsRead = false;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }



        [HttpGet]
        public ActionResult ReadMessage(int id)
        {
            var value = db.TblContact.Find(id);
            value.IsRead= true;
            db.SaveChanges();
            return View(value);
        }


        public ActionResult DeleteMessage(int id) 
        { 
            var value=db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("MessageList");

        }
      

       
    }
}