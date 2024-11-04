using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC50Ders_Stok.Models.Entity;

namespace MVC50Ders_Stok.Controllers
{
    public class UrunController : Controller
    {
        DbMVC50_7_StokEntities db = new DbMVC50_7_StokEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun() 
        { 
            List<SelectListItem> degerler = 
                (from i in db.Tbl_Kategoriler.ToList()
                 select new SelectListItem
                 {
                     Text = i.KategoriAd,
                     Value=i.KategoriAd.ToString()
                 }).ToList();
            return View();  
        }

        [HttpPost]
        public ActionResult YeniUrun(Tbl_Urunler tblUrun)
        {
            db.Tbl_Urunler.Add(tblUrun);
            db.SaveChanges();   
            return View();
        }
    }
}