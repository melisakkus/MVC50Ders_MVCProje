using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC50Ders_Stok.Models.Entity;

namespace MVC50Ders_Stok.Controllers
{
    public class MusteriController : Controller
    {

        DbMVC50_7_StokEntities db = new DbMVC50_7_StokEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Musteriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Tbl_Musteriler tblMusteri)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.Tbl_Musteriler.Add(tblMusteri);  
            db.SaveChanges();   
            return RedirectToAction("Index");  
        }

        public ActionResult MusteriSil(int id)
        {
            var musteri = db.Tbl_Musteriler.Find(id);
            db.Tbl_Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.Tbl_Musteriler.Find(id);
            return View("MusteriGetir", musteri);
        }

        public ActionResult MusteriGuncelle(Tbl_Musteriler model)
        {
            var musteri = db.Tbl_Musteriler.Find(model.MusteriId);
            musteri.MusteriAd = model.MusteriAd;
            musteri.MusteriSoyad = model.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}