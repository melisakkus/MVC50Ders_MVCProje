using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC50Ders_MVCProje.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hakkında sayfası";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim bilgileri sayfası.";

            return View();
        }

        public ActionResult Bilgi()
        {
            return View();//ilgili sayfayı döndürsün ; actionresulttan türettiğim view'ı döndürür
        }

        public ActionResult Profil()
        {
            return View();
        }
    }
}