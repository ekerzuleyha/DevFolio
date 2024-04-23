using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AddressController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        
        public ActionResult AddressList()
        {
            var value = db.TblAddress.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateAddress() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(TblAddress p) 
        {
            db.TblAddress.Add(p);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }

        public ActionResult DeleteAddress(int id) 
        {
            var value=db.TblAddress.Find(id);
            db.TblAddress.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AddressList");

        }
    }
}