using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VtUygulama.Models;
using VtUygulama.ViewModel;

namespace VtUygulama.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        db01Entities db = new db01Entities();
        public ActionResult Index()
        {
            List<tbl_Kayitlar> kayitListe = db.tbl_Kayitlar.ToList();
            return View(kayitListe);
        }

        public ActionResult YeniKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKayit(KayitModel model)
        {
            tbl_Kayitlar kayit = new tbl_Kayitlar();
            kayit.AdSoyad = model.AdSoyad;
            kayit.Email = model.Email;
            kayit.Yas = model.Yas;
            db.tbl_Kayitlar.Add(kayit);
            db.SaveChanges();
            ViewBag.sonuc = "Kayıt Yapıldı";
            return View();
        }

        public ActionResult KayitDuzenle(int? id)
        {
            tbl_Kayitlar kayit = db.tbl_Kayitlar.Where(k => k.Id == id).SingleOrDefault();
            KayitModel model = new KayitModel();
            model.Id = kayit.Id;
            model.AdSoyad = kayit.AdSoyad;
            model.Email = kayit.Email;
            model.Yas = kayit.Yas;
            return View(model);
        }
        [HttpPost]
        public ActionResult KayitDuzenle(KayitModel km)
        {
            tbl_Kayitlar kayit = db.tbl_Kayitlar.Where(k => k.Id ==km.Id).SingleOrDefault();
            kayit.AdSoyad = km.AdSoyad;
            kayit.Email = km.Email;
            kayit.Yas = km.Yas;
            db.SaveChanges();
            ViewBag.sonuc = "Kayıt Güncellendi";
            return View();
           
           
        }
            public ActionResult KayitSil(int? id)
        {
            tbl_Kayitlar kayit = db.tbl_Kayitlar.Where(k => k.Id == id).SingleOrDefault();
            db.tbl_Kayitlar.Remove(kayit);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}