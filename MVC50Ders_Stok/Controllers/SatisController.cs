using MVC50Ders_Stok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC50Ders_Stok.Controllers
{
    public class SatisController : Controller
    {
        DbMVC50_7_StokEntities db = new DbMVC50_7_StokEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(Tbl_Satislar yeniSatis)
        {
            db.Tbl_Satislar.Add(yeniSatis);
            db.SaveChanges();
            return View("Index");
        }
    }
}