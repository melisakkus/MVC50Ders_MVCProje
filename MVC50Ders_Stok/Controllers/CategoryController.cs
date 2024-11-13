using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC50Ders_Stok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC50Ders_Stok.Controllers
{
    public class CategoryController : Controller
    {
        DbMVC50_7_StokEntities db = new DbMVC50_7_StokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.Tbl_Kategoriler.ToList();
            var degerler = db.Tbl_Kategoriler.ToList().ToPagedList(sayfa,4);
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
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Tbl_Kategoriler.Add(tblKategori);
            db.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            db.Tbl_Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Tbl_Kategoriler model)
        {
            var kategori = db.Tbl_Kategoriler.Find(model.KategoriId);
            kategori.KategoriAd = model.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}            
