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
            var value = db.TblContact.Add(p);
            value.SendMessageDate = DateTime.Now;
            value.IsRead = false;
            db.SaveChanges();
            return View("Index", "Default");
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