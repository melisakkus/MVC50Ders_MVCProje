using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC50Ders_Stok.Models.Entity;

namespace MVC50Ders_Stok.Controllers
{
    public class CategoryController : Controller
    {
        DbMVC50_7_StokEntities db = new DbMVC50_7_StokEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Kategoriler.ToList();
            return View(degerler);
        }

        [HttpGet]//sayfa ilk yüklendiğinde
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]//butona basıldığında 
        public ActionResult YeniKategori(Tbl_Kategoriler tblKategori)
        {
            db.Tbl_Kategoriler.Add(tblKategori);
            db.SaveChanges();
            return View();
        }
    }
}            
