using Bussiness;
using Entities;
using KatmanlıMimari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMimari.Controllers
{
    public class SinifController : Controller
    {
        Repository.SinifRepository repSinif = new Repository.SinifRepository();
        SinifModel model = new SinifModel();
        // GET: Sinif
        public ActionResult Index()
        {
            model.slist = repSinif.Listele();
            return View(model);
        }
        public ActionResult Detay(int id)
        {
            model.Sinif = repSinif.Bul(id);
            return View(model);
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(SinifModel sm)
        {
            if (ModelState.IsValid)
            {
                Sinif s = new Sinif();
                s.Sube = sm.Sinif.Sube;
                s.Kademe = sm.Sinif.Kademe;
                if(repSinif.Listele().Where(x=>x.Sube==sm.Sinif.Sube && x.Kademe == sm.Sinif.Kademe).Count() == null) { s.sinifMevcut = 0; }
                else { s.sinifMevcut = sm.Sinif.sinifMevcut; }
                s.sinifMevcut = sm.Sinif.sinifMevcut;
                repSinif.Ekle(s);
                repSinif.Guncel();
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Guncelle(int id)
        {
            model.Sinif = repSinif.Bul(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(int id,SinifModel sm)
        {
            if (ModelState.IsValid) {
            Sinif s = repSinif.Bul(id);
            s.Sube = model.Sinif.Sube;
            s.Kademe = model.Sinif.Kademe;
            s.sinifMevcut = model.Sinif.sinifMevcut;
            repSinif.Guncel();
            return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Sil(int id)
        {
            Sinif s = repSinif.Bul(id);
            repSinif.Sil(s);
            repSinif.Guncel();
          return   RedirectToAction("Index");
        }
        public ActionResult Sube()
        {
            SinifModel s = new SinifModel();
            s.slist = repSinif.GenelListe().Where(x => x.Sube.Contains("A")).ToList();

            return View(s);
        }
    }
}