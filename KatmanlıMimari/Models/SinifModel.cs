using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMimari.Models
{
    public class SinifModel
    {
        public List<Sinif> slist{ get; set; }
        public Sinif Sinif{ get; set; }
        public Ogrenci Ogrenci{ get; set; }
        public List<Ogrenci> olist { get; set; }

        public IEnumerable<SelectListItem>KademeList{ get; set; }
        public IEnumerable<SelectListItem>SubeList{ get; set; }

    }
}