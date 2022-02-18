using Bussiness;
using Entities;
using Katmanlı_DAL;
using KatmanlıMimari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Bussiness.Repository;

namespace KatmanlıMimari.Controllers
{
    public class OgrenciController : Controller
    {
        OgrenciRepository repogr = new OgrenciRepository();
        SinifRepository repsinif = new SinifRepository();
        SinifModel sm = new SinifModel();
        DataContext db = new DataContext();
        // GET: Ogrenci
        public ActionResult Index()
        {
            sm.olist = repogr.Listele();

            return View(sm);

        }
        public ActionResult Ekle()
        {
            sm.KademeList = repsinif.GenelListe().Select(x => new SelectListItem
            {
                Text = x.Kademe.ToString(),
                Value=x.Kademe.ToString()
            }).Distinct();


            sm.SubeList = repsinif.GenelListe().Select(x => new SelectListItem
            {
                Text = x.Sube.ToString(),
                Value = x.Sube.ToString()
            });

         
            return View(sm);
        }
        [HttpPost]
        public ActionResult Ekle(SinifModel model)
        {
            if (ModelState.IsValid)
            {
                Ogrenci o = new Ogrenci();
                o.Ad = model.Ogrenci.Ad;
                o.Soyad = model.Ogrenci.Soyad;
                o.Kademe = model.Ogrenci.Kademe;
                o.Sube = model.Ogrenci.Sube;
                o.Adres = model.Ogrenci.Adres;
                o.Yas = model.Ogrenci.Yas;

                repogr.Ekle(o);
                repogr.Guncel();


                sm.Sinif = repsinif.Set().FirstOrDefault(X => X.Sube == model.Sinif.Sube && X.Kademe == model.Sinif.Kademe);
                sm.Sinif.sinifMevcut += 1;
                repsinif.Guncel();
               // aynısını al guncelleye yap sınıf ıd bakarak
               //sil için o ogrencını ait oldgu sınıfın mevcutu dusur smsınıf=ogrensı sınıf ve sube esit olanları al eksı bır yap

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Detaylar(int id)
        {
            sm.Ogrenci = repogr.Bul(id);
            return View(sm);
        }

            public ActionResult Guncelle(int id)
            {
            sm.Ogrenci = repogr.Bul(id);
            return View(sm);
            }
        [HttpPost]
        public ActionResult Guncelle(int id,SinifModel model)
        {
            if (ModelState.IsValid)
            {
                Ogrenci ogr = repogr.Bul(id);
                ogr.Ad = model.Ogrenci.Ad;
                ogr.Adres = model.Ogrenci.Adres;
                ogr.Soyad = model.Ogrenci.Soyad;
                ogr.Yas = model.Ogrenci.Kademe;
                ogr.Sube = model.Ogrenci.Sube;
                ogr.Sinif = model.Ogrenci.Sinif;

               
                repogr.Guncel();




                return RedirectToAction("Index");

            }
            return View();

        }


        
       
    } 
}