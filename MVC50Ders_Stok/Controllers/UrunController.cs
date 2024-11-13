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
                     Value = i.KategoriId.ToString()
                 }).ToList();
            ViewBag.dgr = degerler; // view'a değerleri taşıyacağız
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Tbl_Urunler tblUrun)
        {
            var kategori = db.Tbl_Kategoriler.Where(m => m.KategoriId == tblUrun.Tbl_Kategoriler.KategoriId).FirstOrDefault();
            tblUrun.Tbl_Kategoriler = kategori;
            db.Tbl_Urunler.Add(tblUrun);
            db.SaveChanges();   
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> urunler = (from x in db.Tbl_Kategoriler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.KategoriAd,
                                                Value = x.KategoriId.ToString()
                                            }).ToList();
            ViewBag.ktgr = urunler;

            var urun = db.Tbl_Urunler.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Tbl_Urunler model)
        {
            var urun = db.Tbl_Urunler.Find(model.UrunId);
            urun.UrunAd = model.UrunAd; 
            urun.UrunMarka = model.UrunMarka;
            urun.UrunFiyat = model.UrunFiyat;
            urun.UrunStok = model.UrunStok;

            //urun.UrunKategori = model.UrunKategori;
            var kategori = db.Tbl_Kategoriler.Where(m => m.KategoriId == model.Tbl_Kategoriler.KategoriId).FirstOrDefault();
            urun.UrunKategori = kategori.KategoriId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}